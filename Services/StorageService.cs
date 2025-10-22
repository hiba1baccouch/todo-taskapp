using System;
using System.IO;
using Newtonsoft.Json;
using DesktopTaskAid.Models;

namespace DesktopTaskAid.Services
{
    public class StorageService
    {
        private readonly string _dataFolder;
        private readonly string _stateFilePath;

        public StorageService()
        {
            LoggingService.Log("StorageService constructor started");
            
            _dataFolder = Path.Combine(
                Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData),
                "DesktopTaskAid"
            );
            
            LoggingService.Log($"Data folder path: {_dataFolder}");

            if (!Directory.Exists(_dataFolder))
            {
                LoggingService.Log("Data folder does not exist, creating it");
                Directory.CreateDirectory(_dataFolder);
                LoggingService.Log("Data folder created successfully");
            }
            else
            {
                LoggingService.Log("Data folder already exists");
            }

            _stateFilePath = Path.Combine(_dataFolder, "appState.json");
            LoggingService.Log($"State file path: {_stateFilePath}");
        }

        public AppState LoadState()
        {
            LoggingService.Log("LoadState called");
            
            try
            {
                if (!File.Exists(_stateFilePath))
                {
                    LoggingService.Log("State file does not exist, creating default state");
                    return CreateDefaultState();
                }

                LoggingService.Log("Reading state file");
                var json = File.ReadAllText(_stateFilePath);
                LoggingService.Log($"State file read successfully, length: {json.Length} chars");
                
                LoggingService.Log("Deserializing state");
                var state = JsonConvert.DeserializeObject<AppState>(json);
                
                // Ensure state is valid
                if (state == null || state.Tasks == null)
                {
                    LoggingService.Log("WARNING: Deserialized state is null or invalid, creating default state");
                    return CreateDefaultState();
                }

                LoggingService.Log($"State deserialized successfully - Tasks: {state.Tasks.Count}, Theme: {state.Settings?.Theme}");

                // Refresh timer daily tracking
                LoggingService.Log("Refreshing timer daily tracking");
                state.Timer.RefreshDailyTracking();

                LoggingService.Log("LoadState completed successfully");
                return state;
            }
            catch (Exception ex)
            {
                LoggingService.LogError("ERROR in LoadState, creating default state", ex);
                return CreateDefaultState();
            }
        }

        public void SaveState(AppState state)
        {
            try
            {
                LoggingService.Log("SaveState called");
                var json = JsonConvert.SerializeObject(state, Formatting.Indented);
                LoggingService.Log($"State serialized, writing to file (length: {json.Length} chars)");
                File.WriteAllText(_stateFilePath, json);
                LoggingService.Log("State saved successfully");
            }
            catch (Exception ex)
            {
                LoggingService.LogError("ERROR saving state", ex);
            }
        }

        private AppState CreateDefaultState()
        {
            LoggingService.Log("CreateDefaultState called - creating new state with sample data");
            
            var state = new AppState();
            
            // Add sample tasks
            state.Tasks.Add(new TaskItem
            {
                Name = "Understanding the tools in Figma",
                DueDate = new DateTime(2025, 1, 14),
                DueTime = new TimeSpan(9, 0, 0),
                ReminderStatus = "active",
                ReminderLabel = "Monday, Jan 14 - 9:00"
            });

            state.Tasks.Add(new TaskItem
            {
                Name = "Review project mockups",
                DueDate = new DateTime(2025, 1, 18),
                DueTime = new TimeSpan(14, 30, 0),
                ReminderStatus = "overdue",
                ReminderLabel = "Saturday, Jan 18 - 2:30 PM"
            });

            state.Tasks.Add(new TaskItem
            {
                Name = "Prepare presentation slides",
                DueDate = new DateTime(2025, 1, 20),
                DueTime = new TimeSpan(10, 0, 0),
                ReminderStatus = "none",
                ReminderLabel = "Not set"
            });

            LoggingService.Log($"Default state created with {state.Tasks.Count} sample tasks");
            return state;
        }

        public string GetDataFolderPath()
        {
            return _dataFolder;
        }
    }
}
