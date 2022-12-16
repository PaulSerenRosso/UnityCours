using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;
using UnityEngine.Rendering;
using UnityEngine.UI;

public class ScreenShotManager : MonoBehaviour
{
    [SerializeField] private KeyCode screenshotKey = KeyCode.Space;

    [SerializeField] private string path;

    private GameObject uiGO;
    private bool takeScreenshot = false;

    private void Update()
    {
        if (Input.GetKeyDown(screenshotKey))
        {
            TakeScreenshot();
        }
    }

    void RenderPipelineManagerEndCameraRendering(ScriptableRenderContext _scriptableRenderContext, Camera arg2)
    {
        if (takeScreenshot)
        {
            takeScreenshot = false;
            int width = arg2.pixelWidth;
            int height = arg2.pixelHeight;
            Texture2D screenshotTexture = new Texture2D(width, height, TextureFormat.ARGB32, false);
            Rect rect = new Rect(0, 0, width, height);
            screenshotTexture.ReadPixels(rect, 0, 0);
            screenshotTexture.Apply();
            Byte[] bytes = screenshotTexture.EncodeToPNG();
            if (!Directory.Exists(path))
            {
                Directory.CreateDirectory(path);
            }

            File.WriteAllBytes(
                path + "/ScreenShot " + width + "-" + height + " " +DateTime.Now.ToString("dd-MM-yyyy_HH-mm-ss") + " " +
                                                                   Directory.GetFiles(path).Length+".png", bytes);
        }
    }

    void TakeScreenshot()
    {
        path = Application.dataPath + "/Screenshots";
        takeScreenshot = true;
        
    }

    private void OnEnable()
    {
        RenderPipelineManager.endCameraRendering += RenderPipelineManagerEndCameraRendering;
    }

    private void OnDisable()
    {
        RenderPipelineManager.endCameraRendering -= RenderPipelineManagerEndCameraRendering;
    }
}