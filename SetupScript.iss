; Script generated by the Inno Setup Script Wizard.
; SEE THE DOCUMENTATION FOR DETAILS ON CREATING INNO SETUP SCRIPT FILES!

#define MyAppName "UtilitiesForAlibre"
#define MyAppVersion "2.0.0.0"
#define MyAppPublisher "David Bolsover"

[Setup]
; NOTE: The value of AppId uniquely identifies this application. Do not use the same AppId value in installers for other applications.
; (To generate a new GUID, click Tools | Generate GUID inside the IDE.)
AppId={{D9BC46BC-D193-411D-B726-06D4CB0B6D52}
AppName={#MyAppName}
AppVersion={#MyAppVersion}
;AppVerName={#MyAppName} {#MyAppVersion}
AppPublisher={#MyAppPublisher}
DefaultDirName={autopf}\{#MyAppName}
DefaultGroupName={#MyAppName}
DisableProgramGroupPage=yes
; Uncomment the following line to run in non administrative install mode (install for current user only.)
PrivilegesRequired=admin
;PrivilegesRequiredOverridesAllowed=dialog
OutputDir=D:\Repository\Jetbrains\Bolsover\UtilitiesForAlibre\UtilitiesForAlibre\bin\Setup
OutputBaseFilename=UtilitiesForAlibreSetup
SetupIconFile=D:\Repository\Jetbrains\Bolsover\UtilitiesForAlibre\UtilitiesForAlibre\bin\Release\nexus.ico
Compression=lzma
SolidCompression=yes
WizardStyle=modern
ArchitecturesAllowed=x64
ArchitecturesInstallIn64BitMode=x64

[Languages]
Name: "english"; MessagesFile: "compiler:Default.isl"

[Files]
Source: "D:\Repository\Jetbrains\Bolsover\UtilitiesForAlibre\UtilitiesForAlibre\bin\Release\Copyright and License.txt"; DestDir: "{app}"; Flags: ignoreversion
Source: "D:\Repository\Jetbrains\Bolsover\UtilitiesForAlibre\UtilitiesForAlibre\bin\Release\nexus.ico"; DestDir: "{app}"; Flags: ignoreversion

Source: "D:\Repository\Jetbrains\Bolsover\UtilitiesForAlibre\UtilitiesForAlibre\bin\Release\ObjectListView.dll"; DestDir: "{app}"; Flags: ignoreversion
Source: "D:\Repository\Jetbrains\Bolsover\UtilitiesForAlibre\UtilitiesForAlibre\bin\Release\UtilitiesForAlibre.dll.config"; DestDir: "{app}"; Flags: ignoreversion
Source: "D:\Repository\Jetbrains\Bolsover\UtilitiesForAlibre\UtilitiesForAlibre\bin\Release\ObjectListView.pdb"; DestDir: "{app}"; Flags: ignoreversion
Source: "D:\Repository\Jetbrains\Bolsover\UtilitiesForAlibre\UtilitiesForAlibre\bin\Release\ObjectListView.xml"; DestDir: "{app}"; Flags: ignoreversion
Source: "D:\Repository\Jetbrains\Bolsover\UtilitiesForAlibre\UtilitiesForAlibre\bin\Release\UtilitiesForAlibre.adc"; DestDir: "{app}"; Flags: ignoreversion
Source: "D:\Repository\Jetbrains\Bolsover\UtilitiesForAlibre\UtilitiesForAlibre\bin\Release\UtilitiesForAlibre.dll"; DestDir: "{app}"; Flags: ignoreversion
Source: "D:\Repository\Jetbrains\Bolsover\UtilitiesForAlibre\UtilitiesForAlibre\bin\Release\MathML.dll"; DestDir: "{app}"; Flags: ignoreversion
Source: "D:\Repository\Jetbrains\Bolsover\UtilitiesForAlibre\UtilitiesForAlibre\bin\Release\MathNet.Numerics.dll"; DestDir: "{app}"; Flags: ignoreversion
Source: "D:\Repository\Jetbrains\Bolsover\UtilitiesForAlibre\UtilitiesForAlibre\bin\Release\WpfMath.dll"; DestDir: "{app}"; Flags: ignoreversion
Source: "D:\Repository\Jetbrains\Bolsover\UtilitiesForAlibre\UtilitiesForAlibre\bin\Release\XamlMath.Shared.dll"; DestDir: "{app}"; Flags: ignoreversion
Source: "D:\Repository\Jetbrains\Bolsover\UtilitiesForAlibre\UtilitiesForAlibre\bin\Release\UtilitiesForAlibre.pdb"; DestDir: "{app}"; Flags: ignoreversion
Source: "D:\Repository\Jetbrains\Bolsover\UtilitiesForAlibre\UtilitiesForAlibre\bin\Release\Gear\PinionTemplate.AD_PRT"; DestDir: "{app}\Gear\"; Flags: ignoreversion
Source: "D:\Repository\Jetbrains\Bolsover\UtilitiesForAlibre\UtilitiesForAlibre\bin\Release\Gear\WheelTemplate.AD_PRT"; DestDir: "{app}\Gear\"; Flags: ignoreversion
Source: "D:\Repository\Jetbrains\Bolsover\UtilitiesForAlibre\UtilitiesForAlibre\bin\Release\Gear\HelicalPinionTemplate.AD_PRT"; DestDir: "{app}\Gear\"; Flags: ignoreversion
Source: "D:\Repository\Jetbrains\Bolsover\UtilitiesForAlibre\UtilitiesForAlibre\bin\Release\Gear\HelicalWheelTemplate.AD_PRT"; DestDir: "{app}\Gear\"; Flags: ignoreversion

Source: "D:\Repository\Jetbrains\Bolsover\UtilitiesForAlibre\UtilitiesForAlibre\bin\Release\Bevel\Images\BevelGearTemplate.AD_PRT"; DestDir: "{app}\Bevel\Images\"; Flags: ignoreversion
Source: "D:\Repository\Jetbrains\Bolsover\UtilitiesForAlibre\UtilitiesForAlibre\bin\Release\Bevel\Images\Symbols.png"; DestDir: "{app}\Bevel\Images\"; Flags: ignoreversion
Source: "D:\Repository\Jetbrains\Bolsover\UtilitiesForAlibre\UtilitiesForAlibre\bin\Release\Bevel\Views\BevelGearForm.resx"; DestDir: "{app}\Bevel\Views\"; Flags: ignoreversion
Source: "D:\Repository\Jetbrains\Bolsover\UtilitiesForAlibre\UtilitiesForAlibre\bin\Release\DataBrowser\DataBrowser.resx"; DestDir: "{app}\DataBrowser\"; Flags: ignoreversion
Source: "D:\Repository\Jetbrains\Bolsover\UtilitiesForAlibre\UtilitiesForAlibre\bin\Release\Icons\*.*";  DestDir: "{app}\Icons\"; Flags: ignoreversion
; NOTE: Don't use "Flags: ignoreversion" on any shared system files

[Icons]
Name: "{group}\{cm:UninstallProgram,{#MyAppName}}"; Filename: "{uninstallexe}"

[Registry]
Root: HKLM; Subkey: "SOFTWARE\Alibre Design Add-Ons"; Flags: uninsdeletekeyifempty; Check: IsAdminInstallMode
Root: HKLM; Subkey: "SOFTWARE\Alibre Design Add-Ons"; ValueType: string; ValueName: "{{305297BD-DE8D-4F36-86A4-AA5E69538A69}"; ValueData: "{autopf}\{#MyAppName}"; Check: IsAdminInstallMode
