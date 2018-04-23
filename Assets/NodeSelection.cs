using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NodeSelection : MonoBehaviour {

    public GameObject last;
    public Camera cam;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {

        if (Input.GetMouseButtonDown(0))
        {
            Ray();
        }
    }

    void Ray() {

        RaycastHit hit;
        Debug.Log("Ray");
        if (Physics.Raycast(cam.transform.position, cam.transform.forward, out hit, Mathf.Infinity))
        {
            Debug.Log("Hit " + hit.transform.name);
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
