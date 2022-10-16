using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Photon.Voice.PUN;
using Photon.Pun;
using TMPro;

public class HighlightSpeaker : MonoBehaviourPunCallbacks
{
    [SerializeField]
    private Image speakerImage;
    [SerializeField]
    private Image micRecImage;
    [SerializeField]
    private Image micRecImageMute;
    [SerializeField]
    private PhotonVoiceView voiceView;
    [SerializeField]
    private TextMeshProUGUI speakingColor;
    

    public bool rec;

    private void Awake()
    {
        speakerImage.enabled = false;
        micRecImage.enabled = false;
        micRecImageMute.enabled = false;
    }

    private void Start()
    {
        //voiceView = GetComponent<PhotonVoiceView>();
        //voiceView.RecorderInUse.IsRecording = true;
        //if(voiceView.RecorderInUse != null)
        //{
        //    rec = voiceView.GetComponent<PhotonVoiceView>().RecorderInUse.IsRecording;
        //    Debug.Log("Recorder " + rec);
        //}
    }

    private void Update()
    {
        speakerImage.enabled = voiceView.IsSpeaking;
        micRecImage.enabled = voiceView.IsRecording;
        if (voiceView.IsSpeaking)
        {
            speakingColor.color = Color.green;
        }
        else
        {
            speakingColor.color = Color.white;
        }
        //Debug.Log("Is Speaking : " + voiceView.IsSpeaking);
        //Debug.Log("Is Recording : " + voiceView.IsRecording);

        if (photonView.IsMine)
        {
            if (Input.GetKeyDown(KeyCode.M))
            {
                MuteAndUnmute();
            }
        }
        else
        {
            //Debug.Log("Not my photon view");
        }
    }

    public void MuteAndUnmute()
    {
        if (voiceView.RecorderInUse != null)
        {
            if (voiceView.RecorderInUse.IsRecording == true)
            {
                voiceView.RecorderInUse.IsRecording = false;
                micRecImageMute.enabled = true;
                Debug.Log("You are on Mute");
            }
            else if (voiceView.RecorderInUse.IsRecording == false)
            {
                voiceView.RecorderInUse.IsRecording = true;
                micRecImageMute.enabled = false;
                Debug.Log("You are UnMuted");
            }
        }
        else
        {
            Debug.Log("Recorder Not Added");
        }
    }

    //public void MuteUnmute()
    //{
    //    if (rec == true)
    //    {
    //        rec = false;
    //        micRecImageMute.enabled = true;
    //        Debug.Log("You are on Mute");
    //    }
    //    else if (rec == false)
    //    {
    //        rec = true;
    //        micRecImageMute.enabled = false;
    //        Debug.Log("You are on UnMuted");
    //    }
    //}
}
