@echo off

::发布:https://learn.microsoft.com/zh-cn/dotnet/core/tools/dotnet-publish

set PROJECT_PATH="%cd%\..\..\src\SharpDevTool\SharpDevTool.Desktop"
set SOURCE_PATH="%PROJECT_PATH%\bin\Release\net8.0-android\publish\*-Signed.apk"
set TARGET_PATH="%cd%\..\..\pakcages\SharpDevTool.exe"

dotnet publish %PROJECT_PATH% -a x64 -c Release --os win -p:WindowsPackageType=None --sc /p:PublishSingleFile=true