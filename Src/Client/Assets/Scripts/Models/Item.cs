using SkillBridge.Message;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Common.Data;

namespace Models
{
    public class Item
    {
        public int Id;
        public int Count;
        public ItemDefine Define;
        public Item(NItemInfo Item)
        {
            this.Id = Item.Id;
            this.Count = Item.Count;
            Define = DataManager.Instance.Items[Item.Id];
        }
        public override string ToString()
        {
            return string.Format("ID:{0},   Count:{1}", this.Id, this.Count);
        }
    }
}
