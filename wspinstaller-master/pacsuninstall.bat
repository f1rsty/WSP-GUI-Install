@echo off && cls
title PACS Uninstaller

if exist %ProgramFiles%\AMICAS (
	echo found older viewer in %ProgramFiles%\AMICAS
    del %ProgramFiles%\AMICAS /f /q
) else (
    echo nothing found in %ProgramFiles%\AMICAS
)

if exist %UserProfile%\AppData\LocalLow\AMICAS (
	echo found older viewer in %UserProfile%\AppData\LocalLow\AMICAS
    del %UserProfile%\AppData\LocalLow\AMICAS /f /q
) else (
    echo nothing found in %UserProfile%\AppData\LocalLow\AMICAS
)

if exist %AppData%\AMICAS (
	echo found older viewer in %AppData%\AMICAS
    del %AppData%\AMICAS /f /q
) else (
    echo nothing found in %AppData%\AMICAS
)
EXIT /b 0
