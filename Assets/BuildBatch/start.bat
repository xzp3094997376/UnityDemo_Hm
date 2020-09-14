echo "build start"
H:\unity2019\Unity\Editor\Unity.exe -batchmode  -projectPath H:\unityProjects\CmdArgsTest -executeMethod TestBuild.BuildGame 
Pause
taskkill /f /im Unity.exe
echo "打包完成"