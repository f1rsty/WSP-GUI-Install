@echo off
SETLOCAL
set SCRIPT_VERSION=0.0.1
set SCRIPT_UPDATED=08-08-2019
title WSP Installer v%SCRIPT_VERSION% (%SCRIPT_UPDATED%)

cls

ECHO.
ECHO =============================
ECHO Please enter a site location.
ECHO =============================
ECHO.
echo 1. McLaren Flint
echo 2. McLaren Lapeer
echo 3. McLaren Bay
echo 4. McLaren Macomb
echo 5. McLaren Oakland
echo 6. McLaren Central
echo Q. Back to options menu
ECHO.
SET /P M=Enter your selection: 
IF %M%==1 set jregistry=java745.reg && set executable=java745.exe && set shortcutlink="https://mrmc-wsp.mclaren.org/WSP/Login.aspx" && set linktext=McLaren WSP Flint
IF %M%==2 set jregistry=java631.reg && set executable=java631.exe && set shortcutlink="https://lrmc-wsp.mclaren.org/WSP/Login.aspx" && set linktext=McLaren WSP Lapeer
IF %M%==3 set jregistry=java745.reg && set executable=java745.exe && set shortcutlink="https://bay-wsp.mclaren.org/WSP/Login.aspx" && set linktext=McLaren WSP Bay
IF %M%==4 set jregistry=java631.reg && set executable=java631.exe && set shortcutlink="https://mcrmc-wsp.mclaren.org/WSP/Login.aspx" && set linktext=McLaren WSP Macomb
IF %M%==5 set jregistry=java631.reg && set executable=java631.exe && set shortcutlink="https://poh-wsp.mclaren.org/WSP/Login.aspx" && set linktext=McLaren WSP Oakland
IF %M%==6 set jregistry=java745.reg && set executable=java745.exe && set shortcutlink="https://cmi-wsp.mclaren.org/WSP/Login.aspx" && set linktext=McLaren WSP Central
IF %M%==Q GOTO EOF

call javauninstall.bat
call dotnetenable.bat
call pacsuninstall.bat
call javainstall.bat
call physdocinstall.bat
call explorerregistry.bat
call javaregistry.bat
call addshortcut.bat
