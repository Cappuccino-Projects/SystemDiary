@echo off
dotnet build --configuration Release -p:Version=0.0.1.4 && echo Удачный билд!
pause