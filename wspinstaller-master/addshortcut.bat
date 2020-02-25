@echo off
set SCRIPT="%TEMP%\%RANDOM%-%RANDOM%-%RANDOM%-%RANDOM%.vbs"
echo Set oWS = WScript.CreateObject("WScript.Shell") >> %SCRIPT%
echo sLinkFile = "%USERPROFILE%\Desktop\%linktext%.lnk" >> %SCRIPT%
echo Set oLink = oWS.CreateShortcut(sLinkFile) >> %SCRIPT%
echo oLink.Arguments = %shortcutlink% >> %SCRIPT%
echo oLink.WindowStyle = 0 >> %SCRIPT%
echo oLink.TargetPath = "%PROGRAMFILES%\Internet Explorer\iexplore.exe" >> %SCRIPT%
echo oLink.Save >> %SCRIPT%

cscript /nologo %SCRIPT%

del %SCRIPT%

EXIT /b 0
