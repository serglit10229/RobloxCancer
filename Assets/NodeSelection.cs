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

        if (Input.GetMouseButtonDown(1) && last != null)
        {
            Attack();
        }
    }

    void Attack()
    {
        RaycastHit hit;

        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        if (Physics.Raycast(ray, out hit))
        {
            if (hit.transform.GetComponent<NodeController>() != null)
            {
                Debug.Log(hit.transform.position);
                last.transform.GetComponent<NodeController>().Spawn(hit.transform.gameObject);
            }
        }
    }

    void Ray() {

        RaycastHit hit;
        
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        if (Physics.Raycast(ray, out hit))
        {
            if (last == null)
            {
                last = hit.transform.gameObject;
                hit.transform.GetComponent<NodeController>().selected = true;
            }
            if (hit.transform.GetComponent<NodeController>() == null)
            {
                last.GetComponent<NodeController>().selected = false;
                last = null;
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
