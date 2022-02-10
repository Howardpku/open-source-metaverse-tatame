using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class PlayerMovement : MonoBehaviour
{
    public CharacterController controller;
   // public Transform cam;
    private Animator animator;
    public float speed = 6f;
    public float turnSmoothTime = 0.1f;
    float turnSmoothVelocity;
    public VJHandler jh;
    void Start()
    {
        animator = gameObject.GetComponentInChildren<Animator>();
        if (GameObject.Find("Canvas")!=null)
        {
            jh = GameObject.Find("Canvas").GetComponent<StartApp>().GetYGl();
            GameObject.Find("Canvas").GetComponent<StartApp>().SetPm(this);
        }
        Camera.main.gameObject.GetComponent<CameraMover>().setFollow(this.transform.GetChild(0).transform);
     //   cam = Camera.main.transform;
    }

    public void wiiw()
    {
        if (b==true)
        {
            animator.SetInteger("ToN", -1);
            KBEngine.Event.fireIn("jump");
            temp = 1;
            b = false;
            StartCoroutine(SecondTimer());
        }
    }

    public void Greet()
    {
        animator.SetInteger("ToN", 2);
        StartCoroutine(IdelTimer(0.2f));
    }
    public void talk()
    {
        animator.SetInteger("ToN", 3);
        StartCoroutine(IdelTimer(0.2f));
    }
    public void dance()
    {
        KBEngine.Event.fireIn("sendEmoji", (byte)4);
        animator.SetInteger("ToN", 4);
        StartCoroutine(IdelTimer(0.2f));
    }

    IEnumerator IdelTimer(float a)
    {
        yield return new WaitForSeconds(a);
        animator.SetInteger("ToN", 0);
    }

    public void Idel()
    {
        animator.SetInteger("ToN", 0);
    }


    //public void Setsudu()
    //{
    //    speed = sl.value;
    //    t.text = speed.ToString();
    //}
    public GameObject fire;
    //public Slider sl;
    //public Text t;
    IEnumerator SecondTimer()
    {
        yield return new WaitForSeconds(0.1f);
        animator.SetInteger("ToN", 0);
        yield return new WaitForSeconds(1f);
       // an.pyfire();
        Playfire();
        yield return new WaitForSeconds(2f);
        temp = 0;
        yield return new WaitForSeconds(4f);
        b = true;
    }

    public void Playfire()
    {
        fire.SetActive(true);
   
    }

    int temp = 0;
    bool b = true;
    int c = 0;

    void Update()
    {
        //float horizontal = Input.GetAxisRaw("Horizontal");
        //float vertical = Input.GetAxisRaw("Vertical");
     //   float horizontal = Input.GetAxis("Horizontal");
       
     //   float vertical = Input.GetAxis("Vertical");
        //controller.Move(direction.normalized * speed * Time.deltaTime);
        if (jh!=null)
        {
            Vector3 direction = new Vector3(jh.InputDirection.x, 0f, jh.InputDirection.y).normalized;
            // Vector3 direction = new Vector3(0, 0f, 0).normalized;
            if (direction.magnitude >= 0.1f)
            {

                if (temp == 0)
                {

                    float targetangle = Mathf.Atan2(direction.x, direction.z) * Mathf.Rad2Deg + Camera.main.transform.eulerAngles.y;
                    float angle = Mathf.SmoothDampAngle(transform.eulerAngles.y, targetangle, ref turnSmoothVelocity, turnSmoothTime);
                    transform.rotation = Quaternion.Euler(0f, angle, 0f);
                    Vector3 moveDir = Quaternion.Euler(0f, targetangle, 0f) * Vector3.forward;
                    controller.Move(moveDir.normalized * speed * Time.deltaTime);
                    //  transform.Translate(moveDir.normalized * speed * Time.deltaTime, Space.World);
                    animator.SetInteger("ToN", 1);
                    c = 1;
                }
            }
            else
            {
                if (temp == 0)
                {
                    if (c == 1)
                    {
                        animator.SetInteger("ToN", 0);
                        c = 0;
                    }
                }
            }
        }
    
        //if (transform.position.y<=-20)
        //{
        //    Debug.Log("d");
        //    transform.position= new Vector3(0, 0.2f, 0);
        //}


    }

}