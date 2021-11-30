using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CreditsScript : MonoBehaviour
{
    void Start()
    {

        GameObject camera = GameObject.Find("Main Camera");

        var videoPlayer = camera.AddComponent<UnityEngine.Video.VideoPlayer>();

        videoPlayer.playOnAwake = false;

        videoPlayer.renderMode = UnityEngine.Video.VideoRenderMode.CameraNearPlane;

        videoPlayer.targetCameraAlpha = 0.5F;

        videoPlayer.url = "Assets/Video/Napisy_koncowe0000-0630.mp4";

        videoPlayer.frame = 100;

        videoPlayer.isLooping = false;

        videoPlayer.loopPointReached += EndReached;

        videoPlayer.Play();
    }

    void EndReached(UnityEngine.Video.VideoPlayer vp)
    {
        vp.Stop();
        Debug.Log("Quittig");
        Application.Quit();
    }
}
