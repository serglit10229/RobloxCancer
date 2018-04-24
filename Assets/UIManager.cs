using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIManager : MonoBehaviour {

    public GameObject node;

    public GameObject btn1;
    public GameObject btn2;
    public GameObject btn3;
    public GameObject btn4;
    public GameObject image;
    public GameObject panel;

    Vector3 offset = new Vector3(0,0.5f,0);

    public GameObject fn1;

	void Update () {
        if (node == null)
        {
            btn1.SetActive(false);
            btn2.SetActive(false);
            btn3.SetActive(false);
            btn4.SetActive(false);
            image.SetActive(false);
            panel.SetActive(false);
        }
        else
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
        Instantiate(fn1, node.transform.position + offset, Quaternion.identity);
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
