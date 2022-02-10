using KBEngine;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class RoomAttributes : MonoBehaviour
{
    UInt64 sk;
    //private SPACE_REPORT spaceAtt;
    // Start is called before the first frame update
    void Start()
    {
       
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void setSpAttributes(UInt64 spaceKey, string spaceName, UInt32 spaceUType, Byte avatarCount, Byte maxPlayer)
    {
        sk= spaceKey;
        //spaceAtt.spaceName = spaceName;
        //spaceAtt.spaceUType = spaceUType;
        //spaceAtt.avatarCount = avatarCount;
        //spaceAtt.maxPlayer = maxPlayer;
        this.transform.GetChild(0).GetComponent<Text>().text = spaceName + "                                                            " + avatarCount + "/" + maxPlayer;
        if(avatarCount>= maxPlayer)
        {
            this.GetComponent<Button>().interactable = false;
        }
    }

    public void beingSelected()
    {
        GameManager.instance.setSPaceKey(sk);
        GameManager.instance.RoomListUI.SetActive(false);
    }
}
