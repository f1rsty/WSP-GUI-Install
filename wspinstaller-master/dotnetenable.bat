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
