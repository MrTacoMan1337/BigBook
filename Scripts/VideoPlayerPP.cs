using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Video;

public class VideoPlayerPP : MonoBehaviour
{
    
    private bool play;

    public VideoPlayer videoPlay; //the gameobject with the video player
    public string videoClipName; //in insperctor write the name of the file (name.mp4)

    private string url;


    //In order for the video to work for WebGL Build. Video must be mp4 with H.264 encoded. It must also be plased in a folder under assets called "StreamingAssets" (Case sensitive)
    private void Awake()
    {
        url = System.IO.Path.Combine(Application.streamingAssetsPath, videoClipName); //sets url path
        videoPlay.url = url;
    }
    
    public void PlayPause() //play or pause the video, this functions runs when pressing a play/pause button in the UI that I created
    {
        play = gameObject.GetComponent<Toggle>().isOn;
        if (play)
        {
            videoPlay.Play();
        }
        else
        {
            videoPlay.Pause();
        }
    }
}
