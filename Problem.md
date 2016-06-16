<<<<<<< HEAD
#YCMap created by YinChao

##错误集锦
###ArcGIS.Version.dll找不到指定模块
1. 错误原因：
ArcGIS.Version.dll依托x86平台而非其他平台，如ANY CPU
2.解决方法：
将程序的目标平台由Any CPU或X64改为x86；

###找不到许可文件
1. 错误原因：
没有绑定许可
2. 解决方法：
打开program.cs，在窗体被调用之前调用
```c#
ESRI.ArcGIS.RuntimeManager.Bind(ESRI.ArcGIS.ProductCode.EngineOrDesktop);
Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new FrmMain());
```
=======
# YCMap
a teaching map demo using ArcGIS Engine and C#



