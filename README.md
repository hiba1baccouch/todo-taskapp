# Desktop Task Aid - WPF Application

A modern task management desktop application built with WPF, C#, and .NET Framework 4.8.

## Features

- ✅ Task Management (Create, Read, Update, Delete)
- ✅ Calendar View with Month Navigation
- ✅ Pomodoro Timer (25 minutes)
- ✅ Daily Task Preview
- ✅ Dark/Light Theme Toggle
- ✅ Local JSON Storage
- ✅ Google Calendar Integration (OAuth 2.0)
- ✅ MVVM Architecture

## Build & Run

### Prerequisites
- Visual Studio 2019/2022
- .NET Framework 4.8

### Build
```bash
dotnet build
```

### Run
```bash
dotnet run
```

Or open `DesktopTaskAid.csproj` in Visual Studio and press F5.

## Architecture

- **MVVM Pattern**: Model-View-ViewModel
- **Data Binding**: Two-way binding for all UI elements
- **Services**: Storage service for JSON persistence
- **Converters**: Value converters for UI transformations

## Project Structure

```
netapp/
├── Models/              # Data models
├── ViewModels/          # ViewModels with INotifyPropertyChanged
├── Views/               # XAML views
├── Services/            # Business logic services
├── Converters/          # Value converters
├── Helpers/             # Utility classes
├── App.xaml            # Application resources
└── MainWindow.xaml     # Main window
```

## Technologies

- WPF (Windows Presentation Foundation)
- C# (.NET Framework 4.8)
- Newtonsoft.Json for JSON serialization
- Google.Apis.Calendar for Google Calendar integration
