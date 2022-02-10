using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraDetail : MonoBehaviour
{
    public GameObject[] hideObj;
    public GameObject[] showObj;
    GameObject currTouchObj;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        TouchInteracableObj();
        IsScaleUpandScaleDown();
    }

    public void TouchInteracableObj()
    {
        if (Input.touchCount == 1)
        {

            //  Touch firstTouch = Input.GetTouch(0);
            if (Input.GetTouch(0).phase == TouchPhase.Began)
            {

                //获取当前触摸到的物体
                currTouchObj = this.transform.GetChild(0).transform.GetChild(0).gameObject;
               
            }

            if (Input.GetTouch(0).phase == TouchPhase.Moved)
            {
                if (currTouchObj)
                {
                  //  Vector3 touchDeltaPos = Input.GetTouch(0).deltaPosition;
                    //currTouchObj.Translate(touchDeltaPos.x * touchObjMoveSpeed, touchDeltaPos.y * touchObjMoveSpeed, 0, Space.World);
                    currTouchObj.transform.Rotate(Input.GetTouch(0).deltaPosition.y * 0.3f, -Input.GetTouch(0).deltaPosition.x * 0.3f, 0,Space.World);
                }
            }
        }
        //鼠标
    }
    //双指放大缩小
    bool BeginScale;
    Vector2 oldPos1;
    Vector2 oldPos2;
    Vector2 newPos1;
    Vector2 newPos2;

    float length1;
    void IsScaleUpandScaleDown()
    {
        if (Input.touchCount == 2)
        {
            //if (EventSystem.current.IsPointerOverGameObject(Input.GetTouch(1).fingerId))
            //    return;

            if (Input.GetTouch(1).phase == TouchPhase.Began)
            {
                oldPos1 = Input.GetTouch(0).position;
                oldPos2 = Input.GetTouch(1).position;
                currTouchObj = this.transform.GetChild(0).transform.GetChild(0).gameObject;
                BeginScale = true;
                return;
            }

            if (Input.GetTouch(1).phase == TouchPhase.Ended)
            {
                BeginScale = false;
            }

            if (BeginScale)
            {
                newPos1 = Input.GetTouch(0).position;
                newPos2 = Input.GetTouch(1).position;

                length1 = Vector2.Distance(newPos1, newPos2) - Vector2.Distance(oldPos1, oldPos2);
                length1 = Time.deltaTime * length1 * 0.02f;

                if (currTouchObj.transform.localScale.x < 2f && length1 > 0)
                    currTouchObj.transform.localScale += new Vector3(length1,length1,length1);

                if (currTouchObj.transform.localScale.x  > 0.5f && length1 < 0)
                    currTouchObj.transform.localScale += new Vector3(length1, length1, length1);
            }
        }
        //  oldPos1 = newPos1;
        //  oldPos2 = newPos2;
    }
    public void ExitDeatilModle()
    {
        foreach(GameObject show in showObj)
        {
            show.SetActive(true);
        }

        foreach(GameObject hi in hideObj)
        {
            hi.SetActive(false);
        }
    }
}
