using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RandomisationScript : MonoBehaviour
{
    public GameObject playerHeadModel, playerLeftHandModel, playerRightHandModel;

    void Start()

    {

        var randomAvatarColour = Random.ColorHSV(0f, 1f, 1f, 1f, 0.5f, 1f);

        playerHeadModel.GetComponent<Renderer>().material.color = randomAvatarColour;

        playerLeftHandModel.GetComponent<Renderer>().material.color = randomAvatarColour;

        playerRightHandModel.GetComponent<Renderer>().material.color = randomAvatarColour;

    }
}
