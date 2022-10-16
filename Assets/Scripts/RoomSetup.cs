using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Realtime;
using Photon;
using Photon.Pun;


public class RoomSetup : IMatchmakingCallbacks
{
    [SerializeField]
    private byte maxPlayers = 4;
    private LoadBalancingClient loadBalancingClient;

    private void CreateRoom()
    {
        RoomOptions roomOptions = new RoomOptions();
        roomOptions.MaxPlayers = maxPlayers;
        EnterRoomParams enterRoomParams = new EnterRoomParams();
        enterRoomParams.RoomOptions = roomOptions;
        loadBalancingClient.OpCreateRoom(enterRoomParams);
    }

    private void QuickMatch()
    {
        loadBalancingClient.OpJoinRandomRoom();
    }

    #region IMatchmakingCallbacks

    void IMatchmakingCallbacks.OnCreatedRoom()
    {

    }

    void IMatchmakingCallbacks.OnCreateRoomFailed(short returnCode, string message)
    {
        
    }

    void IMatchmakingCallbacks.OnFriendListUpdate(List<FriendInfo> friendList)
    {
        Debug.Log("Friends In Room " + friendList);
    }

    void IMatchmakingCallbacks.OnJoinedRoom()
    {
        Debug.Log("Joined Room Successfully");
    }

    void IMatchmakingCallbacks.OnJoinRandomFailed(short returnCode, string message)
    {
        CreateRoom();
    }

    void IMatchmakingCallbacks.OnJoinRoomFailed(short returnCode, string message)
    {
        Debug.Log("Failed Joining Room ");
    }

    void IMatchmakingCallbacks.OnLeftRoom()
    {

    }
    #endregion
}
