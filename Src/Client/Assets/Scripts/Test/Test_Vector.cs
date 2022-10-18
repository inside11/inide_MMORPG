using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Test_Vector : MonoBehaviour {
    public Transform transform1;
    public Transform transform2;
    public Transform transform3;
    // Use this for initialization
    void Start () {
      
    }
	
	// Update is called once per frame
	void Update () {
        float angle = Vector3.Angle(transform1.position - transform2.position, transform1.position - transform3.position);
        print("angle = " + angle);
        print("Mathf.Sin(angle*Mathf.Deg2Rad(2π/360))=" + Mathf.Sin(angle* Mathf.Deg2Rad));
       
        float minDistance = Vector3.Distance(transform1.position, transform2.position) * Mathf.Sin(angle* Mathf.Deg2Rad);
        print("Distance = " + Vector3.Distance(transform1.position, transform2.position));
        print("minDistance = " + minDistance);
    }
}
