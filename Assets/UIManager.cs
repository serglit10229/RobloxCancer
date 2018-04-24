using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIManager : MonoBehaviour {

    public List<GameObject> node;

    public GameObject btn1;
    public GameObject btn2;
    public GameObject btn3;
    public GameObject btn4;
    public GameObject image;
    public GameObject panel;

    Vector3 offset = new Vector3(0,0.5f,0);

    public GameObject fn1;

	void Update () {
        if (node.Count < 1)
        {
            btn1.SetActive(false);
            btn2.SetActive(false);
            btn3.SetActive(false);
            btn4.SetActive(false);
            image.SetActive(false);
            panel.SetActive(false);
        }
        if(node.Count > 0)
        {
            btn1.SetActive(true);
            btn2.SetActive(true);
            btn3.SetActive(true);
            btn4.SetActive(true);
            image.SetActive(true);
            panel.SetActive(true);
        }

	}

    public void Function1()
    {
        GameObject clone;
        //if(clone != null)
        //{
            clone = Instantiate(fn1, node[0].transform.position + offset, Quaternion.Euler(-90,0,0));
            clone.transform.parent = node[0];
        //}
    
    }

    public void Function2()
    {

    }

    public void Function3()
    {

    }

    public void Function4()
    {

    }
}
