using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class NodeSelection : MonoBehaviour {

    public GameObject last;
    public Camera cam;

    public string team = "team1";

    private int fingerID = -1;

    public List<GameObject> t = new List<GameObject>();

    private void Awake()
    {
    #if !UNITY_EDITOR
        fingerID = 0; 
    #endif
    
    }
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
        if (EventSystem.current.IsPointerOverGameObject(fingerID) == false)
        {
            RaycastHit hit;

            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            if (Physics.Raycast(ray, out hit))
            {
                if (hit.transform.GetComponent<NodeController>() != null)
                {
                    if (last.GetComponent<NodeController>().Targets.Contains(hit.transform.gameObject))
                    {
                        Debug.Log(hit.transform.position);
                        List<GameObject> t = new List<GameObject>();
                        t.Add(hit.transform.gameObject);
                        last.transform.GetComponent<NodeController>().Spawn(t);
                    }
                    else
                    {

                        foreach (GameObject g in last.GetComponent<NodeController>().Targets)
                        {
                            if (g == hit.transform.gameObject)
                            {
                                t.Add(g);
                            }
                            else
                            {
                                foreach (GameObject g1 in g.GetComponent<NodeController>().Targets)
                                {
                                    if (g1 == hit.transform.gameObject)
                                    {
                                        t.Add(g1);
                                    }
                                    else
                                    {
                                        foreach (GameObject g2 in g1.GetComponent<NodeController>().Targets)
                                        {
                                            if (g2 == hit.transform.gameObject)
                                            {
                                                t.Add(g2);
                                            }
                                            else
                                            {
                                                foreach (GameObject g3 in g2.GetComponent<NodeController>().Targets)
                                                {
                                                    if (g3 == hit.transform.gameObject)
                                                    {
                                                        t.Add(g3);
                                                    }
                                                    else
                                                    {
                                                        foreach (GameObject g4 in g3.GetComponent<NodeController>().Targets)
                                                        {
                                                            if (g4 == hit.transform.gameObject)
                                                            {
                                                                t.Add(g4);
                                                            }
                                                            else
                                                            {
                                                                foreach (GameObject g5 in g4.GetComponent<NodeController>().Targets)
                                                                {
                                                                    if (g5 == hit.transform.gameObject)
                                                                    {
                                                                        t.Add(g5);
                                                                    }
                                                                    else
                                                                    {
                                                                        foreach (GameObject g6 in g5.GetComponent<NodeController>().Targets)
                                                                        {
                                                                            if (g6 == hit.transform.gameObject)
                                                                            {
                                                                                t.Add(g6);
                                                                            }
                                                                            else
                                                                            {
                                                                                foreach (GameObject g7 in g6.GetComponent<NodeController>().Targets)
                                                                                {
                                                                                    if (g7 == hit.transform.gameObject)
                                                                                    {
                                                                                        t.Add(g7);
                                                                                    }
                                                                                    else
                                                                                    {
                                                                                        foreach (GameObject g8 in g7.GetComponent<NodeController>().Targets)
                                                                                        {
                                                                                            if (g8 == hit.transform.gameObject)
                                                                                            {
                                                                                                t.Add(g8);
                                                                                            }
                                                                                            else
                                                                                            {
                                                                                                foreach (GameObject g9 in g8.GetComponent<NodeController>().Targets)
                                                                                                {
                                                                                                    if (g9 == hit.transform.gameObject)
                                                                                                    {
                                                                                                        t.Add(g9);
                                                                                                    }
                                                                                                    else
                                                                                                    {
                                                                                                        foreach (GameObject g10 in g9.GetComponent<NodeController>().Targets)
                                                                                                        {
                                                                                                            if (g10 == hit.transform.gameObject)
                                                                                                            {
                                                                                                                t.Add(g10);
                                                                                                            }
                                                                                                            else
                                                                                                            {
                                                                                                                Debug.Log("No Route");
                                                                                                            }
                                                                                                        }
                                                                                                    }
                                                                                                }
                                                                                            }
                                                                                        }
                                                                                    }
                                                                                }
                                                                            }
                                                                        }
                                                                    }
                                                                }
                                                            }
                                                        }
                                                    }
                                                }
                                            }
                                        }
                                    }
                                }
                            }
                        }
                    }
                }
            }
        }
    }

    void Ray() {
        if (EventSystem.current.IsPointerOverGameObject(fingerID) == false)
        {
            RaycastHit hit;
            
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            if (Physics.Raycast(ray, out hit))
            {
                if (last == null)
                {
                    last = hit.transform.gameObject;
                    if (hit.transform.GetComponent<NodeController>().team == team)
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
                    if (hit.transform.GetComponent<NodeController>().team == team)
                        hit.transform.GetComponent<NodeController>().selected = true;
                    last = hit.transform.gameObject;
                }
                else
                {
                    if(hit.transform.GetComponent<NodeController>().team == team)
                        hit.transform.GetComponent<NodeController>().selected = true;
                }
            }
        }
        
    }
}