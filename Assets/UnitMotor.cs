using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using System;
using UnityEngine;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;


public class UnitMotor : MonoBehaviour {

    public float speed = 2;
    public List<Vector3> target;
    public List<GameObject> targetgm;


    public Text text;
    int score = 0;

    public string team;


    // Use this for initialization
    void Start () {
        foreach (GameObject g in targetgm)
        {
            if (!target.Contains(g.transform.position))
            {
                target.Add(g.transform.position);
            }
        }
	}
	
	// Update is called once per frame
	void Update () {
        float step = speed * Time.deltaTime;
        Vector3 relativePos = target[0] - transform.position;
        Quaternion rotation = Quaternion.LookRotation(relativePos);
        transform.position = Vector3.MoveTowards(transform.position, new Vector3(target[0].x,transform.position.y,target[0].z), step);
        score = int.Parse(text.text);

        if (transform.position == targetgm.Last().transform.position)
        {
            if (targetgm[0].GetComponent<NodeController>().team == team)
            {
                targetgm[0].GetComponent<NodeController>().score += score;
                target.Remove(target[0]);
                targetgm.Remove(targetgm[0]);
                if(targetgm.Count == 0)
                    Destroy(gameObject);
            }

            if (targetgm[0].GetComponent<NodeController>().team != team)
            {
                targetgm[0].GetComponent<NodeController>().battle = true;
                targetgm[0].GetComponent<NodeController>().opponentScore = score;
                targetgm[0].GetComponent<NodeController>().opponentTeam = team;
                target.Remove(target[0]);
                targetgm.Remove(targetgm[0]);
                if (targetgm.Count == 0)
                    Destroy(gameObject);
            }
        }
    }
}
