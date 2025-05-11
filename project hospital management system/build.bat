@echo off
echo Building project...
csc /target:library /out:bin\project_hospital_management_system.dll /recurse:*.cs
echo Build completed.
