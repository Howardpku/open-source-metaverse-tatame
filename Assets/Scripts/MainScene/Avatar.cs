namespace KBEngine
{

using System.Collections;
using System.Collections.Generic;
using System;
using UnityEngine;
 
        public class Avatar : AvatarBase
        {

        public override void __init__()
        {
            if (isPlayer())
            {
                // 注册事件
                Event.registerIn("updatePlayer", this, "updatePlayer");
                // 动作文件
                Event.registerIn("sendEmoji", this, "sendEmoji");
                Event.registerIn("sendString", this, "sendString");

            }
        }

        public void sendEmoji(Byte arg1)
        {
            cellEntityCall.sendEmoji(arg1);
        }
        //public void reqToken() {
        //    cellEntityCall.reqToken();
        //}

        public void sendString(string arg1)
        {
            cellEntityCall.sendString(arg1);
        }
        public override void onGetNeighbours(List<AVATAR_REPORT> arg1)
        {
            throw new System.NotImplementedException();
        }

        public override void onJump()
        {
            throw new System.NotImplementedException();
        }

        public override void onReqToken(uint arg1, string arg2, string arg3, string arg4)
        {
            throw new System.NotImplementedException();
        }

        public override void onSendEmoji(byte arg1)
        {
            Event.fireOut("onSendEmoji", new object[] { this, arg1 });
        }

        public override void onSendInfo(uint arg1, uint arg2)
        {
            throw new System.NotImplementedException();
        }
        public virtual void updatePlayer(UInt32 currSpaceID, float x, float y, float z, float yaw)
        {
            // 更加安全的更新位置，避免将上一个场景的坐标更新到当前场景中的玩家
            if (currSpaceID > 0 && currSpaceID != KBEngineApp.app.spaceID)
            {
                return;
            }

            position.x = x;
            position.y = y;
            position.z = z;

            direction.z = yaw;
        }



        public override void onSendString(string arg1)
        {
            Event.fireOut("onSendString", new object[] { arg1 });
        }


    }
}
