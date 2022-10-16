using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NormcoreAvatarScript : MonoBehaviour
{
    //public GameObject playerAvatar;
    public GameObject normcoreAvatar;
    public GameObject xrRig;


    // Start is called before the first frame update
    void Start()
    {
        xrRig = GameObject.FindGameObjectWithTag("Player");

        //playerAvatar.GetComponent<Renderer>().material.color = Random.ColorHSV(0f, 1f, 1f, 1f, 0.5f, 1f);
    }

    // Update is called once per frame
    void Update()
    {
        normcoreAvatar.transform.position = xrRig.transform.position;
        normcoreAvatar.transform.rotation = xrRig.transform.rotation;
    }
}
