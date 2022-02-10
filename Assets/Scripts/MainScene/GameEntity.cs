
using UnityEngine;
using KBEngine;
using System.Collections;
using System;
using System.Xml;
using System.Collections.Generic;

public class GameEntity : MonoBehaviour 
{
	public bool isPlayer = false;
	
	private Vector3 _position = Vector3.zero;
	private Vector3 _eulerAngles = Vector3.zero;
	private Vector3 _scale = Vector3.zero;
	private UInt32 _spaceID = 1;

    public Vector3 destPosition = Vector3.zero;
    public Vector3 destDirection = Vector3.zero;
	
	private float _speed = 0f;
	private byte jumpState = 0;
	private float currY = 0.1f;
	
	public Camera playerCamera = null;
	
	public string entity_name;
	
	public string hp = "100/100";
	
	float npcHeight = 2.0f;
	
	public CharacterController characterController;
	
	public bool isOnGround = true;

	public bool isControlled = false;
	
	public bool entityEnabled = true;
	public TextMesh thead;
	void Awake ()   
	{

	}



	void OnBecameVisible()
    {
		isrend = true;
    }
	 void OnBecameInvisible()
	{
		isrend = false;
	}
	public bool isrend = false;
	void Start()
	{
		characterController = ((UnityEngine.GameObject)gameObject).GetComponent<CharacterController>();
		animator = ((UnityEngine.GameObject)gameObject).GetComponentInChildren<Animator>();
		isrend = true;
	 
	}
	public Transform uposition;
	public string nanan;
	public int aa=40;
	public int cccc = -150;
	public int temp = 0;
	void OnGUI()
	{
        //if (!gameObject.transform.Find("Graphics").GetComponent<MeshRenderer>().GetComponent<Renderer>().isVisible)
        //    return;

		 
		if (isrend)
        {

            //     Vector3 worldPosition = new Vector3(transform.position.x, transform.position.y + npcHeight, transform.position.z);

            if (playerCamera == null)
                playerCamera = Camera.main;




        }



	}
    public void LateUpdate()
    {
        if (thead!=null&&Camera.main!=null)
        {
         thead.transform.rotation = Camera.main.transform.rotation;	 
		}
    }
    public Vector3 position {  
		get
		{
			return _position;
		}

		set
		{
			_position = value;
			
			if(gameObject != null)
				gameObject.transform.position = _position;
		}    
    }  
  
    public Vector3 eulerAngles {  
		get
		{
			return _eulerAngles;
		}

		set
		{
			_eulerAngles = value;
			
			if(gameObject != null)
			{
				gameObject.transform.eulerAngles = _eulerAngles;
			}
		}    
    }  

    public Quaternion rotation {  
		get
		{
			return Quaternion.Euler(_eulerAngles);
		}

		set
		{
			eulerAngles = value.eulerAngles;
		}    
    }  
    
    public Vector3 scale {  
		get
		{
			return _scale;
		}
		set
		{
			_scale = value;
			
			if(gameObject != null)
				gameObject.transform.localScale = _scale;
		}    
    }
	private Animator animator;
    public float speed {  
		get
		{
			return _speed;
		}

		set
		{
			_speed = value;
		}    
    } 

    public UInt32 spaceID {  
		get
		{
			return _spaceID;
		}

		set
		{
			_spaceID = value;
		}    
    } 
    
	public void entityEnable()
	{
		entityEnabled = true;
	}

	public void entityDisable()
	{
		entityEnabled = false;
	}

	public void set_state(sbyte v)
	{
		if (v == 3) 
		{
			if(isPlayer)
				gameObject.transform.Find ("Graphics").GetComponent<MeshRenderer> ().material.color = Color.green;
			else
				gameObject.transform.Find ("Graphics").GetComponent<MeshRenderer> ().material.color = Color.red;
		} else if (v == 0) 
		{
			if(isPlayer)
				gameObject.transform.Find ("Graphics").GetComponent<MeshRenderer> ().material.color = Color.blue;
			else
				gameObject.transform.Find ("Graphics").GetComponent<MeshRenderer> ().material.color = Color.white;
		} else if (v == 1) {
			gameObject.transform.Find ("Graphics").GetComponent<MeshRenderer> ().material.color = Color.black;
		}
	}
	
    void FixedUpdate() 
    {

		if (!entityEnabled || KBEngineApp.app == null)
			return;
 
		if (isPlayer == isControlled)
    		return;
 

		KBEngine.Event.fireIn("updatePlayer", spaceID, gameObject.transform.position.x, 
			gameObject.transform.position.y, gameObject.transform.position.z, gameObject.transform.rotation.eulerAngles.y);
    }

 

	public bool aaaaa = true;
	public GameObject g;
	void Update () 
	{
		if (!entityEnabled) 
		{
			position = destPosition;
			return;
		}

		float deltaSpeed = (3f * Time.deltaTime);

		if (isPlayer == true && isControlled == false)
		{
			characterController.stepOffset = deltaSpeed;
			
			if(isOnGround != characterController.isGrounded)
			{
		    	KBEngine.Entity player = KBEngineApp.app.player();
		    	player.isOnGround = characterController.isGrounded;
		    	isOnGround = characterController.isGrounded;
		    }
		    
			return;
		}

		if (Vector3.Distance(eulerAngles, destDirection) > 0.0004f)
		{
			rotation = Quaternion.Slerp(rotation, Quaternion.Euler(destDirection), 8f * Time.deltaTime);
		}

		float dist = 0.0f;

		// 如果isOnGround为true，服务端同步其他实体到客户端时为了节省流量并不同步y轴，客户端需要强制将实体贴在地面上
		// 由于这里的地面位置就是0，所以直接填入0，如果是通过navmesh不规则地表高度寻路则需要想办法得到地面位置
		if(isOnGround)
		{
			dist = Vector3.Distance(new Vector3(destPosition.x, 0f, destPosition.z), 
				new Vector3(position.x, 0, position.z));
		}
		else
		{
			dist = Vector3.Distance(destPosition, position);
		}
	
		if (jumpState > 0)
        {
            if (jumpState == 1)
            {
                currY += 0.05f;

                if (currY > 2.0f)
                    jumpState = 2;
            }
            else
            {
                currY -= 0.05f;
                if (currY < 1.0f)
                {
                    jumpState = 0;
                    currY = 1.0f;
                }
            }

            Vector3 pos = position;
            pos.y = currY;
            position = pos;
        }
        if (dist > 0.01f)
		{
			Vector3 pos = position;

			Vector3 movement = destPosition - pos;
			movement.y = 0;
			movement.Normalize();
			
			movement *= deltaSpeed;
			
			if(dist > deltaSpeed || movement.magnitude > deltaSpeed)
				pos += movement;
			else
				pos = destPosition;

			//if(isOnGround)
			//	pos.y = 0.129f;
			position = pos;
            if (animator!=null)
            {
		 
				if (animator != null)
				{
					animator.SetInteger("ToN", 1); aaaaa = true;
				}
			}
		
		}
		else
		{
			
			position = destPosition;
			if (animator != null)
			{
	 
				if (aaaaa == true)
				{
					animator.SetInteger("ToN", 0);
					aaaaa = false;
				}
			}
		}
	}
	
	public void OnJump()
	{
		if(jumpState != 0)
			return;
		jumpState = 1;
		if (g!=null)
        {
			StartCoroutine(SecondTimer()); 
		 	animator.SetInteger("ToN", -1);
		}
	}

	public void ReceiveEmoj(byte arg1)
	{
		animator.SetInteger("ToN", arg1);
		StartCoroutine(IdelTimer(0.2f));
	}
	int tx = 0;
	IEnumerator SecondTimer()
	{
		yield return new WaitForSeconds(0.1f);
		animator.SetInteger("ToN", 0);
		yield return new WaitForSeconds(1f);
		g.SetActive(true);
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
	IEnumerator IdelTimer(float a)
	{
		yield return new WaitForSeconds(a);
		animator.SetInteger("ToN", 0);
	}

	public void Idel()
	{
		animator.SetInteger("ToN", 0);
	}

	public void OnPlayFireWorks(ushort a, ushort b)
	{
		if (a == 0)
		{
            switch (b)
            {
				case 1:
					OnJump();
					break;
				case 2:
					Greet();
					break;
				case 3:
					talk();
					break;
				default:
                    break;
            }

		}
	}

	public void Speak( string a)
	{

		StopAllCoroutines();

		StartCoroutine(WaitAndPrint(3.0f));
	}
	IEnumerator WaitAndPrint(float waitTime)
	{
		yield return new WaitForSeconds(waitTime);
		print("WaitAndPrint " + Time.time);

	}
}

