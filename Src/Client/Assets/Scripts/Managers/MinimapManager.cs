using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UnityEngine;
using Models;

namespace Managers
{
    class MinimapManager:Singleton<MinimapManager>
    {
        public UIMiniMap miniMap;

        private Collider minimapBoundingBox;
        public Collider MinimapBoundingBox
        {
            get
            {
                { return minimapBoundingBox; }
            }
        }

        public Transform PlayerTransform
        {
            get
            {
                if (User.Instance.CurrentCharacterObject == null)
                    return null;
                return User.Instance.CurrentCharacterObject.transform;
            }
        }

        public Sprite LoadCurrentMinimap()
        {
            return Resloader.Load<Sprite>("UI/Minimap/"+User.Instance.CurrentMapData.MiniMap);
        }

        public void UpdateMinimap(Collider MinimapBoundingBox)
        {
            this.minimapBoundingBox = MinimapBoundingBox;
            if (this.miniMap != null)
                this.miniMap.UpdateMinimap();
        }
    }
}
