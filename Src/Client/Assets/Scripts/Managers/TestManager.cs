using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Common.Data;
using UnityEngine;

namespace Managers
{
    class TestManager : Singleton <TestManager>
    {
        public void Init()
        {
            NpcManager.Instance.RegisterNpcEvent(Common.Data.NpcFunction.InvokeShop, OnNpcInvokeShop);
            NpcManager.Instance.RegisterNpcEvent(Common.Data.NpcFunction.InvokeInstance, OnNpcInvokeInstance);
        }

        private bool OnNpcInvokeShop(NpcDefine npc)
        {
            Debug.LogFormat("TestManager.OnNpcInvokeShop  NPC :{0}:{1}  Type:{2}    Func:{3}", npc.ID, npc.Name,npc.Type, npc.Function);
            UITest test = UIManager.Instance.Show<UITest>();
            test.SetTitle(npc.Name);
            return true;
        }

        private bool OnNpcInvokeInstance(NpcDefine npc)
        {
            Debug.LogFormat("TestManager.OnNpcInvokeShop  NPC :{0}:{1}  Type:{2}    Func:{3}", npc.ID, npc.Name, npc.Type, npc.Function);
            MessageBox.Show("点击了NPC:    " + npc.Name, "与NPC对话");
            return true;
        }


    }
}
