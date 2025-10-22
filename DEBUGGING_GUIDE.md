# Debugging Guide - Desktop Task Aid

## Comprehensive Logging System Added

I've added extensive logging throughout the application to help diagnose why nothing is showing on your desktop when you run the app.

## What Was Added

### 1. **LoggingService** (`Services/LoggingService.cs`)
- Centralized logging system that writes to both file and debug output
- Automatic exception capture with full stack traces
- Log files are date-stamped for easy tracking

### 2. **Logging Locations Added**
- ✅ **App.xaml.cs**: Application startup, global exception handlers
- ✅ **MainWindow.xaml.cs**: Window initialization, loading, rendering events
- ✅ **MainViewModel.cs**: ViewModel construction, all initialization steps
- ✅ **StorageService.cs**: State loading/saving, file operations
- ✅ **Converters**: Exception handling in all value converters

### 3. **Exception Handling**
- Global unhandled exception handlers at app level
- Try-catch blocks in critical initialization code
- User-friendly error messages showing log file location

## How to Use

### Step 1: Run the Application
Build and run your application:
```bash
dotnet build
dotnet run
```

### Step 2: View the Logs

#### Option A: Use the Helper Script
Double-click **`ViewLogs.bat`** in the project folder to open the log directory.

#### Option B: Manual Access
Navigate to:
```
%APPDATA%\DesktopTaskAid\
```
Or full path:
```
C:\Users\MSI\AppData\Roaming\DesktopTaskAid\
```

### Step 3: Open the Log File
The log file is named: `app_log_YYYYMMDD.txt` (e.g., `app_log_20251022.txt`)

## What to Look For in Logs

### 1. **Successful Startup Sequence**
```
[INFO] === APPLICATION STARTED ===
[INFO] === OnStartup BEGIN ===
[INFO] Setting up unhandled exception handlers
[INFO] Calling base.OnStartup
[INFO] === MainWindow Constructor BEGIN ===
[INFO] Calling InitializeComponent
[INFO] InitializeComponent completed successfully
[INFO] === MainWindow Constructor COMPLETED ===
[INFO] === MainViewModel Constructor BEGIN ===
[INFO] Creating StorageService
[INFO] Loading application state
[INFO] State loaded - Tasks count: 3
[INFO] MainWindow Loaded event fired
[INFO] MainWindow ContentRendered event fired - Window is now visible to user
```

### 2. **Common Issues to Check**

#### Issue: XAML Parsing Error
Look for:
```
[ERROR] ERROR in MainWindow constructor
Exception: XamlParseException
```
**Solution**: Check MainWindow.xaml for syntax errors or missing resources

#### Issue: DataContext Binding Error
Look for:
```
[ERROR] ERROR in MainViewModel constructor
```
**Solution**: Check MainViewModel initialization, property bindings

#### Issue: Missing Theme Resources
Look for:
```
[ERROR] Theme file not found
```
**Solution**: Verify `Themes/lightTheme.xaml` and `Themes/darkTheme.xaml` exist

#### Issue: Converter Errors
Look for:
```
[ERROR] ERROR in [ConverterName].Convert
```
**Solution**: Check data being bound to converters

#### Issue: File Access Errors
Look for:
```
[ERROR] ERROR in LoadState
Exception: UnauthorizedAccessException
```
**Solution**: Check file permissions for AppData folder

## Common Failure Patterns

### Pattern 1: Nothing in Log File
- **Cause**: App isn't starting at all, or LoggingService failing
- **Check**: Build errors, missing dependencies, .NET Framework version

### Pattern 2: Logs Stop at "MainWindow Constructor BEGIN"
- **Cause**: XAML parsing failure in MainWindow.xaml
- **Check**: XAML syntax, resource dictionaries, control templates

### Pattern 3: Logs Stop at "MainViewModel Constructor BEGIN"
- **Cause**: Error in ViewModel initialization
- **Check**: State loading, collection initialization

### Pattern 4: Logs Complete but Window Not Visible
- **Cause**: Window rendered off-screen or behind other windows
- **Check**: 
  - Window size in logs
  - WindowState property
  - Multi-monitor setup

## Additional Debugging Commands

### Check if Process is Running
```powershell
Get-Process | Where-Object {$_.ProcessName -like "*DesktopTaskAid*"}
```

### Check Build Output
```bash
dotnet build --verbosity detailed
```

### Run with Debug Output
```bash
dotnet run --verbosity detailed
```

## Error Messages with Log Path

If an error occurs, you'll see a message box with:
```
Critical startup error occurred. Check log file at:
C:\Users\MSI\AppData\Roaming\DesktopTaskAid\app_log_YYYYMMDD.txt

Error: [Error message]
```

## Next Steps After Reviewing Logs

1. **Share the log file** - Send me the contents of the log file
2. **Note the last successful step** - Tell me where the logs stop
3. **Check for ERROR entries** - Any lines starting with [ERROR] are critical
4. **Look for exceptions** - Full stack traces will help identify the exact issue

## Files Modified

- ✅ `Services/LoggingService.cs` - New logging service
- ✅ `App.xaml.cs` - Added startup logging and exception handlers
- ✅ `MainWindow.xaml.cs` - Added window lifecycle logging
- ✅ `ViewModels/MainViewModel.cs` - Added initialization logging
- ✅ `Services/StorageService.cs` - Added file operation logging
- ✅ `Converters/*.cs` - Added exception handling to all converters
- ✅ `ViewLogs.bat` - Helper script to open log folder
- ✅ `DEBUGGING_GUIDE.md` - This guide

## Contact

If you need help interpreting the logs, paste the relevant error lines or share the full log file.
