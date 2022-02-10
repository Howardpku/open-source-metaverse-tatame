using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SelectCharacter : MonoBehaviour
{
    // Start is called before the first frame update
    public GameObject[] charcterList;
    private GameObject currentCharacter;
    void Start()
    {
        currentCharacter = charcterList[0];
        SelectChacterMethod(0);
    }

    public void SelectChacterMethod(int i)
    {
        currentCharacter.SetActive(false);
        currentCharacter = charcterList[i];
        GameManager.instance.setModelID(i);
        currentCharacter.SetActive(true);
    }

    public void hideCurrent()
    {
      //  Debug.Log(GameManager.instance.Playername().Trim());
       if(GameManager.instance.getPlayerName().Trim() != "")
        currentCharacter.SetActive(false);
    }
}
