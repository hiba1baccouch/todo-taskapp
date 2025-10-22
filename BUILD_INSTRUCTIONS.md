# Build Instructions for Desktop Task Aid (WPF)

## Prerequisites

- **Visual Studio 2019 or 2022** (Community, Professional, or Enterprise)
- **.NET Framework 4.8 SDK** (usually included with Visual Studio)
- **Windows 10/11** operating system

## Building the Application

### Option 1: Using Visual Studio

1. Open Visual Studio
2. Click **File** → **Open** → **Project/Solution**
3. Navigate to `netapp` folder and open `DesktopTaskAid.csproj`
4. Wait for NuGet packages to restore (this happens automatically)
5. Press **F6** or click **Build** → **Build Solution**
6. Press **F5** to run the application in debug mode

### Option 2: Using Command Line

Open PowerShell or Command Prompt in the `netapp` directory and run:

```powershell
# Restore NuGet packages
dotnet restore

# Build the project
dotnet build --configuration Release

# Run the application
dotnet run
```

## Project Output

After building, the executable will be located at:
```
netapp\bin\Debug\net48\DesktopTaskAid.exe
```

Or for release builds:
```
netapp\bin\Release\net48\DesktopTaskAid.exe
```

## NuGet Packages

The following packages will be automatically restored:

- **Google.Apis.Calendar.v3** (1.69.0.3746) - Google Calendar API
- **Google.Apis.Auth** (1.72.0) - OAuth authentication
- **Newtonsoft.Json** (13.0.4) - JSON serialization

## Data Storage

The application stores data in:
```
C:\Users\{YourUsername}\AppData\Roaming\DesktopTaskAid\appState.json
```

## Troubleshooting

### Build Errors

1. **Missing .NET Framework 4.8**
   - Install from: https://dotnet.microsoft.com/download/dotnet-framework/net48

2. **NuGet Package Restore Failed**
   - Run `dotnet restore` manually
   - Or in Visual Studio: **Tools** → **NuGet Package Manager** → **Restore NuGet Packages**

3. **XAML Design-Time Errors**
   - These are usually safe to ignore if the project builds successfully
   - Restart Visual Studio if the designer doesn't load

### Runtime Errors

1. **Application doesn't start**
   - Check if .NET Framework 4.8 is installed
   - Run as Administrator if permission issues occur

2. **Data not persisting**
   - Check folder permissions for AppData\Roaming
   - Data is stored in JSON format in the AppData folder

## Creating a Distributable Package

### Using Visual Studio Publish

1. Right-click the project in Solution Explorer
2. Click **Publish**
3. Choose **Folder** as target
4. Select output folder
5. Click **Publish**

### Manual Distribution

Copy these files from the bin folder:
- `DesktopTaskAid.exe`
- All `.dll` files
- `DesktopTaskAid.exe.config`

## Adding Google Calendar Integration

To enable Google Calendar sync:

1. Create a Google Cloud Project
2. Enable the Google Calendar API
3. Create OAuth 2.0 credentials
4. Download the credentials JSON file
5. Place it in the application directory as `google-credentials.json`

For detailed instructions, see: https://developers.google.com/calendar/api/quickstart/dotnet

## Development Tips

- The application uses **MVVM architecture**
- Models are in `Models/` folder
- ViewModels in `ViewModels/`
- Views (XAML) are in the root and `Views/` folder
- Services in `Services/`
- All styling is in `Themes/` folder

## Hot Reload (Visual Studio 2022+)

With Visual Studio 2022, you can use XAML Hot Reload:
- Run the application in debug mode
- Edit XAML files
- Changes appear immediately without restarting

## Known Issues

- Timer doesn't persist running state between app restarts (by design)
- Google Calendar sync requires additional setup
- Dark theme requires restart to fully apply

## Support

For issues or questions, refer to the README.md file in the netapp folder.
