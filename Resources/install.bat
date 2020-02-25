@echo off
SETLOCAL
set SCRIPT_VERSION=0.0.6
set SCRIPT_UPDATED=2-17-2020
title WSP Installer v%SCRIPT_VERSION% (%SCRIPT_UPDATED%)

cls

call :DOTNET
EXIT /B 0

:DOTNET
@echo off && cls
title Dotnet Checker
echo.
echo Checking if the required dotnet package is installed for Physician Documentation
echo.
dism /online /get-features /format:table | find /i "NetFx3" | find /v "Microsoft" | find "Enabled" >nul
if %ERRORLEVEL% == 1 (
	dism /online /Enable-Feature /FeatureName:NetFx3 /NoRestart
) else (
	echo NetFx3 is already enabled.
)
echo.
EXIT /B 0