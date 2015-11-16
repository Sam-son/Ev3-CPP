;--------------------------------
;Include Modern UI

  !include "MUI2.nsh"

;--------------------------------
;General

  ;Name and file
  Name "Ev3DL"
  OutFile "Install.exe"

  ;Default installation folder
  InstallDir "$PROGRAMFILES\Ev3DL"
  
  ;Get installation folder from registry if available
  InstallDirRegKey HKCU "Software\Ev3DL" ""

  ;Request application privileges for Windows Vista
  RequestExecutionLevel admin

;--------------------------------
;Interface Settings

  !define MUI_ABORTWARNING

;--------------------------------
;Pages

  !insertmacro MUI_PAGE_DIRECTORY
  !insertmacro MUI_PAGE_INSTFILES
  
  !insertmacro MUI_UNPAGE_CONFIRM
  !insertmacro MUI_UNPAGE_INSTFILES
  
;--------------------------------
;Languages
 
  !insertmacro MUI_LANGUAGE "English"

;--------------------------------
;Installer Sections

Section "Section" Sec

  SetOutPath "$INSTDIR"
  ;ADD YOUR OWN FILES HERE...
  File Ev3DL.exe
  File Lego.Ev3.Desktop.dll
  File Lego.Ev3.Desktop.XML
  File icon.ico
  File /r "lmsapi"
  ;Add Start Menu Shortcut
  createDirectory "$SMPROGRAMS\Ev3DL"
  createShortCut "$SMPROGRAMS\Ev3DL\Ev3DL.lnk" "$INSTDIR\Ev3DL.exe" "" "$INSTDIR\icon.ico"
  ;Store installation folder
  WriteRegStr HKCU "Software\Ev3DL" "" $INSTDIR
  
  ;Create uninstaller
  WriteUninstaller "$INSTDIR\Uninstall.exe"
  ;Create unistaller entry in install table
  WriteRegStr HKLM "Software\Microsoft\Windows\CurrentVersion\Uninstall\Ev3DL" \
	"DisplayName" "Ev3DL"
  WriteRegStr HKLM "Software\Microsoft\Windows\CurrentVersion\Uninstall\Ev3DL" \
    "UninstallString" "$\"$INSTDIR\Uninstall.exe$\""
SectionEnd

;--------------------------------
;Descriptions

  ;Language strings
;  LangString DESC_SecDummy ${LANG_ENGLISH} "A test section."

  ;Assign language strings to sections
;  !insertmacro MUI_FUNCTION_DESCRIPTION_BEGIN
;    !insertmacro MUI_DESCRIPTION_TEXT ${SecDummy} $(DESC_SecDummy)
;  !insertmacro MUI_FUNCTION_DESCRIPTION_END

;--------------------------------
;Uninstaller Section

Section "Uninstall"

  ;ADD YOUR OWN FILES HERE...

  Delete "$INSTDIR\Uninstall.exe"
  Delete "$INSTDIR\Ev3DL.exe"
  Delete "$INSTDIR\Lego.Ev3.Desktop.dll"
  Delete "$INSTDIR\Lego.Ev3.Desktop.XML"
  Delete "$INSTDIR\icon.ico"
  RMDir /r "$SMPROGRAMS\Ev3DL"
  RMDir /r "$INSTDIR\lmsapi"
  RMDir "$INSTDIR"
  DeleteRegKey /ifempty HKCU "Software\Ev3DL"
  DeleteRegKey HKLM "Software\Microsoft\Windows\CurrentVersion\Uninstall\Ev3DL"
SectionEnd