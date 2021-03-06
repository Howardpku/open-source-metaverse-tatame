/*
	Generated by KBEngine!
	Please do not modify this file!
	tools = kbcmd
*/

namespace KBEngine
{
	using UnityEngine;
	using System;
	using System.Collections;
	using System.Collections.Generic;

	public class EntityDef
	{
		public static Dictionary<string, UInt16> datatype2id = new Dictionary<string, UInt16>();
		public static Dictionary<string, DATATYPE_BASE> datatypes = new Dictionary<string, DATATYPE_BASE>();
		public static Dictionary<UInt16, DATATYPE_BASE> id2datatypes = new Dictionary<UInt16, DATATYPE_BASE>();
		public static Dictionary<string, Int32> entityclass = new Dictionary<string, Int32>();
		public static Dictionary<string, ScriptModule> moduledefs = new Dictionary<string, ScriptModule>();
		public static Dictionary<UInt16, ScriptModule> idmoduledefs = new Dictionary<UInt16, ScriptModule>();

		public static bool init()
		{
			initDataTypes();
			initDefTypes();
			initScriptModules();
			return true;
		}

		public static bool reset()
		{
			clear();
			return init();
		}

		public static void clear()
		{
			datatype2id.Clear();
			datatypes.Clear();
			id2datatypes.Clear();
			entityclass.Clear();
			moduledefs.Clear();
			idmoduledefs.Clear();
		}

		public static void initDataTypes()
		{
			datatypes["UINT8"] = new DATATYPE_UINT8();
			datatypes["UINT16"] = new DATATYPE_UINT16();
			datatypes["UINT32"] = new DATATYPE_UINT32();
			datatypes["UINT64"] = new DATATYPE_UINT64();

			datatypes["INT8"] = new DATATYPE_INT8();
			datatypes["INT16"] = new DATATYPE_INT16();
			datatypes["INT32"] = new DATATYPE_INT32();
			datatypes["INT64"] = new DATATYPE_INT64();

			datatypes["FLOAT"] = new DATATYPE_FLOAT();
			datatypes["DOUBLE"] = new DATATYPE_DOUBLE();

			datatypes["STRING"] = new DATATYPE_STRING();
			datatypes["VECTOR2"] = new DATATYPE_VECTOR2();

			datatypes["VECTOR3"] = new DATATYPE_VECTOR3();

			datatypes["VECTOR4"] = new DATATYPE_VECTOR4();
			datatypes["PYTHON"] = new DATATYPE_PYTHON();

			datatypes["UNICODE"] = new DATATYPE_UNICODE();
			datatypes["ENTITYCALL"] = new DATATYPE_ENTITYCALL();

			datatypes["BLOB"] = new DATATYPE_BLOB();
		}

		public static void initScriptModules()
		{
			ScriptModule pAccountModule = new ScriptModule("Account");
			EntityDef.moduledefs["Account"] = pAccountModule;
			EntityDef.idmoduledefs[1] = pAccountModule;

			Property pAccount_position = new Property();
			pAccount_position.name = "position";
			pAccount_position.properUtype = 40000;
			pAccount_position.properFlags = 4;
			pAccount_position.aliasID = 1;
			Vector3 Account_position_defval = new Vector3();
			pAccount_position.defaultVal = Account_position_defval;
			pAccountModule.propertys["position"] = pAccount_position; 

			pAccountModule.usePropertyDescrAlias = true;
			pAccountModule.idpropertys[(UInt16)pAccount_position.aliasID] = pAccount_position;

			//Dbg.DEBUG_MSG("EntityDef::initScriptModules: add(Account), property(position / 40000).");

			Property pAccount_direction = new Property();
			pAccount_direction.name = "direction";
			pAccount_direction.properUtype = 40001;
			pAccount_direction.properFlags = 4;
			pAccount_direction.aliasID = 2;
			Vector3 Account_direction_defval = new Vector3();
			pAccount_direction.defaultVal = Account_direction_defval;
			pAccountModule.propertys["direction"] = pAccount_direction; 

			pAccountModule.usePropertyDescrAlias = true;
			pAccountModule.idpropertys[(UInt16)pAccount_direction.aliasID] = pAccount_direction;

			//Dbg.DEBUG_MSG("EntityDef::initScriptModules: add(Account), property(direction / 40001).");

			Property pAccount_spaceID = new Property();
			pAccount_spaceID.name = "spaceID";
			pAccount_spaceID.properUtype = 40002;
			pAccount_spaceID.properFlags = 16;
			pAccount_spaceID.aliasID = 3;
			UInt32 Account_spaceID_defval;
			UInt32.TryParse("", out Account_spaceID_defval);
			pAccount_spaceID.defaultVal = Account_spaceID_defval;
			pAccountModule.propertys["spaceID"] = pAccount_spaceID; 

			pAccountModule.usePropertyDescrAlias = true;
			pAccountModule.idpropertys[(UInt16)pAccount_spaceID.aliasID] = pAccount_spaceID;

			//Dbg.DEBUG_MSG("EntityDef::initScriptModules: add(Account), property(spaceID / 40002).");

			List<DATATYPE_BASE> pAccount_onCreateAvatarResult_args = new List<DATATYPE_BASE>();
			pAccount_onCreateAvatarResult_args.Add(EntityDef.id2datatypes[2]);
			pAccount_onCreateAvatarResult_args.Add(EntityDef.id2datatypes[25]);

			Method pAccount_onCreateAvatarResult = new Method();
			pAccount_onCreateAvatarResult.name = "onCreateAvatarResult";
			pAccount_onCreateAvatarResult.methodUtype = 10005;
			pAccount_onCreateAvatarResult.aliasID = 1;
			pAccount_onCreateAvatarResult.args = pAccount_onCreateAvatarResult_args;

			pAccountModule.methods["onCreateAvatarResult"] = pAccount_onCreateAvatarResult; 
			pAccountModule.useMethodDescrAlias = true;
			pAccountModule.idmethods[(UInt16)pAccount_onCreateAvatarResult.aliasID] = pAccount_onCreateAvatarResult;

			//Dbg.DEBUG_MSG("EntityDef::initScriptModules: add(Account), method(onCreateAvatarResult / 10005).");

			List<DATATYPE_BASE> pAccount_onRegisterSpawnPoint_args = new List<DATATYPE_BASE>();
			pAccount_onRegisterSpawnPoint_args.Add(EntityDef.id2datatypes[16]);

			Method pAccount_onRegisterSpawnPoint = new Method();
			pAccount_onRegisterSpawnPoint.name = "onRegisterSpawnPoint";
			pAccount_onRegisterSpawnPoint.methodUtype = 3;
			pAccount_onRegisterSpawnPoint.aliasID = 2;
			pAccount_onRegisterSpawnPoint.args = pAccount_onRegisterSpawnPoint_args;

			pAccountModule.methods["onRegisterSpawnPoint"] = pAccount_onRegisterSpawnPoint; 
			pAccountModule.useMethodDescrAlias = true;
			pAccountModule.idmethods[(UInt16)pAccount_onRegisterSpawnPoint.aliasID] = pAccount_onRegisterSpawnPoint;

			//Dbg.DEBUG_MSG("EntityDef::initScriptModules: add(Account), method(onRegisterSpawnPoint / 3).");

			List<DATATYPE_BASE> pAccount_onReqSpaceReport_args = new List<DATATYPE_BASE>();
			pAccount_onReqSpaceReport_args.Add(EntityDef.id2datatypes[34]);

			Method pAccount_onReqSpaceReport = new Method();
			pAccount_onReqSpaceReport.name = "onReqSpaceReport";
			pAccount_onReqSpaceReport.methodUtype = 2;
			pAccount_onReqSpaceReport.aliasID = 3;
			pAccount_onReqSpaceReport.args = pAccount_onReqSpaceReport_args;

			pAccountModule.methods["onReqSpaceReport"] = pAccount_onReqSpaceReport; 
			pAccountModule.useMethodDescrAlias = true;
			pAccountModule.idmethods[(UInt16)pAccount_onReqSpaceReport.aliasID] = pAccount_onReqSpaceReport;

			//Dbg.DEBUG_MSG("EntityDef::initScriptModules: add(Account), method(onReqSpaceReport / 2).");

			List<DATATYPE_BASE> pAccount_enterByCreating_args = new List<DATATYPE_BASE>();
			pAccount_enterByCreating_args.Add(EntityDef.id2datatypes[2]);
			pAccount_enterByCreating_args.Add(EntityDef.id2datatypes[12]);
			pAccount_enterByCreating_args.Add(EntityDef.id2datatypes[4]);
			pAccount_enterByCreating_args.Add(EntityDef.id2datatypes[5]);

			Method pAccount_enterByCreating = new Method();
			pAccount_enterByCreating.name = "enterByCreating";
			pAccount_enterByCreating.methodUtype = 10002;
			pAccount_enterByCreating.aliasID = -1;
			pAccount_enterByCreating.args = pAccount_enterByCreating_args;

			pAccountModule.methods["enterByCreating"] = pAccount_enterByCreating; 
			pAccountModule.base_methods["enterByCreating"] = pAccount_enterByCreating;

			pAccountModule.idbase_methods[pAccount_enterByCreating.methodUtype] = pAccount_enterByCreating;

			//Dbg.DEBUG_MSG("EntityDef::initScriptModules: add(Account), method(enterByCreating / 10002).");

			List<DATATYPE_BASE> pAccount_registerSpawnPoint_args = new List<DATATYPE_BASE>();
			pAccount_registerSpawnPoint_args.Add(EntityDef.id2datatypes[16]);

			Method pAccount_registerSpawnPoint = new Method();
			pAccount_registerSpawnPoint.name = "registerSpawnPoint";
			pAccount_registerSpawnPoint.methodUtype = 1;
			pAccount_registerSpawnPoint.aliasID = -1;
			pAccount_registerSpawnPoint.args = pAccount_registerSpawnPoint_args;

			pAccountModule.methods["registerSpawnPoint"] = pAccount_registerSpawnPoint; 
			pAccountModule.base_methods["registerSpawnPoint"] = pAccount_registerSpawnPoint;

			pAccountModule.idbase_methods[pAccount_registerSpawnPoint.methodUtype] = pAccount_registerSpawnPoint;

			//Dbg.DEBUG_MSG("EntityDef::initScriptModules: add(Account), method(registerSpawnPoint / 1).");

			ScriptModule pAvatarModule = new ScriptModule("Avatar");
			EntityDef.moduledefs["Avatar"] = pAvatarModule;
			EntityDef.idmoduledefs[2] = pAvatarModule;

			Property pAvatar_position = new Property();
			pAvatar_position.name = "position";
			pAvatar_position.properUtype = 40000;
			pAvatar_position.properFlags = 4;
			pAvatar_position.aliasID = 1;
			Vector3 Avatar_position_defval = new Vector3();
			pAvatar_position.defaultVal = Avatar_position_defval;
			pAvatarModule.propertys["position"] = pAvatar_position; 

			pAvatarModule.usePropertyDescrAlias = true;
			pAvatarModule.idpropertys[(UInt16)pAvatar_position.aliasID] = pAvatar_position;

			//Dbg.DEBUG_MSG("EntityDef::initScriptModules: add(Avatar), property(position / 40000).");

			Property pAvatar_direction = new Property();
			pAvatar_direction.name = "direction";
			pAvatar_direction.properUtype = 40001;
			pAvatar_direction.properFlags = 4;
			pAvatar_direction.aliasID = 2;
			Vector3 Avatar_direction_defval = new Vector3();
			pAvatar_direction.defaultVal = Avatar_direction_defval;
			pAvatarModule.propertys["direction"] = pAvatar_direction; 

			pAvatarModule.usePropertyDescrAlias = true;
			pAvatarModule.idpropertys[(UInt16)pAvatar_direction.aliasID] = pAvatar_direction;

			//Dbg.DEBUG_MSG("EntityDef::initScriptModules: add(Avatar), property(direction / 40001).");

			Property pAvatar_spaceID = new Property();
			pAvatar_spaceID.name = "spaceID";
			pAvatar_spaceID.properUtype = 40002;
			pAvatar_spaceID.properFlags = 16;
			pAvatar_spaceID.aliasID = 3;
			UInt32 Avatar_spaceID_defval;
			UInt32.TryParse("", out Avatar_spaceID_defval);
			pAvatar_spaceID.defaultVal = Avatar_spaceID_defval;
			pAvatarModule.propertys["spaceID"] = pAvatar_spaceID; 

			pAvatarModule.usePropertyDescrAlias = true;
			pAvatarModule.idpropertys[(UInt16)pAvatar_spaceID.aliasID] = pAvatar_spaceID;

			//Dbg.DEBUG_MSG("EntityDef::initScriptModules: add(Avatar), property(spaceID / 40002).");

			Property pAvatar_forbids = new Property();
			pAvatar_forbids.name = "forbids";
			pAvatar_forbids.properUtype = 47005;
			pAvatar_forbids.properFlags = 4;
			pAvatar_forbids.aliasID = 4;
			Int32 Avatar_forbids_defval;
			Int32.TryParse("0", out Avatar_forbids_defval);
			pAvatar_forbids.defaultVal = Avatar_forbids_defval;
			pAvatarModule.propertys["forbids"] = pAvatar_forbids; 

			pAvatarModule.usePropertyDescrAlias = true;
			pAvatarModule.idpropertys[(UInt16)pAvatar_forbids.aliasID] = pAvatar_forbids;

			//Dbg.DEBUG_MSG("EntityDef::initScriptModules: add(Avatar), property(forbids / 47005).");

			Property pAvatar_level = new Property();
			pAvatar_level.name = "level";
			pAvatar_level.properUtype = 41002;
			pAvatar_level.properFlags = 8;
			pAvatar_level.aliasID = 5;
			UInt16 Avatar_level_defval;
			UInt16.TryParse("", out Avatar_level_defval);
			pAvatar_level.defaultVal = Avatar_level_defval;
			pAvatarModule.propertys["level"] = pAvatar_level; 

			pAvatarModule.usePropertyDescrAlias = true;
			pAvatarModule.idpropertys[(UInt16)pAvatar_level.aliasID] = pAvatar_level;

			//Dbg.DEBUG_MSG("EntityDef::initScriptModules: add(Avatar), property(level / 41002).");

			Property pAvatar_modelID = new Property();
			pAvatar_modelID.name = "modelID";
			pAvatar_modelID.properUtype = 41006;
			pAvatar_modelID.properFlags = 4;
			pAvatar_modelID.aliasID = 6;
			UInt32 Avatar_modelID_defval;
			UInt32.TryParse("0", out Avatar_modelID_defval);
			pAvatar_modelID.defaultVal = Avatar_modelID_defval;
			pAvatarModule.propertys["modelID"] = pAvatar_modelID; 

			pAvatarModule.usePropertyDescrAlias = true;
			pAvatarModule.idpropertys[(UInt16)pAvatar_modelID.aliasID] = pAvatar_modelID;

			//Dbg.DEBUG_MSG("EntityDef::initScriptModules: add(Avatar), property(modelID / 41006).");

			Property pAvatar_modelScale = new Property();
			pAvatar_modelScale.name = "modelScale";
			pAvatar_modelScale.properUtype = 41007;
			pAvatar_modelScale.properFlags = 4;
			pAvatar_modelScale.aliasID = 7;
			Byte Avatar_modelScale_defval;
			Byte.TryParse("30", out Avatar_modelScale_defval);
			pAvatar_modelScale.defaultVal = Avatar_modelScale_defval;
			pAvatarModule.propertys["modelScale"] = pAvatar_modelScale; 

			pAvatarModule.usePropertyDescrAlias = true;
			pAvatarModule.idpropertys[(UInt16)pAvatar_modelScale.aliasID] = pAvatar_modelScale;

			//Dbg.DEBUG_MSG("EntityDef::initScriptModules: add(Avatar), property(modelScale / 41007).");

			Property pAvatar_moveSpeed = new Property();
			pAvatar_moveSpeed.name = "moveSpeed";
			pAvatar_moveSpeed.properUtype = 8;
			pAvatar_moveSpeed.properFlags = 4;
			pAvatar_moveSpeed.aliasID = 8;
			Byte Avatar_moveSpeed_defval;
			Byte.TryParse("50", out Avatar_moveSpeed_defval);
			pAvatar_moveSpeed.defaultVal = Avatar_moveSpeed_defval;
			pAvatarModule.propertys["moveSpeed"] = pAvatar_moveSpeed; 

			pAvatarModule.usePropertyDescrAlias = true;
			pAvatarModule.idpropertys[(UInt16)pAvatar_moveSpeed.aliasID] = pAvatar_moveSpeed;

			//Dbg.DEBUG_MSG("EntityDef::initScriptModules: add(Avatar), property(moveSpeed / 8).");

			Property pAvatar_name = new Property();
			pAvatar_name.name = "name";
			pAvatar_name.properUtype = 41003;
			pAvatar_name.properFlags = 4;
			pAvatar_name.aliasID = 9;
			string Avatar_name_defval = "";
			pAvatar_name.defaultVal = Avatar_name_defval;
			pAvatarModule.propertys["name"] = pAvatar_name; 

			pAvatarModule.usePropertyDescrAlias = true;
			pAvatarModule.idpropertys[(UInt16)pAvatar_name.aliasID] = pAvatar_name;

			//Dbg.DEBUG_MSG("EntityDef::initScriptModules: add(Avatar), property(name / 41003).");

			Property pAvatar_own_val = new Property();
			pAvatar_own_val.name = "own_val";
			pAvatar_own_val.properUtype = 3;
			pAvatar_own_val.properFlags = 16;
			pAvatar_own_val.aliasID = 10;
			UInt16 Avatar_own_val_defval;
			UInt16.TryParse("", out Avatar_own_val_defval);
			pAvatar_own_val.defaultVal = Avatar_own_val_defval;
			pAvatarModule.propertys["own_val"] = pAvatar_own_val; 

			pAvatarModule.usePropertyDescrAlias = true;
			pAvatarModule.idpropertys[(UInt16)pAvatar_own_val.aliasID] = pAvatar_own_val;

			//Dbg.DEBUG_MSG("EntityDef::initScriptModules: add(Avatar), property(own_val / 3).");

			Property pAvatar_spaceKey = new Property();
			pAvatar_spaceKey.name = "spaceKey";
			pAvatar_spaceKey.properUtype = 4;
			pAvatar_spaceKey.properFlags = 4;
			pAvatar_spaceKey.aliasID = 11;
			UInt64 Avatar_spaceKey_defval;
			UInt64.TryParse("", out Avatar_spaceKey_defval);
			pAvatar_spaceKey.defaultVal = Avatar_spaceKey_defval;
			pAvatarModule.propertys["spaceKey"] = pAvatar_spaceKey; 

			pAvatarModule.usePropertyDescrAlias = true;
			pAvatarModule.idpropertys[(UInt16)pAvatar_spaceKey.aliasID] = pAvatar_spaceKey;

			//Dbg.DEBUG_MSG("EntityDef::initScriptModules: add(Avatar), property(spaceKey / 4).");

			Property pAvatar_spaceUType = new Property();
			pAvatar_spaceUType.name = "spaceUType";
			pAvatar_spaceUType.properUtype = 41001;
			pAvatar_spaceUType.properFlags = 8;
			pAvatar_spaceUType.aliasID = 12;
			UInt32 Avatar_spaceUType_defval;
			UInt32.TryParse("", out Avatar_spaceUType_defval);
			pAvatar_spaceUType.defaultVal = Avatar_spaceUType_defval;
			pAvatarModule.propertys["spaceUType"] = pAvatar_spaceUType; 

			pAvatarModule.usePropertyDescrAlias = true;
			pAvatarModule.idpropertys[(UInt16)pAvatar_spaceUType.aliasID] = pAvatar_spaceUType;

			//Dbg.DEBUG_MSG("EntityDef::initScriptModules: add(Avatar), property(spaceUType / 41001).");

			Property pAvatar_state = new Property();
			pAvatar_state.name = "state";
			pAvatar_state.properUtype = 47006;
			pAvatar_state.properFlags = 4;
			pAvatar_state.aliasID = 13;
			SByte Avatar_state_defval;
			SByte.TryParse("0", out Avatar_state_defval);
			pAvatar_state.defaultVal = Avatar_state_defval;
			pAvatarModule.propertys["state"] = pAvatar_state; 

			pAvatarModule.usePropertyDescrAlias = true;
			pAvatarModule.idpropertys[(UInt16)pAvatar_state.aliasID] = pAvatar_state;

			//Dbg.DEBUG_MSG("EntityDef::initScriptModules: add(Avatar), property(state / 47006).");

			Property pAvatar_subState = new Property();
			pAvatar_subState.name = "subState";
			pAvatar_subState.properUtype = 47007;
			pAvatar_subState.properFlags = 4;
			pAvatar_subState.aliasID = 14;
			Byte Avatar_subState_defval;
			Byte.TryParse("", out Avatar_subState_defval);
			pAvatar_subState.defaultVal = Avatar_subState_defval;
			pAvatarModule.propertys["subState"] = pAvatar_subState; 

			pAvatarModule.usePropertyDescrAlias = true;
			pAvatarModule.idpropertys[(UInt16)pAvatar_subState.aliasID] = pAvatar_subState;

			//Dbg.DEBUG_MSG("EntityDef::initScriptModules: add(Avatar), property(subState / 47007).");

			Property pAvatar_uid = new Property();
			pAvatar_uid.name = "uid";
			pAvatar_uid.properUtype = 41004;
			pAvatar_uid.properFlags = 4;
			pAvatar_uid.aliasID = 15;
			UInt32 Avatar_uid_defval;
			UInt32.TryParse("0", out Avatar_uid_defval);
			pAvatar_uid.defaultVal = Avatar_uid_defval;
			pAvatarModule.propertys["uid"] = pAvatar_uid; 

			pAvatarModule.usePropertyDescrAlias = true;
			pAvatarModule.idpropertys[(UInt16)pAvatar_uid.aliasID] = pAvatar_uid;

			//Dbg.DEBUG_MSG("EntityDef::initScriptModules: add(Avatar), property(uid / 41004).");

			Property pAvatar_utype = new Property();
			pAvatar_utype.name = "utype";
			pAvatar_utype.properUtype = 41005;
			pAvatar_utype.properFlags = 4;
			pAvatar_utype.aliasID = 16;
			UInt32 Avatar_utype_defval;
			UInt32.TryParse("0", out Avatar_utype_defval);
			pAvatar_utype.defaultVal = Avatar_utype_defval;
			pAvatarModule.propertys["utype"] = pAvatar_utype; 

			pAvatarModule.usePropertyDescrAlias = true;
			pAvatarModule.idpropertys[(UInt16)pAvatar_utype.aliasID] = pAvatar_utype;

			//Dbg.DEBUG_MSG("EntityDef::initScriptModules: add(Avatar), property(utype / 41005).");

			List<DATATYPE_BASE> pAvatar_onGetNeighbours_args = new List<DATATYPE_BASE>();
			pAvatar_onGetNeighbours_args.Add(EntityDef.id2datatypes[35]);

			Method pAvatar_onGetNeighbours = new Method();
			pAvatar_onGetNeighbours.name = "onGetNeighbours";
			pAvatar_onGetNeighbours.methodUtype = 17;
			pAvatar_onGetNeighbours.aliasID = 1;
			pAvatar_onGetNeighbours.args = pAvatar_onGetNeighbours_args;

			pAvatarModule.methods["onGetNeighbours"] = pAvatar_onGetNeighbours; 
			pAvatarModule.useMethodDescrAlias = true;
			pAvatarModule.idmethods[(UInt16)pAvatar_onGetNeighbours.aliasID] = pAvatar_onGetNeighbours;

			//Dbg.DEBUG_MSG("EntityDef::initScriptModules: add(Avatar), method(onGetNeighbours / 17).");

			List<DATATYPE_BASE> pAvatar_onJump_args = new List<DATATYPE_BASE>();

			Method pAvatar_onJump = new Method();
			pAvatar_onJump.name = "onJump";
			pAvatar_onJump.methodUtype = 21;
			pAvatar_onJump.aliasID = 2;
			pAvatar_onJump.args = pAvatar_onJump_args;

			pAvatarModule.methods["onJump"] = pAvatar_onJump; 
			pAvatarModule.useMethodDescrAlias = true;
			pAvatarModule.idmethods[(UInt16)pAvatar_onJump.aliasID] = pAvatar_onJump;

			//Dbg.DEBUG_MSG("EntityDef::initScriptModules: add(Avatar), method(onJump / 21).");

			List<DATATYPE_BASE> pAvatar_onReqToken_args = new List<DATATYPE_BASE>();
			pAvatar_onReqToken_args.Add(EntityDef.id2datatypes[4]);
			pAvatar_onReqToken_args.Add(EntityDef.id2datatypes[12]);
			pAvatar_onReqToken_args.Add(EntityDef.id2datatypes[12]);
			pAvatar_onReqToken_args.Add(EntityDef.id2datatypes[12]);

			Method pAvatar_onReqToken = new Method();
			pAvatar_onReqToken.name = "onReqToken";
			pAvatar_onReqToken.methodUtype = 16;
			pAvatar_onReqToken.aliasID = 3;
			pAvatar_onReqToken.args = pAvatar_onReqToken_args;

			pAvatarModule.methods["onReqToken"] = pAvatar_onReqToken; 
			pAvatarModule.useMethodDescrAlias = true;
			pAvatarModule.idmethods[(UInt16)pAvatar_onReqToken.aliasID] = pAvatar_onReqToken;

			//Dbg.DEBUG_MSG("EntityDef::initScriptModules: add(Avatar), method(onReqToken / 16).");

			List<DATATYPE_BASE> pAvatar_onSendEmoji_args = new List<DATATYPE_BASE>();
			pAvatar_onSendEmoji_args.Add(EntityDef.id2datatypes[2]);

			Method pAvatar_onSendEmoji = new Method();
			pAvatar_onSendEmoji.name = "onSendEmoji";
			pAvatar_onSendEmoji.methodUtype = 18;
			pAvatar_onSendEmoji.aliasID = 4;
			pAvatar_onSendEmoji.args = pAvatar_onSendEmoji_args;

			pAvatarModule.methods["onSendEmoji"] = pAvatar_onSendEmoji; 
			pAvatarModule.useMethodDescrAlias = true;
			pAvatarModule.idmethods[(UInt16)pAvatar_onSendEmoji.aliasID] = pAvatar_onSendEmoji;

			//Dbg.DEBUG_MSG("EntityDef::initScriptModules: add(Avatar), method(onSendEmoji / 18).");

			List<DATATYPE_BASE> pAvatar_onSendInfo_args = new List<DATATYPE_BASE>();
			pAvatar_onSendInfo_args.Add(EntityDef.id2datatypes[4]);
			pAvatar_onSendInfo_args.Add(EntityDef.id2datatypes[4]);

			Method pAvatar_onSendInfo = new Method();
			pAvatar_onSendInfo.name = "onSendInfo";
			pAvatar_onSendInfo.methodUtype = 19;
			pAvatar_onSendInfo.aliasID = 5;
			pAvatar_onSendInfo.args = pAvatar_onSendInfo_args;

			pAvatarModule.methods["onSendInfo"] = pAvatar_onSendInfo; 
			pAvatarModule.useMethodDescrAlias = true;
			pAvatarModule.idmethods[(UInt16)pAvatar_onSendInfo.aliasID] = pAvatar_onSendInfo;

			//Dbg.DEBUG_MSG("EntityDef::initScriptModules: add(Avatar), method(onSendInfo / 19).");

			List<DATATYPE_BASE> pAvatar_onSendString_args = new List<DATATYPE_BASE>();
			pAvatar_onSendString_args.Add(EntityDef.id2datatypes[12]);

			Method pAvatar_onSendString = new Method();
			pAvatar_onSendString.name = "onSendString";
			pAvatar_onSendString.methodUtype = 20;
			pAvatar_onSendString.aliasID = 6;
			pAvatar_onSendString.args = pAvatar_onSendString_args;

			pAvatarModule.methods["onSendString"] = pAvatar_onSendString; 
			pAvatarModule.useMethodDescrAlias = true;
			pAvatarModule.idmethods[(UInt16)pAvatar_onSendString.aliasID] = pAvatar_onSendString;

			//Dbg.DEBUG_MSG("EntityDef::initScriptModules: add(Avatar), method(onSendString / 20).");

			List<DATATYPE_BASE> pAvatar_alive_args = new List<DATATYPE_BASE>();

			Method pAvatar_alive = new Method();
			pAvatar_alive.name = "alive";
			pAvatar_alive.methodUtype = 10;
			pAvatar_alive.aliasID = -1;
			pAvatar_alive.args = pAvatar_alive_args;

			pAvatarModule.methods["alive"] = pAvatar_alive; 
			pAvatarModule.cell_methods["alive"] = pAvatar_alive;

			pAvatarModule.idcell_methods[pAvatar_alive.methodUtype] = pAvatar_alive;

			//Dbg.DEBUG_MSG("EntityDef::initScriptModules: add(Avatar), method(alive / 10).");

			List<DATATYPE_BASE> pAvatar_changeStates_args = new List<DATATYPE_BASE>();
			pAvatar_changeStates_args.Add(EntityDef.id2datatypes[6]);
			pAvatar_changeStates_args.Add(EntityDef.id2datatypes[2]);

			Method pAvatar_changeStates = new Method();
			pAvatar_changeStates.name = "changeStates";
			pAvatar_changeStates.methodUtype = 12;
			pAvatar_changeStates.aliasID = -1;
			pAvatar_changeStates.args = pAvatar_changeStates_args;

			pAvatarModule.methods["changeStates"] = pAvatar_changeStates; 
			pAvatarModule.cell_methods["changeStates"] = pAvatar_changeStates;

			pAvatarModule.idcell_methods[pAvatar_changeStates.methodUtype] = pAvatar_changeStates;

			//Dbg.DEBUG_MSG("EntityDef::initScriptModules: add(Avatar), method(changeStates / 12).");

			List<DATATYPE_BASE> pAvatar_getNeighbours_args = new List<DATATYPE_BASE>();

			Method pAvatar_getNeighbours = new Method();
			pAvatar_getNeighbours.name = "getNeighbours";
			pAvatar_getNeighbours.methodUtype = 7;
			pAvatar_getNeighbours.aliasID = -1;
			pAvatar_getNeighbours.args = pAvatar_getNeighbours_args;

			pAvatarModule.methods["getNeighbours"] = pAvatar_getNeighbours; 
			pAvatarModule.cell_methods["getNeighbours"] = pAvatar_getNeighbours;

			pAvatarModule.idcell_methods[pAvatar_getNeighbours.methodUtype] = pAvatar_getNeighbours;

			//Dbg.DEBUG_MSG("EntityDef::initScriptModules: add(Avatar), method(getNeighbours / 7).");

			List<DATATYPE_BASE> pAvatar_jump_args = new List<DATATYPE_BASE>();

			Method pAvatar_jump = new Method();
			pAvatar_jump.name = "jump";
			pAvatar_jump.methodUtype = 9;
			pAvatar_jump.aliasID = -1;
			pAvatar_jump.args = pAvatar_jump_args;

			pAvatarModule.methods["jump"] = pAvatar_jump; 
			pAvatarModule.cell_methods["jump"] = pAvatar_jump;

			pAvatarModule.idcell_methods[pAvatar_jump.methodUtype] = pAvatar_jump;

			//Dbg.DEBUG_MSG("EntityDef::initScriptModules: add(Avatar), method(jump / 9).");

			List<DATATYPE_BASE> pAvatar_relive_args = new List<DATATYPE_BASE>();
			pAvatar_relive_args.Add(EntityDef.id2datatypes[2]);

			Method pAvatar_relive = new Method();
			pAvatar_relive.name = "relive";
			pAvatar_relive.methodUtype = 8;
			pAvatar_relive.aliasID = -1;
			pAvatar_relive.args = pAvatar_relive_args;

			pAvatarModule.methods["relive"] = pAvatar_relive; 
			pAvatarModule.cell_methods["relive"] = pAvatar_relive;

			pAvatarModule.idcell_methods[pAvatar_relive.methodUtype] = pAvatar_relive;

			//Dbg.DEBUG_MSG("EntityDef::initScriptModules: add(Avatar), method(relive / 8).");

			List<DATATYPE_BASE> pAvatar_reqToken_args = new List<DATATYPE_BASE>();

			Method pAvatar_reqToken = new Method();
			pAvatar_reqToken.name = "reqToken";
			pAvatar_reqToken.methodUtype = 4;
			pAvatar_reqToken.aliasID = -1;
			pAvatar_reqToken.args = pAvatar_reqToken_args;

			pAvatarModule.methods["reqToken"] = pAvatar_reqToken; 
			pAvatarModule.cell_methods["reqToken"] = pAvatar_reqToken;

			pAvatarModule.idcell_methods[pAvatar_reqToken.methodUtype] = pAvatar_reqToken;

			//Dbg.DEBUG_MSG("EntityDef::initScriptModules: add(Avatar), method(reqToken / 4).");

			List<DATATYPE_BASE> pAvatar_sendEmoji_args = new List<DATATYPE_BASE>();
			pAvatar_sendEmoji_args.Add(EntityDef.id2datatypes[2]);

			Method pAvatar_sendEmoji = new Method();
			pAvatar_sendEmoji.name = "sendEmoji";
			pAvatar_sendEmoji.methodUtype = 11;
			pAvatar_sendEmoji.aliasID = -1;
			pAvatar_sendEmoji.args = pAvatar_sendEmoji_args;

			pAvatarModule.methods["sendEmoji"] = pAvatar_sendEmoji; 
			pAvatarModule.cell_methods["sendEmoji"] = pAvatar_sendEmoji;

			pAvatarModule.idcell_methods[pAvatar_sendEmoji.methodUtype] = pAvatar_sendEmoji;

			//Dbg.DEBUG_MSG("EntityDef::initScriptModules: add(Avatar), method(sendEmoji / 11).");

			List<DATATYPE_BASE> pAvatar_sendInfo_args = new List<DATATYPE_BASE>();
			pAvatar_sendInfo_args.Add(EntityDef.id2datatypes[4]);
			pAvatar_sendInfo_args.Add(EntityDef.id2datatypes[4]);

			Method pAvatar_sendInfo = new Method();
			pAvatar_sendInfo.name = "sendInfo";
			pAvatar_sendInfo.methodUtype = 13;
			pAvatar_sendInfo.aliasID = -1;
			pAvatar_sendInfo.args = pAvatar_sendInfo_args;

			pAvatarModule.methods["sendInfo"] = pAvatar_sendInfo; 
			pAvatarModule.cell_methods["sendInfo"] = pAvatar_sendInfo;

			pAvatarModule.idcell_methods[pAvatar_sendInfo.methodUtype] = pAvatar_sendInfo;

			//Dbg.DEBUG_MSG("EntityDef::initScriptModules: add(Avatar), method(sendInfo / 13).");

			List<DATATYPE_BASE> pAvatar_sendString_args = new List<DATATYPE_BASE>();
			pAvatar_sendString_args.Add(EntityDef.id2datatypes[12]);

			Method pAvatar_sendString = new Method();
			pAvatar_sendString.name = "sendString";
			pAvatar_sendString.methodUtype = 14;
			pAvatar_sendString.aliasID = -1;
			pAvatar_sendString.args = pAvatar_sendString_args;

			pAvatarModule.methods["sendString"] = pAvatar_sendString; 
			pAvatarModule.cell_methods["sendString"] = pAvatar_sendString;

			pAvatarModule.idcell_methods[pAvatar_sendString.methodUtype] = pAvatar_sendString;

			//Dbg.DEBUG_MSG("EntityDef::initScriptModules: add(Avatar), method(sendString / 14).");

		}

		public static void initDefTypes()
		{
			{
				UInt16 utype = 2;
				string typeName = "ENTITY_SUBSTATE";
				string name = "UINT8";
				DATATYPE_BASE val = null;
				EntityDef.datatypes.TryGetValue(name, out val);
				EntityDef.datatypes[typeName] = val;
				EntityDef.id2datatypes[utype] = EntityDef.datatypes[typeName];
				EntityDef.datatype2id[typeName] = utype;
			}

			{
				UInt16 utype = 3;
				string typeName = "UINT16";
				string name = "UINT16";
				DATATYPE_BASE val = null;
				EntityDef.datatypes.TryGetValue(name, out val);
				EntityDef.datatypes[typeName] = val;
				EntityDef.id2datatypes[utype] = EntityDef.datatypes[typeName];
				EntityDef.datatype2id[typeName] = utype;
			}

			{
				UInt16 utype = 5;
				string typeName = "UID";
				string name = "UINT64";
				DATATYPE_BASE val = null;
				EntityDef.datatypes.TryGetValue(name, out val);
				EntityDef.datatypes[typeName] = val;
				EntityDef.id2datatypes[utype] = EntityDef.datatypes[typeName];
				EntityDef.datatype2id[typeName] = utype;
			}

			{
				UInt16 utype = 4;
				string typeName = "ENTITY_UTYPE";
				string name = "UINT32";
				DATATYPE_BASE val = null;
				EntityDef.datatypes.TryGetValue(name, out val);
				EntityDef.datatypes[typeName] = val;
				EntityDef.id2datatypes[utype] = EntityDef.datatypes[typeName];
				EntityDef.datatype2id[typeName] = utype;
			}

			{
				UInt16 utype = 6;
				string typeName = "ENTITY_STATE";
				string name = "INT8";
				DATATYPE_BASE val = null;
				EntityDef.datatypes.TryGetValue(name, out val);
				EntityDef.datatypes[typeName] = val;
				EntityDef.id2datatypes[utype] = EntityDef.datatypes[typeName];
				EntityDef.datatype2id[typeName] = utype;
			}

			{
				UInt16 utype = 7;
				string typeName = "INT16";
				string name = "INT16";
				DATATYPE_BASE val = null;
				EntityDef.datatypes.TryGetValue(name, out val);
				EntityDef.datatypes[typeName] = val;
				EntityDef.id2datatypes[utype] = EntityDef.datatypes[typeName];
				EntityDef.datatype2id[typeName] = utype;
			}

			{
				UInt16 utype = 8;
				string typeName = "ENTITY_FORBIDS";
				string name = "INT32";
				DATATYPE_BASE val = null;
				EntityDef.datatypes.TryGetValue(name, out val);
				EntityDef.datatypes[typeName] = val;
				EntityDef.id2datatypes[utype] = EntityDef.datatypes[typeName];
				EntityDef.datatype2id[typeName] = utype;
			}

			{
				UInt16 utype = 9;
				string typeName = "INT64";
				string name = "INT64";
				DATATYPE_BASE val = null;
				EntityDef.datatypes.TryGetValue(name, out val);
				EntityDef.datatypes[typeName] = val;
				EntityDef.id2datatypes[utype] = EntityDef.datatypes[typeName];
				EntityDef.datatype2id[typeName] = utype;
			}

			{
				UInt16 utype = 1;
				string typeName = "STRING";
				string name = "STRING";
				DATATYPE_BASE val = null;
				EntityDef.datatypes.TryGetValue(name, out val);
				EntityDef.datatypes[typeName] = val;
				EntityDef.id2datatypes[utype] = EntityDef.datatypes[typeName];
				EntityDef.datatype2id[typeName] = utype;
			}

			{
				UInt16 utype = 12;
				string typeName = "UNICODE";
				string name = "UNICODE";
				DATATYPE_BASE val = null;
				EntityDef.datatypes.TryGetValue(name, out val);
				EntityDef.datatypes[typeName] = val;
				EntityDef.id2datatypes[utype] = EntityDef.datatypes[typeName];
				EntityDef.datatype2id[typeName] = utype;
			}

			{
				UInt16 utype = 13;
				string typeName = "FLOAT";
				string name = "FLOAT";
				DATATYPE_BASE val = null;
				EntityDef.datatypes.TryGetValue(name, out val);
				EntityDef.datatypes[typeName] = val;
				EntityDef.id2datatypes[utype] = EntityDef.datatypes[typeName];
				EntityDef.datatype2id[typeName] = utype;
			}

			{
				UInt16 utype = 14;
				string typeName = "DOUBLE";
				string name = "DOUBLE";
				DATATYPE_BASE val = null;
				EntityDef.datatypes.TryGetValue(name, out val);
				EntityDef.datatypes[typeName] = val;
				EntityDef.id2datatypes[utype] = EntityDef.datatypes[typeName];
				EntityDef.datatype2id[typeName] = utype;
			}

			{
				UInt16 utype = 10;
				string typeName = "UID1";
				string name = "PYTHON";
				DATATYPE_BASE val = null;
				EntityDef.datatypes.TryGetValue(name, out val);
				EntityDef.datatypes[typeName] = val;
				EntityDef.id2datatypes[utype] = EntityDef.datatypes[typeName];
				EntityDef.datatype2id[typeName] = utype;
			}

			{
				UInt16 utype = 10;
				string typeName = "PY_DICT";
				string name = "PY_DICT";
				DATATYPE_BASE val = null;
				EntityDef.datatypes.TryGetValue(name, out val);
				EntityDef.datatypes[typeName] = val;
				EntityDef.id2datatypes[utype] = EntityDef.datatypes[typeName];
				EntityDef.datatype2id[typeName] = utype;
			}

			{
				UInt16 utype = 10;
				string typeName = "PY_TUPLE";
				string name = "PY_TUPLE";
				DATATYPE_BASE val = null;
				EntityDef.datatypes.TryGetValue(name, out val);
				EntityDef.datatypes[typeName] = val;
				EntityDef.id2datatypes[utype] = EntityDef.datatypes[typeName];
				EntityDef.datatype2id[typeName] = utype;
			}

			{
				UInt16 utype = 10;
				string typeName = "PY_LIST";
				string name = "PY_LIST";
				DATATYPE_BASE val = null;
				EntityDef.datatypes.TryGetValue(name, out val);
				EntityDef.datatypes[typeName] = val;
				EntityDef.id2datatypes[utype] = EntityDef.datatypes[typeName];
				EntityDef.datatype2id[typeName] = utype;
			}

			{
				UInt16 utype = 20;
				string typeName = "ENTITYCALL";
				string name = "ENTITYCALL";
				DATATYPE_BASE val = null;
				EntityDef.datatypes.TryGetValue(name, out val);
				EntityDef.datatypes[typeName] = val;
				EntityDef.id2datatypes[utype] = EntityDef.datatypes[typeName];
				EntityDef.datatype2id[typeName] = utype;
			}

			{
				UInt16 utype = 11;
				string typeName = "BLOB";
				string name = "BLOB";
				DATATYPE_BASE val = null;
				EntityDef.datatypes.TryGetValue(name, out val);
				EntityDef.datatypes[typeName] = val;
				EntityDef.id2datatypes[utype] = EntityDef.datatypes[typeName];
				EntityDef.datatype2id[typeName] = utype;
			}

			{
				UInt16 utype = 15;
				string typeName = "VECTOR2";
				string name = "VECTOR2";
				DATATYPE_BASE val = null;
				EntityDef.datatypes.TryGetValue(name, out val);
				EntityDef.datatypes[typeName] = val;
				EntityDef.id2datatypes[utype] = EntityDef.datatypes[typeName];
				EntityDef.datatype2id[typeName] = utype;
			}

			{
				UInt16 utype = 16;
				string typeName = "DIRECTION3D";
				string name = "VECTOR3";
				DATATYPE_BASE val = null;
				EntityDef.datatypes.TryGetValue(name, out val);
				EntityDef.datatypes[typeName] = val;
				EntityDef.id2datatypes[utype] = EntityDef.datatypes[typeName];
				EntityDef.datatype2id[typeName] = utype;
			}

			{
				UInt16 utype = 17;
				string typeName = "VECTOR4";
				string name = "VECTOR4";
				DATATYPE_BASE val = null;
				EntityDef.datatypes.TryGetValue(name, out val);
				EntityDef.datatypes[typeName] = val;
				EntityDef.id2datatypes[utype] = EntityDef.datatypes[typeName];
				EntityDef.datatype2id[typeName] = utype;
			}

			{
				UInt16 utype = 22;
				string typeName = "ENTITY_FORBID_COUNTER";
				DATATYPE_ENTITY_FORBID_COUNTER datatype = new DATATYPE_ENTITY_FORBID_COUNTER();
				EntityDef.datatypes[typeName] = datatype;
				EntityDef.id2datatypes[utype] = EntityDef.datatypes[typeName];
				EntityDef.datatype2id[typeName] = utype;
			}

			{
				UInt16 utype = 23;
				string typeName = "ENTITYID_LIST";
				DATATYPE_ENTITYID_LIST datatype = new DATATYPE_ENTITYID_LIST();
				EntityDef.datatypes[typeName] = datatype;
				EntityDef.id2datatypes[utype] = EntityDef.datatypes[typeName];
				EntityDef.datatype2id[typeName] = utype;
			}

			{
				UInt16 utype = 24;
				string typeName = "AVATAR_DATA";
				DATATYPE_AVATAR_DATA datatype = new DATATYPE_AVATAR_DATA();
				EntityDef.datatypes[typeName] = datatype;
				EntityDef.id2datatypes[utype] = EntityDef.datatypes[typeName];
				EntityDef.datatype2id[typeName] = utype;
			}

			{
				UInt16 utype = 25;
				string typeName = "AVATAR_INFOS";
				DATATYPE_AVATAR_INFOS datatype = new DATATYPE_AVATAR_INFOS();
				EntityDef.datatypes[typeName] = datatype;
				EntityDef.id2datatypes[utype] = EntityDef.datatypes[typeName];
				EntityDef.datatype2id[typeName] = utype;
			}

			{
				UInt16 utype = 26;
				string typeName = "AVATAR_INFOS_LIST";
				DATATYPE_AVATAR_INFOS_LIST datatype = new DATATYPE_AVATAR_INFOS_LIST();
				EntityDef.datatypes[typeName] = datatype;
				EntityDef.id2datatypes[utype] = EntityDef.datatypes[typeName];
				EntityDef.datatype2id[typeName] = utype;
			}

			{
				UInt16 utype = 28;
				string typeName = "BAG";
				DATATYPE_BAG datatype = new DATATYPE_BAG();
				EntityDef.datatypes[typeName] = datatype;
				EntityDef.id2datatypes[utype] = EntityDef.datatypes[typeName];
				EntityDef.datatype2id[typeName] = utype;
			}

			{
				UInt16 utype = 31;
				string typeName = "SPACE_REPORT";
				DATATYPE_SPACE_REPORT datatype = new DATATYPE_SPACE_REPORT();
				EntityDef.datatypes[typeName] = datatype;
				EntityDef.id2datatypes[utype] = EntityDef.datatypes[typeName];
				EntityDef.datatype2id[typeName] = utype;
			}

			{
				UInt16 utype = 32;
				string typeName = "AVATAR_REPORT";
				DATATYPE_AVATAR_REPORT datatype = new DATATYPE_AVATAR_REPORT();
				EntityDef.datatypes[typeName] = datatype;
				EntityDef.id2datatypes[utype] = EntityDef.datatypes[typeName];
				EntityDef.datatype2id[typeName] = utype;
			}

			{
				UInt16 utype = 33;
				string typeName = "EXAMPLES";
				DATATYPE_EXAMPLES datatype = new DATATYPE_EXAMPLES();
				EntityDef.datatypes[typeName] = datatype;
				EntityDef.id2datatypes[utype] = EntityDef.datatypes[typeName];
				EntityDef.datatype2id[typeName] = utype;
			}

			{
				UInt16 utype = 34;
				string typeName = "AnonymousArray_34";
				DATATYPE_AnonymousArray_34 datatype = new DATATYPE_AnonymousArray_34();
				EntityDef.datatypes[typeName] = datatype;
				EntityDef.id2datatypes[utype] = EntityDef.datatypes[typeName];
				EntityDef.datatype2id[typeName] = utype;
			}

			{
				UInt16 utype = 35;
				string typeName = "AnonymousArray_35";
				DATATYPE_AnonymousArray_35 datatype = new DATATYPE_AnonymousArray_35();
				EntityDef.datatypes[typeName] = datatype;
				EntityDef.id2datatypes[utype] = EntityDef.datatypes[typeName];
				EntityDef.datatype2id[typeName] = utype;
			}

			foreach(string datatypeStr in EntityDef.datatypes.Keys)
			{
				DATATYPE_BASE dataType = EntityDef.datatypes[datatypeStr];
				if(dataType != null)
				{
					dataType.bind();
				}
			}
		}

	}


}