using UnityEngine;
using UnityEngine.EventSystems;

public class CameraMover : MonoBehaviour
{

    public Transform follow;
    private float m_fDistance = 4.0f;
    private float m_fXSpeed = 6.0f;
    private float m_fYMinLimit = 0.1f;
    private float m_fYMaxLimit = 30.1f;
    public float m_fXRot = 0.0f;
    public float m_fYRot = 0.0f;
    public float speed = 5.0f;
    //public VJHandler jsMovement;

   // float ScreenWidth;

    public void setFollow(Transform trans)
    {
        follow = trans;
    }
    void Start()
    {
   
        //if (GameObject.Find("Canvas")!=null)
        //{
        //    jsMovement = GameObject.Find("Canvas").GetComponent<StartApp>().GetYGr();
        //}

    }

    Vector3 negDistance;


    Vector2 rotatePosBegin;
    Vector2 rotatePosNew;
    Vector3 rotateDirection;
    bool BeginRotate;
    int currentRotateHandId=-1;

    void LateUpdate()
    {
        if (follow == null)
            return;
        //PhoneRotate();
        //PCRotate();

        //滑动旋转相机
        PhoneRotate();
#if UNITY_EDITOR
        PCRotate();
#endif

        //if (Input.GetMouseButton(0))
        //{
        //    Debug.Log(jsMovement.InputDirection);
        //    m_fXRot -= jsMovement.InputDirection.x / 10.0f * m_fXSpeed;
        //    m_fYRot += jsMovement.InputDirection.y / 10.0f * m_fXSpeed;
        //}
        m_fYRot = Mathf.Clamp(m_fYRot, m_fYMinLimit, m_fYMaxLimit);
        negDistance = new Vector3(0.0f, 0.0f, -m_fDistance);
        //transform.rotation = Quaternion.Lerp(transform.rotation,Quaternion.Euler(m_fYRot, m_fXRot, 0),Time.deltaTime*speed);
        transform.rotation = Quaternion.Euler(m_fYRot, m_fXRot, 0);

        // transform.position = Vector3.Lerp(transform.position, transform.rotation * negDistance + follow.position,Time.deltaTime*10f);
        transform.position = transform.rotation * negDistance + follow.position;

        //防穿墙
        CameraCollider();
    }


    void Update()
    {
        TouchInteracableObj();
    }
    //双指放大缩小
    bool BeginScale;
    Vector2 oldPos1;
    Vector2 oldPos2;
    Vector2 newPos1;
    Vector2 newPos2;

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

                float length1 = Vector2.Distance(newPos1, newPos2) - Vector2.Distance(oldPos1, oldPos2);

                if (this.GetComponent<Camera>().fieldOfView > 10f && length1 > 0)
                    this.GetComponent<Camera>().fieldOfView -= Time.deltaTime * length1 * 0.02f;

                if (this.GetComponent<Camera>().fieldOfView < 60f && length1 < 0)
                    this.GetComponent<Camera>().fieldOfView -= Time.deltaTime * length1 * 0.02f;
            }
        }
      //  oldPos1 = newPos1;
      //  oldPos2 = newPos2;
    }

    //相机碰撞检测
    Vector3 dir;
    RaycastHit hit;
    void CameraCollider()
    {
        //if (follow == null)
        //    return;
        #region 相机碰撞检测
        //相机碰撞检测
        dir = transform.position - follow.position;
        //  if (Physics.Raycast(transform.rotation * new Vector3(0.0f, 0.0f, -5f) + follow.position, dir,out hit, 5f
        if (Physics.Raycast(follow.position, dir, out hit, 4f))
        {
            if (hit.collider.tag != "Player" && hit.collider.tag != "ignore")
            {
                m_fDistance = Vector3.Distance(hit.point, follow.position);
                //   Debug.Log(hit.collider.tag);
            }
        }
        else
        {
            m_fDistance = 5f;
        }

        //if (jsMovement.InputDirection != Vector3.zero)
        //    return;
        #endregion
    }

    void PhoneRotate()
    {

        // Debug.Log(Input.mousePosition);
        if (Input.touchCount > 0)
        {

            //遍历所有touch 开始
            for (int i = 0; i < Input.touchCount; i++)
            {
                if (Input.GetTouch(i).phase == TouchPhase.Began)
                {
                    if (EventSystem.current.IsPointerOverGameObject(Input.GetTouch(Input.touchCount - 1).fingerId) == false)
                    {
                        BeginRotate = true;
                        rotatePosBegin = Input.GetTouch(i).position;
                        currentRotateHandId = i;
                    }
                    else
                    {
                        BeginRotate = false;
                        rotateDirection = Vector3.zero;
                        currentRotateHandId = -1;
                    }
                }
            }

            if (BeginRotate)
            {
                rotatePosNew = Input.GetTouch(currentRotateHandId).position;
                rotateDirection = Vector3.Normalize(rotatePosNew - rotatePosBegin);
                m_fXRot += rotateDirection.x / 12f * m_fXSpeed;
                m_fYRot -= rotateDirection.y / 12f * m_fXSpeed;

                if (Input.GetTouch(currentRotateHandId).phase == TouchPhase.Ended)
                {
                    BeginRotate = false;
                    rotateDirection = Vector3.zero;
                    currentRotateHandId = -1;
                }
            }
            
            
        }
    }

    void PCRotate()
    {
        if (Input.GetMouseButtonDown(0))
        {
            rotatePosBegin = Input.mousePosition;
            if (EventSystem.current.IsPointerOverGameObject() == false)
            {
                BeginRotate = true;
            }
        }

        if (Input.GetMouseButtonUp(0))
        {
            BeginRotate = false;
            rotateDirection = Vector3.zero;
        }

        if (Input.GetMouseButton(0))
        {
            if (BeginRotate)
            {
                rotatePosNew = Input.mousePosition;
                rotateDirection = Vector3.Normalize(rotatePosNew - rotatePosBegin);
            }
            m_fXRot -= rotateDirection.x / 8f * m_fXSpeed;
            m_fYRot += rotateDirection.y / 12f * m_fXSpeed;
        }
    }


    //可交互物体
    Ray interactorRay;
    RaycastHit interactorhit;
    public void TouchInteracableObj()
    {
        if (Input.touchCount == 1)
        {

          //  Touch firstTouch = Input.GetTouch(0);
            if (Input.GetTouch(0).phase == TouchPhase.Began)
            {
                interactorRay = Camera.main.ScreenPointToRay(Input.GetTouch(0).position);
                if (Physics.Raycast(interactorRay, out interactorhit))
                {
       
                    if(interactorhit.collider.tag== "interacable")
                    {
                        if (EventSystem.current.IsPointerOverGameObject(Input.GetTouch(0).fingerId) == false)
                        {
                            EnterDeatilModel();
                        }
                        //{

                            //}
                            //开始交互
                    }
                    //获取当前触摸到的物体
                  //  currTouchObj = hit.collider.transform;
                }
            }

            //if (Input.GetTouch(0).phase == TouchPhase.Moved)
            //{
            //    if (currTouchObj)
            //    {
            //        Vector3 touchDeltaPos = Input.GetTouch(0).deltaPosition;
            //        currTouchObj.Translate(touchDeltaPos.x * touchObjMoveSpeed, touchDeltaPos.y * touchObjMoveSpeed, 0, Space.World);
            //    }
            //}
        }
        //鼠标
        if(Input.GetMouseButtonDown(0))
        {
            interactorRay = Camera.main.ScreenPointToRay(Input.mousePosition);
            if (Physics.Raycast(interactorRay, out interactorhit))
            {
              
                if (interactorhit.collider.tag == "interacable")
                {
                    if (EventSystem.current.IsPointerOverGameObject() == false)
                    {
                        Debug.Log(interactorhit.collider.name);
                    }
                    //开始交互
                }
                //获取当前触摸到的物体
                //  currTouchObj = hit.collider.transform;
            }
        }
    }

    //DetailModel
    public GameObject[] hideObj;
    public GameObject[] showObj;
    public void EnterDeatilModel()
    {
        foreach (GameObject show in showObj)
        {
            show.SetActive(true);
        }

        foreach (GameObject hi in hideObj)
        {
            hi.SetActive(false);
        }
    }
}
 