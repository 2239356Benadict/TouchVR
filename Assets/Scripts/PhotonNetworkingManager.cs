using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;
using Photon.Realtime;
using TMPro;
using UnityEngine.SceneManagement;

public class PhotonNetworkingManager : MonoBehaviourPunCallbacks
{
    #region Create Room Fields
    [Header("Create Room")]

    public TextMeshProUGUI _createUserNameInput;
    public TextMeshProUGUI _createRoomName;

    #endregion

    #region Join Room Fields
    [Header("Join Room")]

    public TextMeshProUGUI _joinUserNameInput;
    public TextMeshProUGUI _joinRoomName;

    #endregion

    #region General Fields

    public static string userName;
    public byte MaxPlayers;

    //public RoomTypeSelection selectedType;


    [Space(20)]
    public TextMeshProUGUI feedBackText;
    public TextMeshProUGUI _myName;
    //[SerializeField]
    //private GameObject loadingBar;
    [SerializeField]
    private GameObject lobbyAllUI;
    private const string V = "Player Name";
    private const string W = "Room Name";
    #endregion

    #region Monobehaviour CallBacks

    private void Awake()
    {
        PhotonNetwork.AutomaticallySyncScene = true;
    }
    void Start()
    {
        DontDestroyOnLoad(this.gameObject);
        //loadingBar.SetActive(false);
        PhotonNetwork.GameVersion = "0.1";
        ConnectPUN();
    }


    #endregion

    #region Methods

    public void ConnectPUN()
    {
        if (PhotonNetwork.IsConnected)
        {
            //SetPlayerName(_userNameInput.text);
            //PhotonNetwork.JoinRoom(_roomName.text);
            Debug.Log("Already connnected....");
        }
        else
        {
            PhotonNetwork.ConnectUsingSettings();
            print("Connecting Using Settings");
            
        }

    }
    #endregion

    #region Override Methods
    public override void OnConnectedToMaster()
    {
        print("connected to master...");
        feedBackText.text = "IsConnected = " + PhotonNetwork.IsConnected.ToString();

    }
    //public override void OnDisconnected(DisconnectCause cause)
    //{
    //    base.OnDisconnected(cause);
    //    print("disconnected" + cause);
    //    feedBackText.text = "Disconnected = " + cause;
    //}
    //public override void OnJoinRandomFailed(short returnCode, string message)
    //{
    //    feedBackText.text = message;
    //    Debug.Log("Tried to join a room and failed");
    //    RoomOptions autoxr_roomOption = new RoomOptions()
    //    {
    //        MaxPlayers = this.MaxPlayers,
    //        PlayerTtl = -1,
    //        EmptyRoomTtl = 60000,  //should be less than PayerTtl for room persistence
    //        CleanupCacheOnLeave = false
    //    };


    //    PhotonNetwork.CreateRoom(_createRoomName.text, autoxr_roomOption);
    //    Debug.Log("Room AutoXR created");
    //    Debug.Log(PhotonNetwork.LocalPlayer.NickName);
    //}

    public override void OnLeftRoom()
    {
        //SceneManager.LoadScene(0);
    }
    #endregion


    #region Public Methods

    public void JoinFriendsRoom()
    {
        if (PhotonNetwork.IsConnected)
        {
            SetPlayerNameInPhoton(_createUserNameInput.text);

            PhotonNetwork.JoinRoom(_createRoomName.text);
            lobbyAllUI.SetActive(false);
            //loadingBar.SetActive(true);
            SceneManager.LoadScene(1);
            print("Name has entered");
        }
    }

    public void CreateMyRoom()
    {
        if (PhotonNetwork.IsConnected)
        {
            SetPlayerNameInPhoton(_createUserNameInput.text);

            RoomOptions xr_roomOption = new RoomOptions()
            {
                MaxPlayers = this.MaxPlayers,
                PlayerTtl = -1,
                EmptyRoomTtl = 60000,  //should be less than PayerTtl for room persistence
                CleanupCacheOnLeave = false
            };

            PhotonNetwork.CreateRoom(_createRoomName.text, xr_roomOption);
            Debug.Log("Room TouchVR created");
            Debug.Log(PhotonNetwork.LocalPlayer.NickName);

            lobbyAllUI.SetActive(false);
            //loadingBar.SetActive(true);
            SceneManager.LoadScene(1);
            print("Name has entered");
        }
    }

    public void SetPlayerNameInPhoton(string value)
    {
        if (string.IsNullOrEmpty(value))
        {
            Debug.Log("Player name is empty, please enter your name");
            return;
        }
        PhotonNetwork.LocalPlayer.NickName = value;
        print(PhotonNetwork.NickName);

        _myName.text = PhotonNetwork.NickName;
    }

    public void LeaveRoom()
    {
        if (photonView.IsMine)
        {
            PhotonNetwork.LeaveRoom();
        }
    }

    #endregion

    #region Keyboard Entry

    public void InputEntries()
    {
        //_createUserNameInput.text = selectedType._virtualKeyBoardInputValue;

        if (_createUserNameInput.text == V)
        {
            //_createUserNameInput.text = selectedType._virtualKeyBoardInputValue;
            print(_createUserNameInput.text);
        }
        else if (_createUserNameInput.text != null & _createRoomName.text == W)
        {
            //_createRoomName.text = selectedType._virtualKeyBoardInputValue;
        }
        print("Input entry clicked");
    }


    #endregion
}
