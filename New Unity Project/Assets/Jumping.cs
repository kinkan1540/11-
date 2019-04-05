using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Jumping : MonoBehaviour
{
    private bool startJumping;

    private Transform[] targetPlanets;
    private int currectTarget;
    public GameObject targetConstellation;

    
    public float startJumpSpeed;
    public float energyLost;

    

    public GameObject constellationCam;

    public GameObject LinePrefab;
    public float pointTime;
    private float pointTimer=0f;


    public float energyLevel;
    public float speedLevel;
    public float centerLevel;

    private float energyscore;
    private float speedscore;
    private float centerscore;


    // Start is called before the first frame update
    void Start()
    {
        startJumping = false;
        currectTarget = 0;
    }


    private void FixedUpdate()
    {
        if (startJumping)
        {
            if ((transform.position - targetPlanets[currectTarget].position).sqrMagnitude >= 1)
            {
                transform.LookAt(targetPlanets[currectTarget]);
                Vector3 pos = Vector3.MoveTowards(transform.position, targetPlanets[currectTarget].position, startJumpSpeed * Time.fixedDeltaTime);
                GetComponent<Rigidbody>().MovePosition(pos);
            }
            else
            {
                currectTarget = (currectTarget + 1) % targetPlanets.Length;
            }
            startJumpSpeed -= energyLost * Time.fixedDeltaTime;
            startJumpSpeed = Mathf.Max(startJumpSpeed, 0);

            if (Time.time > pointTimer && startJumpSpeed != 0)
            {
                Instantiate(LinePrefab, transform.position, Quaternion.identity);
                pointTimer += pointTime;
            }

        }

    }

    public void StartJumping()
    {

        targetPlanets = targetConstellation.GetComponent<SetConstellation>().planets;
        GetComponent<Rigidbody>().velocity = Vector3.zero;
        startJumping = true;

        pointTimer = Time.time;
        constellationCam.SetActive(true);
        GameObject.FindGameObjectWithTag("MainCamera").SetActive(false);


        SetConstellation con = targetConstellation.GetComponent<SetConstellation>();
        float total =con.GetTotalLength();

        //startJumpSpeed = Mathf.Sqrt(2 * energyLost * total);

        //startJumpSpeed = con.totalSpeed * (speedscore * speedLevel + energyscore * energyLevel + centerscore * centerLevel);
    }

    private void ScoreJudge()
    {
        
    }

    private void CenterJudge()
    {
        //Vector3 dis
    }
}
