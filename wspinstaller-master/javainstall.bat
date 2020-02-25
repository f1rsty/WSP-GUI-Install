@echo off && cls
title Java Installer
set JAVA_ARGUMENTS=/s INSTALL_SILENT=1 STATIC=0 AUTO_UPDATE=0 WEB_JAVA=1 WEB_JAVA_SECURITY_LEVEL=M WEB_ANALYTICS=0 EULA=0 REBOOT=0
echo Please wait, Installing Java
"%cd%\%executable%" %JAVA_ARGUMENTS%
echo.
EXIT /B 0
