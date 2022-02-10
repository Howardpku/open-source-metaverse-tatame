using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using UnityEngine.UI;
public class StartApp : MonoBehaviour
{
    public GameObject MessageUI;
    public Transform MessageUIParent;
    // Start is called before the first frame update
    void Start()
    {
        //  string[] arguments = Environment.GetCommandLineArgs();

        //pm = GameObject.Find("PlayerPosition(Clone)").GetComponent<PlayerMovement>();
        //Debug.Log(pm);
        //if (pm!=null)
        //{
        //    pm.jh = yjhl;  
        //}
        KBEngine.Event.registerOut("onSendString", this, "onSendString");
    }
    public VJHandler yjhl;
    public VJHandler yjhr;
    public VJHandler GetYGl()
    {
        return yjhl;
    }
    public PlayerMovement pm;
    public void SetPm(PlayerMovement p)
    {
        pm = p;
    }
    public VJHandler GetYGr()
    {
        return yjhr;
    }

    public InputField inputf;


    public void Dance()
    {
        pm.dance();
    }

    public void SendMessageToAll()
    {
        if(inputf.text.Trim()!="")
        {
            KBEngine.Event.fireIn("sendString", pm.transform.GetComponent<GameEntity>().entity_name+":"+inputf.text);
            inputf.text = "";
        }
    }

    public void onSendString(string arg1)
    {
       GameObject tempUI= Instantiate(MessageUI,MessageUI.transform.position,Quaternion.identity,MessageUIParent);
       tempUI.GetComponent<Text>().text = arg1;
       tempUI.transform.SetSiblingIndex(0);
       Destroy(tempUI, 15f);
       MessageBoxShowTime.instance.resetShowTime(15f);
    }
}
