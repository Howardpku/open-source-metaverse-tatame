using KBEngine;
using UnityEngine;
using System; 
using System.IO;  
using System.Collections; 
using System.Collections.Generic;
using System.Linq;
using UnityEngine.SceneManagement;
public class MWorld : MonoBehaviour 
{
	private UnityEngine.GameObject terrain = null;
	public UnityEngine.GameObject terrainPerfab;
	
	private UnityEngine.GameObject player = null;
	//public UnityEngine.GameObject entityPerfab;
	//public UnityEngine.GameObject avatarPerfab;
	public UnityEngine.GameObject[] playerPerfab;
	public UnityEngine.GameObject[] avatarPerfabs;

	void Awake() 
	 {

	 }
	public int playertype=0;
	// Use this for initialization
	void Start () 
	{
		installEvents();
	}

	void installEvents()
	{
		// in world
		KBEngine.Event.registerOut("addSpaceGeometryMapping", this, "addSpaceGeometryMapping");
		KBEngine.Event.registerOut("onEnterWorld", this, "onEnterWorld");
		KBEngine.Event.registerOut("onLeaveWorld", this, "onLeaveWorld");
		KBEngine.Event.registerOut("set_position", this, "set_position");
		KBEngine.Event.registerOut("set_direction", this, "set_direction");
		KBEngine.Event.registerOut("updatePosition", this, "updatePosition");
		KBEngine.Event.registerOut("onControlled", this, "onControlled");
		
		// in world(register by scripts)
		KBEngine.Event.registerOut("onAvatarEnterWorld", this, "onAvatarEnterWorld");

		KBEngine.Event.registerOut("set_name", this, "set_entityName");
		KBEngine.Event.registerOut("set_state", this, "set_state");
		KBEngine.Event.registerOut("set_moveSpeed", this, "set_moveSpeed");

		//KBEngine.Event.registerOut("otherAvatarOnJump", this, "otherAvatarOnJump");

		//发送表情
		KBEngine.Event.registerOut("onSendEmoji", this, "onSendEmoji");

	}

	void OnDestroy()
	{
		KBEngine.Event.deregisterOut(this);
	}
	
	// Update is called once per frame
	void Update () 
	{
     
			createPlayer();
	 
		
	
  //      if (Input.GetKeyUp(KeyCode.Space))
  //      {
		//	Debug.Log("KeyCode.Space");
		//	KBEngine.Event.fireIn("jump");
		//	KBEngine.Event.fireIn("speak","test");
		//	KBEngine.Event.fireIn("playFireworks", (ushort)0,(ushort)1);
		//}

	}
	
	public void addSpaceGeometryMapping(string respath)
	{
		// 这个事件可以理解为服务器通知客户端加载指定的场景资源
		// 通过服务器的api KBEngine.addSpaceGeometryMapping设置到spaceData中，进入space的玩家就会被同步spaceData里面的内容
		//Debug.Log("loading scene加载-----(" + respath + ")...");


		if (terrain == null)
			terrain = Instantiate(terrainPerfab) as UnityEngine.GameObject;

        if (player)
        {
		
			player.GetComponent<GameEntity>().entityEnable();
		//	Debug.Log("entityEnable");
		}
           
    }	
	
	public void onAvatarEnterWorld(UInt64 rndUUID, Int32 eid, KBEngine.Avatar avatar)
	{
	 //   UI.inst.err("onAvatarEnterWorld");
		if (!avatar.isPlayer())
		{
			return;
		}

		Debug.Log("loading scene...");
	}

	public void createPlayer()
	{
		//
		// 需要等场景加载完毕再显示玩家
		if (player != null)
		{
			if(terrain != null)
				player.GetComponent<GameEntity>().entityEnable();
			return;
		}

		if (KBEngineApp.app.entity_type != "Avatar") {
			return;
		}

        KBEngine.Avatar avatar = (KBEngine.Avatar)KBEngineApp.app.player();
		if(avatar == null)
		{
			//Debug.Log("");
			return;
		}
	
		float y = avatar.position.y;
		//if(avatar.isOnGround)
		//	y = 1.3f;

		UInt32 mid1 = 0;
		if (avatar != null)
		{
			mid1 = avatar.modelID;

		}

		//player = Instantiate(avatarPerfab, new Vector3(avatar.position.x, y, avatar.position.z), 
		//                     Quaternion.Euler(new Vector3(avatar.direction.y, avatar.direction.z, avatar.direction.x))) as UnityEngine.GameObject;
		//player = Instantiate(playerPerfab[playertype], new Vector3(avatar.position.x, y, avatar.position.z),
  //                           Quaternion.Euler(new Vector3(avatar.direction.y, avatar.direction.z, avatar.direction.x))) as UnityEngine.GameObject;
     
		player = Instantiate(playerPerfab[mid1-1], new Vector3(avatar.position.x, y, avatar.position.z),
						 Quaternion.Euler(new Vector3(avatar.direction.y, avatar.direction.z, avatar.direction.x))) as UnityEngine.GameObject;

		player.GetComponent<GameEntity>().entityDisable();
        avatar.renderObj = player;
		((UnityEngine.GameObject)avatar.renderObj).GetComponent<GameEntity>().isPlayer = true;
		//if (player)
		//{
		//	player.GetComponent<GameEntity>().entityEnable();
		//}
		// 有必要设置一下，由于该接口由Update异步调用，有可能set_position等初始化信息已经先触发了                                                          
		// 那么如果不设置renderObj的位置和方向将为0，人物会陷入地下
		set_position(avatar);
		set_direction(avatar);
        set_entityName(avatar, avatar.name);
    }

                                   
	
	public void onEnterWorld(KBEngine.Entity entity)
	{
		//UI.inst.err("onEnterWorld");
		if (entity.isPlayer())
			return;
		float y = entity.position.y;
		if(entity.isOnGround)
			y = 0f;

		//entity.renderObj = Instantiate(entityPerfab, new Vector3(entity.position.x, y, entity.position.z), 
		//	Quaternion.Euler(new Vector3(entity.direction.y, entity.direction.z, entity.direction.x))) as UnityEngine.GameObject;
		UInt32 mid=0;

		if (entity.className=="Avatar")
        {
			KBEngine.Avatar a =(KBEngine.Avatar) entity;
            if (a!=null)
            {
			  mid = a.modelID;
				//Debug.Log(mid);
            }
        }
 
	    entity.renderObj = Instantiate(avatarPerfabs[mid - 1], new Vector3(entity.position.x, y, entity.position.z),
		Quaternion.Euler(new Vector3(entity.direction.y, entity.direction.z, entity.direction.x))) as UnityEngine.GameObject;


		((UnityEngine.GameObject)entity.renderObj).name = entity.className + "_" + entity.id;
	}
	
	public void onLeaveWorld(KBEngine.Entity entity)
	{
		if(entity.renderObj == null)
			return;
		
		UnityEngine.GameObject.Destroy((UnityEngine.GameObject)entity.renderObj);
		entity.renderObj = null;
	}

	public void set_position(KBEngine.Entity entity)
	{
		if(entity.renderObj == null)
			return;

		GameEntity gameEntity = ((UnityEngine.GameObject)entity.renderObj).GetComponent<GameEntity>();
		gameEntity.destPosition = entity.position;
		gameEntity.position = entity.position;
		gameEntity.spaceID = KBEngineApp.app.spaceID;
	}

	public void updatePosition(KBEngine.Entity entity)
	{
	
		if (entity.renderObj == null)
			return;
		GameEntity gameEntity = ((UnityEngine.GameObject)entity.renderObj).GetComponent<GameEntity>();
		gameEntity.destPosition = entity.position;
		gameEntity.isOnGround = entity.isOnGround;
		if(gameEntity.isOnGround)
        {
			gameEntity.destPosition.y = 0;
		}
		gameEntity.spaceID = KBEngineApp.app.spaceID;
	}
	
	public void onControlled(KBEngine.Entity entity, bool isControlled)
	{
		if(entity.renderObj == null)
			return;
		
		GameEntity gameEntity = ((UnityEngine.GameObject)entity.renderObj).GetComponent<GameEntity>();
		gameEntity.isControlled = isControlled;
	}
	
	public void set_direction(KBEngine.Entity entity)
	{
		if (entity.renderObj == null)
			return;
		
		GameEntity gameEntity = ((UnityEngine.GameObject)entity.renderObj).GetComponent<GameEntity>();
		gameEntity.destDirection = new Vector3(entity.direction.y, entity.direction.z, entity.direction.x); 
		gameEntity.spaceID = KBEngineApp.app.spaceID;
	}


	
	public void set_entityName(KBEngine.Entity entity, string v)
	{
		if(entity.renderObj != null)
		{
			((UnityEngine.GameObject)entity.renderObj).GetComponent<GameEntity>().entity_name = v;
            if (((UnityEngine.GameObject)entity.renderObj).GetComponent<GameEntity>().thead!=null)
            {
                if (v!="server")
                {
					((UnityEngine.GameObject)entity.renderObj).GetComponent<GameEntity>().thead.text = v;
				}
			    else
                {
					((UnityEngine.GameObject)entity.renderObj).GetComponent<GameEntity>().thead.text = "";
				}

			}
		}
	}
	
	public void set_state(KBEngine.Entity entity, SByte v)
	{
		if(entity.renderObj != null)
		{
			((UnityEngine.GameObject)entity.renderObj).GetComponent<GameEntity>().set_state(v);
		}
		
		if(entity.isPlayer())
		{
			Debug.Log("player->set_state: " + v);
			
			
			return;
		}
	}

	public void set_moveSpeed(KBEngine.Entity entity, Byte v)
	{
		float fspeed = ((float)(Byte)v) / 10f;
		
		if(entity.renderObj != null)
		{
			((UnityEngine.GameObject)entity.renderObj).GetComponent<GameEntity>().speed = 3f;
		}
	}
	

	

	public void onSendEmoji(KBEngine.Entity entity, byte arg1)
	{
		if(entity.renderObj != null)
		{
			((UnityEngine.GameObject)entity.renderObj).GetComponent<GameEntity>().ReceiveEmoj(arg1);
		}
	}


}
