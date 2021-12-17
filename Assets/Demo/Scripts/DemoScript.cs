using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityAndroidOpenUrl;
using UnityEngine;

public class DemoScript : MonoBehaviour
{
    private const string MAIN_DIR = "/storage/emulated/0";
    private const string directoryName = "Download";
    private const string fileName = "template.pdf";

    private void Start()
    {
        string directoryPath = Path.Combine(MAIN_DIR, directoryName);
        if (!Directory.Exists(directoryPath))
            Directory.CreateDirectory(directoryPath);

        StartCoroutine(SaveToDownloads(directoryPath,fileName));
    }

    private IEnumerator SaveToDownloads(string directoryPath, string fileName)
    {
        string localFilePath = Path.Combine(Application.streamingAssetsPath, fileName);
        WWW www = new WWW(localFilePath);
        yield return www;
        if (!string.IsNullOrEmpty(www.error))
        {
            Debug.LogError("Error while loading file template : " + www.error);
            yield break;
        }
        string filePath = Path.Combine(directoryPath, fileName);
        File.WriteAllBytes(filePath, www.bytes);
        OpenFile(filePath, "application/pdf");
    }

    private void OpenFile(string filePath, string type) {
        AndroidOpenUrl.OpenFile(filePath, type);
    }
}
