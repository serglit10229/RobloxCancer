using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UnitMotor : MonoBehaviour {

    public float speed = 2;
    public Vector3 target;


	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        float step = speed * Time.deltaTime;
        target.y = transform.position.y;
        transform.position = Vector3.MoveTowards(transform.position, target, step);
    }
}
