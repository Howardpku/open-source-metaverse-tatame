using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class OfflineManager : MonoBehaviour
{
    //初始UI
    public GameObject DebugUI;
    //选角色界面
    public GameObject charactorSelectUi;
    // Start is called before the first frame update
    void Start()
    {
        onGameStart();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void onGameStart()
    {
        charactorSelectUi.SetActive(true);
        DebugUI.SetActive(false);
    }

  //  Byte roolType = 1;
    String Playername = "";
    UInt32 modelID = 1;
   // UInt64 spaceKey = 1;

    //玩家名字
    public InputField playerNameFiled;
    public void CharacterReady()
    {
        Playername = playerNameFiled.text;
        if (Playername.Trim() != "")
        {
            charactorSelectUi.SetActive(false);
            EnterTheWorld();
        }
    }
    public void EnterTheWorld()
    {
        // Debug.Log(Playername + "           1111111             "  +spaceKey.ToString());
     
        SceneManager.LoadScene("Block");

        //enterByCreating(Playername, modelID);

    }


}
