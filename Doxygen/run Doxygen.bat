@echo off
cd /d "%~dp0"

:: Remove previous version(if any)
rmdir /s /q "html"

:: Run Doxygen with REA-ALL config file
doxygen "Doxygen_Settings_REA_ALL"

echo Doxygen run completed. Press any key to exit.

pause
