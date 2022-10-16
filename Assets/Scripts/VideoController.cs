using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Video;

public class VideoController : MonoBehaviour
{
    public VideoClip[] clipsToPlay;
    private VideoPlayer videoPlayerToPlay;
    private int videoClipIndex;
    public GameObject _nextButton;
    public GameObject _previousButton;


    
    void Start()
    {
        videoPlayerToPlay = gameObject.GetComponent<VideoPlayer>();

        videoPlayerToPlay.clip = clipsToPlay[0];
    }

    public void PlayNextVideo()
    {
        videoClipIndex++;

        if (videoClipIndex >= clipsToPlay.Length)
        {
            videoClipIndex = videoClipIndex % clipsToPlay.Length;
        }
        videoPlayerToPlay.clip = clipsToPlay[videoClipIndex];
        videoPlayerToPlay.Pause();
        videoPlayerToPlay.Play();

        if (videoClipIndex <= clipsToPlay.Length)
        {
            _nextButton.active = true;
            _previousButton.active = true;
        }
        if (videoClipIndex == clipsToPlay.Length -1)
        {
            _nextButton.active = false;
            
        }
    }

    public void PlayPreviousVideo()
    {
        

        videoClipIndex--;
        if (videoClipIndex > clipsToPlay.Length)
        {
            videoClipIndex = videoClipIndex % clipsToPlay.Length;
        }
        videoPlayerToPlay.clip = clipsToPlay[videoClipIndex];
        videoPlayerToPlay.Pause();
        videoPlayerToPlay.Play();

        if (videoClipIndex == 0)
        {
            _nextButton.active = true;
            _previousButton.active = false;
        }
        if (videoClipIndex < clipsToPlay.Length)
        {
            _nextButton.active = true;
        }
        Debug.Log(videoClipIndex);
    }


}
