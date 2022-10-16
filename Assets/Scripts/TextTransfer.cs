using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using VRKeys;

public class TextTransfer : MonoBehaviour
{
    public TextMeshProUGUI nameOfPlayer;
    public TextMeshProUGUI nameOfRoom;
    private const string V = "Player Name";
    private const string W = "Room Name";
    public static string userName;
    // Start is called before the first frame update
    void Start()
    {
        userName = this.gameObject.GetComponent<Keyboard>().displayText.text;
    }
    public void InputEntries()
    {
        //_createUserNameInput.text = selectedType._virtualKeyBoardInputValue;

        if (nameOfPlayer.text == V)
        {
            nameOfPlayer.text = userName;
            //_createUserNameInput.text = selectedType._virtualKeyBoardInputValue;
            print(nameOfPlayer.text);
            
        }
        else if (nameOfPlayer.text != null & nameOfRoom.text == W)
        {
            nameOfRoom.text = userName;
            //_createRoomName.text = selectedType._virtualKeyBoardInputValue;
        }
        print("Input entry clicked");
    }
    // Update is called once per frame
    void Update()
    {
        
    }
}
