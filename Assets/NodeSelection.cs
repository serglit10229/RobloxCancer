using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NodeSelection : MonoBehaviour {

    public GameObject last;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        RaycastHit hit;

        if (Input.GetMouseButtonDown(0))
        {
            Debug.Log("Mouse");
            if (Physics.Raycast(transform.position, transform.forward, out hit, Mathf.Infinity))
            {
                Debug.Log("Hit");
                if (last == null)
                {
                    last = hit.transform.gameObject;
                    hit.transform.GetComponent<NodeController>().selected = true;
                }
                if (last != hit.transform)
                {
                    last.GetComponent<NodeController>().selected = false;
                    hit.transform.GetComponent<NodeController>().selected = true;
                    last = hit.transform.gameObject;
                }
                else
                {
                    hit.transform.GetComponent<NodeController>().selected = true;
                }
            }
        }
    }
}
