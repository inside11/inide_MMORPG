using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Titles : MonoBehaviour {
    public GameObject[] titles;
    private int currentCharacter=0;
    public int CurrentCharacter
    {
        get
        {
            return currentCharacter;
        }
        set
        {
            currentCharacter = value;
            this.UpdateTitle();
        }
    }
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    void UpdateTitle()
    {
        for(int i=0; i<3;i++)
        {
            titles[i].SetActive(i == currentCharacter);
        }
    }
}
