using System.Collections;
using System.Collections.Generic;
using UnityEngine;
 
public class ShowFPSMobile : MonoBehaviour
{
    // provided by Niter88
    private string fps = "";
 
    private WaitForSecondsRealtime waitForFrequency;
 
    GUIStyle style = new GUIStyle();
    Rect rect;
 
    bool isInicialized = false;
 
 
    private void Awake()
    {
        //float fraction = 0.5f; // Render at half the resolution of current screen
        //float fraction = 0.8f;
        //float fraction = 1f;
        //Screen.SetResolution((int)(Screen.currentResolution.width * fraction), (int)(Screen.currentResolution.height * fraction), true);
 
        //don't use vsync on mobile, limit fps instead
 
        // Sync framerate to monitors refresh rate
        //Use 'Don't Sync' (0) to not wait for VSync. Value must be 0, 1, 2, 3, or 4
        QualitySettings.vSyncCount = 0;
 
        // Disable screen dimming
        Screen.sleepTimeout = SleepTimeout.NeverSleep;
 
        //Inicialize(true); //use for testing on editor
    }
 
    private IEnumerator FPS()
    {
        int lastFrameCount;
        float lastTime;
        float timeSpan;
        int frameCount;
        for (; ; )
        {
            // Capture frame-per-second
            lastFrameCount = Time.frameCount;
            lastTime = Time.realtimeSinceStartup;
            yield return waitForFrequency;
            timeSpan = Time.realtimeSinceStartup - lastTime;
            frameCount = Time.frameCount - lastFrameCount;
 
            fps = string.Format("FPS: {0}", Mathf.RoundToInt(frameCount / timeSpan));
        }
    }
 
 
    void OnGUI()
    {
        // Display
        GUI.Label(rect, fps, style);
        //GUI.Label(new Rect(Screen.width - 110, 5, 0, Screen.height * 2 / 100), fps, style);
 
        //GUI.Label(new Rect(10, 10, Screen.width, Screen.height * 2 / 100), fps, style);
        //GUI.Label(new Rect(Screen.width - 100, 10, 150, 20), fps, style);
    }
 
    private void Inicialize(bool showFps)
    {
        isInicialized = true;
 
        style.alignment = TextAnchor.UpperLeft;
        style.fontSize = Screen.height * 3 / 100;
        style.normal.textColor = new Color32(0, 200, 0, 255);
        rect = new Rect(Screen.width * 90 / 100, 5, 0, Screen.height * 2 / 100);
 
        if(showFps)
            StartCoroutine(FPS());
    }
 
 
    public void SetNewConfig(GraphicSettingsMB gSettings)
    {
        Application.targetFrameRate = gSettings.targetFrameRate;
 
        waitForFrequency = new WaitForSecondsRealtime(gSettings.testFpsFrequency);
 
        if (!isInicialized) Inicialize(gSettings.showFps);
 
        if (!gSettings.showFps)
            Destroy(this.gameObject);
    }
}
 
[SerializeField]
public class GraphicSettingsMB
{
    public byte targetFrameRate = 30;
    public byte testFpsFrequency = 1;
    public bool showFps = false;
}
