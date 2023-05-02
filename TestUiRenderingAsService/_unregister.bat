@call "%ProgramFiles(x86)%\Microsoft Visual Studio\2019\Professional\VC\Auxiliary\Build\vcvars32.bat"

rem run as administrator!
installutil.exe /u %~dp0bin\Debug\TestUiRenderingAsService.exe

pause