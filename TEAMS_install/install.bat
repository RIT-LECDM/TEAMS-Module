@echo off
cd ../TEAMSModule/Plugin/TEAMSPlugin/bin/Debug/
xcopy /s TEAMS.dll %HOMEPATH%
cd %HOMEPATH%
for /f %%a in ('dir /b /s greet.exe') do copy TEAMS.dll %%~dpa
cd %~dp0
cd ../TEAMSModule/Plugin/TEAMSPlugin/bin/Debug/
xcopy /s EPPlus.dll %HOMEPATH%
cd %HOMEPATH%
for /f %%a in ('dir /b /s greet.exe') do copy EPPlus.dll %%~dpa
echo.
echo.
echo.
echo Installation of TEAMS completed successfully.
pause