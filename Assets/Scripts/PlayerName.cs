using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;
using Photon.Realtime;
using TMPro;

public class PlayerName : MonoBehaviour
{
 
    void Start()
    {
        this.GetComponent<TextMeshProUGUI>().text = PhotonNetwork.NickName;
    }


}
