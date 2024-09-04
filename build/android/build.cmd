@echo off

::使用cli发布应用:https://learn.microsoft.com/en-us/dotnet/maui/android/deployment/publish-cli?view=net-maui-8.0

set KEYSTORE_PATH="%cd%\sample.keystore"
set PROJECT_PATH="%cd%\..\..\src\SharpDevTool\SharpDevTool.Mobile"
set SOURCE_PATH="%PROJECT_PATH%\bin\Release\net8.0-android\publish\*-Signed.apk"
set TARGET_PATH="%cd%\..\..\pakcages\SharpDevTool.apk"

if exist %TARGET_PATH% (
    del /F %TARGET_PATH%
)

dotnet publish -f net8.0-android -c Release -p:AndroidKeyStore=true -p:AndroidSigningKeyStore=%KEYSTORE_PATH% -p:AndroidSigningKeyAlias=sample -p:AndroidSigningKeyPass=12345678 -p:AndroidSigningStorePass=12345678 %PROJECT_PATH%

echo f | xcopy /f %SOURCE_PATH% %TARGET_PATH%