using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;
using Photon.Realtime;
using TMPro;
using UnityEngine.UI;


public class PhotonLogin : MonoBehaviourPunCallbacks
{

    [Header("UI")]
    public TextMeshProUGUI uI_InformText;
    public TMP_InputField uI_PlayerName;
    public TextMeshProUGUI placeholder;

    [Header("Version & Players")]
    public float Version;
    public byte MaxPlayers;

    public string roomName;

    private void Awake()
    {
        PhotonNetwork.AutomaticallySyncScene = true;
    }
    void Start()
    {
        Connect();
        Debug.Log("start");
    }
    public void Connect()
    {
        PhotonNetwork.ConnectUsingSettings();
        PhotonNetwork.GameVersion = Version.ToString();
    }
    public void Play()
    {
     
        //PhotonNetwork.JoinRandomRoom();
        string playername = uI_PlayerName.text;
        PhotonNetwork.LocalPlayer.NickName = playername;
        PhotonNetwork.JoinRandomRoom();
    }
    public override void OnJoinRandomFailed(short returnCode, string message)
    {
        uI_InformText.text = message;
        Debug.Log("Tried to join a room and failed");
        RoomOptions autoxr_roomOption = new RoomOptions()
        {
            MaxPlayers = this.MaxPlayers,
            PlayerTtl = -1,
            EmptyRoomTtl = 60000,  //should be less than PayerTtl for room persistence
            CleanupCacheOnLeave = false
        };

        
        PhotonNetwork.CreateRoom(roomName, autoxr_roomOption);
        Debug.Log("Room AutoXR created");
        Debug.Log(PhotonNetwork.LocalPlayer.NickName);
    }

    //bool cleanup = PhotonNetwork.CurrentRoom.AutoCleanUp;
    public override void OnJoinedRoom()
    {
        Debug.Log("Joined a room - yay!");

        uI_InformText.text = "Entering to " + PhotonNetwork.CurrentRoom.Name;
        Debug.Log(uI_InformText.text);
        
        

        if (PhotonNetwork.IsMasterClient)
        {
            //cleanup = false;
            Debug.Log(PhotonNetwork.CurrentRoom.AutoCleanUp); //is false

            PhotonNetwork.LoadLevel(1);
            uI_InformText.text = PhotonNetwork.LocalPlayer.NickName + " is masterclient ? " + PhotonNetwork.IsMasterClient;
            //Debug.Log("CLEANUP: " + cleanup);           
        }
        else
        {
            uI_InformText.text = "Is masterclient ? " + PhotonNetwork.IsMasterClient;
        }
    }

    #region Private Methods

    public void Update()
    {
        if (Input.GetKeyDown(KeyCode.KeypadEnter))
        {
            Play();
            
        }
    }
    

    #endregion
}
