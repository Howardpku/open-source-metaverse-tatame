using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MessageBoxShowTime : MonoBehaviour
{
    public static MessageBoxShowTime instance;
    float showTime;
    bool show;
    private void Awake()
    {
        instance = this;
    }
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (!show)
            return;

        if(showTime>0f)
        {
            showTime -= Time.deltaTime;
        }
        else
        {
            this.GetComponent<Image>().enabled = false;
            show = false;            
        }
    }

    public void resetShowTime(float restTime)
    {
        show = true;
        this.GetComponent<Image>().enabled = true;
        showTime = restTime;
    }
}
