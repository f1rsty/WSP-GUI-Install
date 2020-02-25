set TEAMNOTES_ARGUMENTS=/quiet
title Team Notes Installer
@echo off && cls
echo Please wait, Installing Team Notes

if exist %PROGRAMFILES(x86)%\Paragon (
    echo Team Notes installed successfully
	EXIT /B 0
) else (
    "%cd%\TeamNotesFormEditorLibrary.msi" %TEAMNOTES_ARGUMENTS%
)

EXIT /B 0
