namespace KBEngine
{
  	using UnityEngine; 
	using System; 
	using System.Collections; 
	using System.Collections.Generic;
	using System.Linq;
	
    public class Account : AccountBase 
    {
		
		public Account() : base()
		{}

        public override void __init__()
        {
            // ×¢²áÊÂ¼þ
              Event.registerIn("registerSpawnPoint", this, "registerSpawnPoint");
              Event.registerIn("enterByCreating", this, "enterByCreating");
        }

        public void registerSpawnPoint(Vector3 arg1) {
            baseEntityCall.registerSpawnPoint(arg1);
        }
        //public void enterByCreating(Byte arg1, string arg2, UInt32 arg3, UInt64 arg4) {
        public void enterByCreating(Byte roleType, string name, uint modelid, ulong id)
        {
            baseEntityCall.enterByCreating((byte)roleType, name, (uint)modelid, (ulong)id);
        }

        public Dictionary<UInt64, AVATAR_INFOS> avatars = new Dictionary<UInt64, AVATAR_INFOS>();
        public override void onCreateAvatarResult(Byte retcode, AVATAR_INFOS info)
        {
            //Dbg.DEBUG_MSG(info.name);
            if (retcode == 0)
            {
                avatars.Add(info.dbid, info);
               // Dbg.DEBUG_MSG("Account::onCreateAvatarResult: name=" + info.name);
            }
            else
            {
               // Dbg.ERROR_MSG("Account::onCreateAvatarResult: retcode=" + retcode);
            }

            // ui event
            Event.fireOut("onCreateAvatarResult", new object[] { retcode, info, avatars });
            // Event.fireOut("onCreateAvatarResult", new object[] { retcode, info });
        }

        public override void onRegisterSpawnPoint(Vector3 arg1)
        {
            Event.fireOut("onRegisterSpawnPoint", new object[] { arg1 });
        }

        public override void onReqSpaceReport(List<SPACE_REPORT> arg1)
        {
            Event.fireOut("onReqSpaceReport", new object[] { arg1 });
        }


    }
} 
