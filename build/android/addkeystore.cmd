@echo off

::下载openjdk:https://learn.microsoft.com/en-us/java/openjdk/download
::jdk位置:C:\Program Files (x86)\Android\openjdk\jdk-{version}-hotspot
::使用cli发布应用:https://learn.microsoft.com/en-us/dotnet/maui/android/deployment/publish-cli?view=net-maui-8.0

set PATH=%PATH%;C:\Program Files (x86)\Android\openjdk\jdk-17.0.8.101-hotspot\bin
set KEYSTORE_PATH="%cd%\sample.keystore"

if exist %KEYSTORE_PATH% (
    del /F %KEYSTORE_PATH%
)

keytool -genkeypair -v -keystore %KEYSTORE_PATH% -storepass 12345678 -alias sample -keyalg RSA -keysize 2048 -keypass 12345678 -dname CN=yibei333,O=development,OU=personal,L=beijing,ST=beijing,C=cn -validity 36000
::keytool -list -keystore ./sample.keystore