using Entities;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIWorldElementManager :MonoSingleton<UIWorldElementManager> {
    public GameObject nameBarPrefab;

    private Dictionary<Transform, GameObject> elements = new Dictionary<Transform, GameObject>();

    protected override void OnStart()
    {
        nameBarPrefab.SetActive(false);
    }

    public void AddCharacterNameBar(Transform owner, Character character)
    {
        GameObject goNamebar =  Instantiate(nameBarPrefab,this.transform);
        goNamebar.name = "NamerBar" + character.Info.Id;
        goNamebar.GetComponent<UIWorldElement>().owner = owner;
        goNamebar.GetComponent<UINameBar>().character = character;
        goNamebar.SetActive(true);
        this.elements[owner] = goNamebar;
    }

    public void RemoveCharacterNameBar(Transform owner)
    {
        if(this.elements.ContainsKey(owner))
        {
            Destroy(this.elements[owner]);
                this.elements.Remove(owner);
        }
        
    }
}
