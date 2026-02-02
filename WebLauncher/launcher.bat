@echo off
setlocal
cd /d "%~dp0"

:: ----------------------------------------------------------------------
:: AUTOMATED LAUNCHER
:: This script looks for any .exe file in the "Game" folder and runs it.
:: ----------------------------------------------------------------------

if not exist "Game" (
    echo [ERROR] 'Game' folder not found!
    echo Please create a folder named 'Game' inside WebLauncher and put your built game there.
    pause
    exit
)

cd Game
for %%f in (*.exe) do (
    echo Found Game: %%f
    start "" "%%f"
    exit
)

echo [ERROR] No game .exe found in the 'Game' folder!
echo Please build your Unity game and place the files here.
pause
exit
