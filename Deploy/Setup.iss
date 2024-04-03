﻿; https://github.com/DomGries/InnoDependencyInstaller


; requires netcorecheck.exe and netcorecheck_x64.exe (see CodeDependencies.iss)
#define public Dependency_Path_NetCoreCheck "dependencies\"

; requires dxwebsetup.exe (see CodeDependencies.iss)
;#define public Dependency_Path_DirectX "dependencies\"

#include "CodeDependencies.iss"

[Setup]
#define MyAppSetupName 'Foxter'
#define MyAppVersion '0.0.0.13'
#define MyAppPublisher 'Drew IT Solutions'

AppName={#MyAppSetupName}
AppVersion={#MyAppVersion}
AppVerName={#MyAppSetupName} {#MyAppVersion}
VersionInfoVersion={#MyAppVersion}
VersionInfoCompany={#MyAppPublisher}
AppPublisher={#MyAppPublisher}
OutputBaseFilename={#MyAppSetupName}-{#MyAppVersion}
DefaultGroupName={#MyAppSetupName}
DefaultDirName={autopf}\{#MyAppSetupName}
UninstallDisplayIcon={app}\Foxter.exe
OutputDir={#SourcePath}\bin
AllowNoIcons=yes
PrivilegesRequired=admin

; remove next line if you only deploy 32-bit binaries and dependencies
; ArchitecturesInstallIn64BitMode=x64

[Languages]
Name: en; MessagesFile: "compiler:Default.isl"
Name: fr; MessagesFile: "compiler:Languages\French.isl"
Name: it; MessagesFile: "compiler:Languages\Italian.isl"
Name: de; MessagesFile: "compiler:Languages\German.isl"
Name: es; MessagesFile: "compiler:Languages\Spanish.isl"

[Files]

Source: "..\Foxter\bin\Release\net7.0-windows10.0.17763.0\Foxter.exe"; DestDir: "{app}"; Flags: ignoreversion
Source: "..\Foxter\bin\Release\net7.0-windows10.0.17763.0\*.dll"; DestDir: "{app}"; Flags: ignoreversion
Source: "..\Foxter\bin\Release\net7.0-windows10.0.17763.0\runtimes\*"; DestDir: "{app}\runtimes"; Flags: ignoreversion recursesubdirs createallsubdirs external


[Registry]
Root: HKCU; Subkey: "SOFTWARE\Microsoft\Windows\CurrentVersion\Run"; ValueType: string; ValueName: "Foxter"; ValueData: """{app}\Foxter.exe"""; Flags: uninsdeletevalue



[Icons]
Name: "{group}\{#MyAppSetupName}"; Filename: "{app}\Foxter.exe"
Name: "{group}\{cm:UninstallProgram,{#MyAppSetupName}}"; Filename: "{uninstallexe}"
Name: "{commondesktop}\{#MyAppSetupName}"; Filename: "{app}\Foxter.exe"; Tasks: desktopicon

[Tasks]
Name: "desktopicon"; Description: "{cm:CreateDesktopIcon}"

[Run]
Filename: "{app}\Foxter.exe"; Description: "{cm:LaunchProgram,{#MyAppSetupName}}"; Flags: nowait postinstall skipifsilent

[Code]
function InitializeSetup: Boolean;
begin
  // comment out functions to disable installing them
   
#ifdef Dependency_Path_NetCoreCheck
  Dependency_AddDotNet70;
  Dependency_AddDotNet70Desktop;
#endif



  Result := True;
end;
