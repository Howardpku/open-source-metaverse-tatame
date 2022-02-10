using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using KBEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    public static GameManager instance;
    public static string deviceUniqueIdentifier;

    bool startRelogin = false;

    //账号密码
    private string stringAccount = "";
    private string stringPasswd = "";

    //初始UI
    public GameObject DebugUI;
    //服务器列表 UI
    public GameObject RoomListUI;
    public GameObject RoomListPerfab;
    public GameObject RoomListParent;

    //选角色界面
    public GameObject charactorSelectUi;


    private void Awake()
    {
        instance = this;
        //获取设备ID
       // deviceUniqueIdentifier = UnityEngine.Random.Range(0,500).ToString();
        deviceUniqueIdentifier = SystemInfo.deviceUniqueIdentifier;
        stringAccount = deviceUniqueIdentifier;
        stringPasswd = "TATAME666";

    }
    // Start is called before the first frame update
    void Start()
    {
        installEvents();


        //SceneManager.LoadScene("login");
    }

    // Update is called once per frame
    void Update()
    {

    }


    void installEvents()
    {
        // common
        KBEngine.Event.registerOut("onKicked", this, "onKicked");
        KBEngine.Event.registerOut("onDisconnected", this, "onDisconnected");
        KBEngine.Event.registerOut("onConnectionState", this, "onConnectionState");


        // login
        KBEngine.Event.registerOut("onCreateAccountResult", this, "onCreateAccountResult");
        KBEngine.Event.registerOut("onLoginFailed", this, "onLoginFailed");
        KBEngine.Event.registerOut("onLoginBaseappFailed", this, "onLoginBaseappFailed");
        KBEngine.Event.registerOut("onLoginSuccessfully", this, "onLoginSuccessfully");
        KBEngine.Event.registerOut("onReloginBaseappFailed", this, "onReloginBaseappFailed");
        KBEngine.Event.registerOut("onReloginBaseappSuccessfully", this, "onReloginBaseappSuccessfully");
        KBEngine.Event.registerOut("onLoginBaseapp", this, "onLoginBaseapp");

        // select-avatars(register by scripts)
        KBEngine.Event.registerOut("onCreateAvatarResult", this, "onCreateAvatarResult");


        //获取服务器列表
        KBEngine.Event.registerOut("onReqSpaceReport", this, "onReqSpaceReport");

    }

    public void registerSpawnPoint(Vector3 vector3)
    {
        KBEngine.Event.fireIn("registerSpawnPoint", this, vector3);
    }


    //被踢掉
    public void onKicked(UInt16 failedcode)
    {
        err("kick, disconnect!, reason=" + KBEngineApp.app.serverErr(failedcode));
        SceneManager.LoadScene("login");
    }

    //掉线
    public void onDisconnected()
    {
        err("disconnect! will try to reconnect...(你已掉线，尝试重连中!)");
        startRelogin = true;
        Invoke("onReloginBaseappTimer", 1.0f);
        Application.Quit();
    }

    public void onReloginBaseappTimer()
    {
        KBEngineApp.app.reloginBaseapp();

        if (startRelogin)
            Invoke("onReloginBaseappTimer", 3.0f);
    }

    public void onConnectionState(bool success)
    {
        if (!success)
            err("connect(" + KBEngineApp.app.getInitArgs().ip + ":" + KBEngineApp.app.getInitArgs().port + ") is error! (连接错误)");
        else
            err("connect successfully, please wait...(连接成功，请等候...)");
    }

    public void onCreateAccountResult(UInt16 retcode, byte[] datas)
    {
        if (retcode != 0)
        {
            err("createAccount is error(注册账号错误)! err=" + KBEngineApp.app.serverErr(retcode));
            return;
        }

        if (KBEngineApp.validEmail(stringAccount))
        {
            err("createAccount is successfully, Please activate your Email!(注册账号成功，请激活Email!)");
        }
        else
        {
            err("createAccount is successfully!(注册账号成功!)");
        }
    }

    float reloginCount;
    public void onLoginFailed(UInt16 failedcode, byte[] serverdatas)
    {
        if (failedcode == 20)
        {
            err("login is failed(登陆失败), err=" + KBEngineApp.app.serverErr(failedcode) + ", " + System.Text.Encoding.ASCII.GetString(serverdatas));
        }
        else
        {
            err("login is failed(登陆失败), err=" + KBEngineApp.app.serverErr(failedcode));
        }

        //尝试两次重连，还不行，退掉
        reloginCount += 1;
        if (reloginCount < 2)
        {
            login();
        }
        else
        {
            Application.Quit();
        }
    }

    public void onLoginBaseappFailed(UInt16 failedcode)
    {
        err("loginBaseapp is failed(登陆网关失败), err=" + KBEngineApp.app.serverErr(failedcode));
    }

    public void onLoginSuccessfully(UInt64 rndUUID, Int32 eid, Account accountEntity)
    {
        Debug.Log("asdasdasdasd Login Successfully");
        //SceneManager.LoadScene("selavatars");

        // SceneManager.LoadScene("selavatars1");
    }

    public void onReloginBaseappFailed(UInt16 failedcode)
    {
        err("relogin is failed(重连网关失败), err=" + KBEngineApp.app.serverErr(failedcode));
        startRelogin = false;
    }

    public void onReloginBaseappSuccessfully()
    {
        err("relogin is successfully!(重连成功!)");
        startRelogin = false;
    }

    public void onLoginBaseapp()
    {
        err("connect to loginBaseapp, please wait...(连接到网关， 请稍后...)");
    }

    public void onCreateAvatarResult(UInt64 retcode, AVATAR_INFOS info, Dictionary<UInt64, AVATAR_INFOS> avatarList)
    {
        if (retcode != 0)
        {
            err("Error creating avatar, errcode=" + retcode);
            return;
        }
        //(avatarList);
    }



    //Debug 消息
    void err(string debugMessage)
    {
        Debug.Log(debugMessage);
    }
    //登录
    public void login()
    {
        err("connect to server...(连接到服务端...)" + stringAccount);
        KBEngine.Event.fireIn("login", stringAccount, stringPasswd, System.Text.Encoding.UTF8.GetBytes("kbengine_unity3d_demo"));

    }

    //获取房间列表
    public void onReqSpaceReport(List<SPACE_REPORT> arg1)
    {
        charactorSelectUi.SetActive(true);
        DebugUI.SetActive(false);
        foreach (SPACE_REPORT sp in arg1)
        {
            GameObject tempButton =  GameObject.Instantiate(RoomListPerfab, RoomListPerfab.transform.position, Quaternion.identity, RoomListParent.transform);
            // tempButton.transform.GetChild(0).GetComponent<Text>().text= sp.spaceName +"                                                            " + sp.avatarCount +  "/" +sp.maxPlayer;
           // Debug.Log(sp.spaceName +"       "+ sp.avatarCount);
            tempButton.GetComponent<RoomAttributes>().setSpAttributes(sp.spaceKey, sp.spaceName, sp.spaceUType, sp.avatarCount, sp.maxPlayer) ;
           // tempButton.GetComponent<RoomAttributes>().setSpAttributes(sp.spaceKey, sp.spaceName, sp.spaceUType, sp.avatarCount, sp.maxPlayer);
           // Debug.Log("spaceKey" + sp.spaceKey + "spaceName " + sp.spaceName);
        }
    }

    #region 进入游戏
    Byte roolType =1;
    String Playername="";
    UInt32 modelID =1;
    UInt64 spaceKey =1;

    //玩家名字
    public InputField playerNameFiled;

    public string getPlayerName()
    {
        return Playername;
    }
    public void setSPaceKey(UInt64 sk)
    {
        spaceKey = sk;
      //  charactorSelectUi.SetActive(true);
        EnterTheWorld();
    }

    public void setModelID(int sk)
    {
        modelID = Convert.ToUInt32(sk + 1);
    }

    public void CharacterReady()
    {
        Playername = playerNameFiled.text;
        if (Playername.Trim() != "")
        {
            charactorSelectUi.SetActive(false);
            GameManager.instance.RoomListUI.SetActive(true);
        }
    }
    public void EnterTheWorld()
    {
           // Debug.Log(Playername + "           1111111             "  +spaceKey.ToString());
            enterByCreating(roolType, Playername, modelID, spaceKey);
            SceneManager.LoadScene("Block");
        
    }

    public void enterByCreating(Byte arg1, string arg2, uint arg3, ulong arg4)
    {
        KBEngine.Event.fireIn("registerSpawnPoint", new Vector3(52f, 0f, 38f));
        KBEngine.Event.fireIn("enterByCreating", arg1, arg2, arg3, arg4);

    }
    #endregion;
}
