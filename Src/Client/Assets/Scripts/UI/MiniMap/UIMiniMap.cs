using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Models;
using Managers;
using System.Threading;

public class UIMiniMap : MonoSingleton<UIMiniMap> {
    public Collider minimapBoundingBox;
    public Image Minimap;
    public Image Arrow;
    public Text MapName;

    private Transform playerTransform;
	// Use this for initialization
	void Start () {
        MinimapManager.Instance.miniMap = this;
        this.UpdateMinimap();
	}

     public void UpdateMinimap()
    {
        this.MapName.text = User.Instance.CurrentMapData.Name;
        this.Minimap.overrideSprite = MinimapManager.Instance.LoadCurrentMinimap();

        this.Minimap.SetNativeSize();
        this.Minimap.transform.localPosition = Vector3.zero;
        this.minimapBoundingBox = MinimapManager.Instance.MinimapBoundingBox;
        this.playerTransform = null;
    }

    // Update is called once per frame
    void Update () {
        if(playerTransform == null)
        {
            playerTransform = MinimapManager.Instance.PlayerTransform;
        }
        if (playerTransform == null || minimapBoundingBox == null)   return;
        float realWidth = minimapBoundingBox.bounds.size.x;
        float realHeight = minimapBoundingBox.bounds.size.z;
      
        float realX = this.playerTransform.position.x - minimapBoundingBox.bounds.min.x;
        float realY = this.playerTransform.position.z - minimapBoundingBox.bounds.min.z;

        float pivotX = realX / realWidth;
        float pivotY = realY / realHeight;

        this.Minimap.rectTransform.pivot = new Vector2(pivotX, pivotY);
        this.Minimap.rectTransform.localPosition = Vector2.zero;

        this.Arrow.transform.eulerAngles = new Vector3(0,0, -this.playerTransform.eulerAngles.y);
    }
}
