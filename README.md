# Unity-Android-Files-Opener
 Unity Android Files Opener allows your android application to open files on local drive with (**including API Level 24 or higher**).
 If you encounter a problem on Android `Application.OpenUrl` does not work, then this will solve your problem!

## Requirements
 Unity Editor 2017 or newer

## Installation
 * Add Assets files to your Assets in Unity project.
 * If you are building for API level 28 or above you have to enable Custom Main Manifest, Custom Launcher Manifest file from Player Settings --> Publishing Settings --> Build  
 * Add the following permission and set `android:requestLegacyExternalStorage="true"` for application  `<application android:requestLegacyExternalStorage="true">`

```
    <uses-permission android:name="android.permission.READ_EXTERNAL_STORAGE" />
    <uses-permission android:name="android.permission.WRITE_EXTERNAL_STORAGE" />
```

## Usage
The following example demonstrates how to open a file:
```csharp
public void Example()
{   
    string dataType = "application/pdf";
    string documentUrl = "/storage/emulated/0/Downloads/template.pdf";
    AndroidOpenUrl.OpenUrl(documentUrl, dataType); // you can specify any MIME type when opening a file by explicitly specifying the dataType parameter
}
```
The demo project access "Downloads" folder in `/storage/emulated/0` and you need to allow external write permission. Open `Player Settings` in your project and change `Write Permission` to `External(SDCard)`.

## Demo

<img src="Demo/demo.gif" width="345px" height="620px" />

## Known Editor errors:
 * **Plugins folder not found**:
   The Editor Script `PackageNameChanger.cs` cannot find the Plugins folder in the root of the Assets folder.
   This error message can occur as a result of moving the Plugins folder to some other place that is different from the root of the Assets folder.
   To solve the problem, just re-import the asset.
 * **File release.aar not found**:
   The Editor Script `PackageNameChanger.cs`cannot find the release.aar archive in the Plugins folder. This error may occur if you deleted, moved or renamed the release.aar file.
   To solve the problem, just re-import the asset.
 * **System.IO.FileNotFoundException: Could not find file**:
   While you changed the package name in the project, Editor Script `PackageNameChanger.cs` should change it in the Plugins/release.aar files, but this did not happen because the file named release.aar no longer exists in the Plugins/release.arr folder. 
   To solve this problem, re-import the asset.
 * **Temp folder not found**.
   Editor Script `PackageNameChanger.cs` during the process of renaming the package name creates a Temp folder in the Plugins folder. After the renaming process is complete, `PackageNameChanger.cs` will delete this folder itself. This error may occur if you were able to remove it manually. 
   To solve this problem, restart the project.

## Notes
 * If you need External access to files, then you need to set `Write Permission` to `Extarnal(SDCard)` in `Player Settings` of your project.
 * The example project was built using Unity 2019.4.17f1
 * A minimum API level of 25 and target API level of 30 was used during testing.
 * If your project needs to make any changes to your `AndroidManifest.xml`, then consider that the Editor Script `PackageNameChanger.cs` monitors the changes in the Package Name of your project and makes these changes in Plugins/realese.aar/AndroidManifest.xml and Plugins/realese.aar/res/xml/filepaths.xml files
 * For the health of the asset, the Editor Script `PackageNameChanger.cs` located in the Editor folder is important. 
   ***Delete it only if you are not going to change the package name in the project anymore !!!***
