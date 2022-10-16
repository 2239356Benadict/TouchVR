using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;
using Photon.Realtime;
using ExitGames.Client.Photon;

public class SpawnManager : MonoBehaviourPunCallbacks
{
    public GameObject playerPrefabs;
    public Transform[] spawnPositions;


    public enum RaiseEventCodes
    {
        PlayerSpawnEventCode = 0
    }

    private void Start()
    {
        PhotonNetwork.NetworkingClient.EventReceived += OnEvent;
    }

    private void OnDestroy()
    {
        PhotonNetwork.NetworkingClient.EventReceived -= OnEvent;
    }

    #region Photon Callbacks Methods

    void OnEvent(EventData photonEvent)
    {
        if(photonEvent.Code == (byte)RaiseEventCodes.PlayerSpawnEventCode)
        {
            object[] data = (object[])photonEvent.CustomData;
            Vector3 receivedPosition = (Vector3)data[0];
            Quaternion receivedRotation = (Quaternion)data[1];
            int receivedPlayerSelectionData = (int)data[3];

            GameObject player = Instantiate(playerPrefabs, receivedPosition, receivedRotation);
            PhotonView _photonView = player.GetComponent<PhotonView>();
            _photonView.ViewID = (int)data[2];
        }
    }

    public override void OnJoinedRoom()
    {
        if (PhotonNetwork.IsConnectedAndReady)
        {
            SpawnPlayer();
        }
    }

    #endregion

    #region privateMathods

    private void SpawnPlayer()
    {
        
            int randomSpawnPoint = Random.Range(0, spawnPositions.Length - 1);
            Vector3 instantitePosition = spawnPositions[randomSpawnPoint].position;

            PhotonNetwork.Instantiate(playerPrefabs.name, instantitePosition, Quaternion.identity);
        
    }

    #endregion
}
