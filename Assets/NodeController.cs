using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;

public class NodeController : MonoBehaviour {

    public bool selected = false;
    public GameObject Unit;
    public List<GameObject> Targets;
    public int score = 10;
    public Text textObject;
    public float interval = 1;

    public bool hasFactory = false;
    public bool hasReactor = false;

    public GameObject UI;
    public float time = 0;
    public float boostNum = 0;

        //Multiplayer
    public bool team1 = false;
    public bool team2 = false;
    //public bool team3 = false;
    //public bool Idle = true;

    public string team;
    public bool battle = false;
    public int opponentScore = 0;
    public string opponentTeam;

    public Color team1Color = Color.blue;
    public Color team2Color = Color.green;

    public TeamScore scoreUI;
    //public Color team3Color = Color.red;


    // Use this for initialization
    void Start () {
        UI = gameObject.transform.GetChild(0).GetChild(1).gameObject;
        UI.GetComponent<UIManager>().node = gameObject;
        scoreUI = Object.FindObjectOfType<TeamScore>();
        if (team1 == true)
        {
            team = "team1";
        }
        if (team2 == true)
        {
            team = "team2";
        }

        
        if (team == "team1")
        {
            scoreUI.t1 += score;
        }
        if (team == "team2")
        {
            scoreUI.t2 += score;
        }

    }

    // Update is called once per frame
    void Update()
    {
        /* 
        if(Idle == true)
        {
            team1 = false;
            team2 = false;
            team3 = false;
        }
        
        if(team1 == true || team2 == true || team3 == true)
        {
            Idle = false;
        }
        */
        
        if (selected == true)
        {
            Renderer rend = GetComponent<Renderer>();
            rend.material.shader = Shader.Find("Specular");
            rend.material.SetColor("_Color", Color.white);
            if (!UI.gameObject.activeSelf)
                UI.gameObject.SetActive(true);
        }
        else
        {
            Renderer rend = GetComponent<Renderer>();
            rend.material.shader = Shader.Find("Specular");
            
            if(team1 == true)
                rend.material.SetColor("_Color", team1Color);
            if(team2 == true)
                rend.material.SetColor("_Color", team2Color);
            if(team1 == false && team2 == false)
                rend.material.SetColor("_Color", Color.red);
            if (UI.gameObject.activeSelf)
                UI.gameObject.SetActive(false);
        }

        textObject.text = score.ToString();




        if (battle == true)
        {
            if (opponentScore > 0 || score > 0)
            {
                time += Time.deltaTime;
                if (time >= 1)
                {
                    score--;
                    opponentScore--;

                    scoreUI.t1--;
                    scoreUI.t2--;

                    time = 0;
                }
            }

            if (opponentScore == 0)
            {
                battle = false;
            }
            if (score == 0)
            {
                score = opponentScore;
                if (opponentTeam == "Team1")
                {
                    team2 = false;
                    team1 = true;
                }
                if (opponentTeam == "Team2")
                {
                    team2 = true;
                    team1 = false;
                }
                battle = false;
            }
            textObject.text = score.ToString() + "v" + opponentScore.ToString();
        }
        else
        {
            textObject.text = score.ToString();
            if (hasFactory == true)
            {
                time += Time.deltaTime;
                if (time >= interval)
                {
                    score++;
                    time = 0;
                    if (team == "team1")
                    {
                        scoreUI.t1++;
                    }
                    if (team == "team2")
                    {
                        scoreUI.t2 ++;
                    }
                }
            }
        }
    }

    public void Spawn(GameObject target)
    {
        if (Targets.Contains(target) && score > 0)
        {
            Debug.Log("FUCK");
            Vector3 offset = new Vector3(0, 0.5f, 0);
            Vector3 relativePos = target.transform.position - transform.position;
            Quaternion rotation = Quaternion.LookRotation(relativePos);
            GameObject spawnedUnit = Instantiate(Unit, transform.position + offset, rotation);
            spawnedUnit.GetComponent<UnitMotor>().target = target.transform.position;
            spawnedUnit.GetComponent<UnitMotor>().targetgm = target;
            spawnedUnit.GetComponent<UnitMotor>().team = team;
            spawnedUnit.GetComponent<UnitMotor>().text.text = score.ToString();
            score = 0;
        }
    }

    void Generate()
    {
        score += 1;
    }
}
