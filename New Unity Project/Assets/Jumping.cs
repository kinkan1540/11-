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
    private float pointTimer;

    // Start is called before the first frame update
    void Start()
    {
        startJumping = false;
        currectTarget = 0;
    }

    // Update is called once per frame
    void Update()
    {
        if(startJumping)
        {
            if ((transform.position - targetPlanets[currectTarget].position).sqrMagnitude>=1)
            {
                Vector3 pos = Vector3.MoveTowards(transform.position, targetPlanets[currectTarget].position, startJumpSpeed * Time.deltaTime);
                GetComponent<Rigidbody>().MovePosition(pos);
            }
            else
            {
                currectTarget = (currectTarget + 1) % targetPlanets.Length;
            }
            startJumpSpeed -= energyLost * Time.deltaTime;
            startJumpSpeed = Mathf.Max(startJumpSpeed, 0);

            pointTimer += (pointTimer + Time.deltaTime) % pointTime;
            if (pointTime < 0.1)
            {
                Instantiate(LinePrefab, transform.position, Quaternion.identity);
            }

        }
    }

    public void StartJumping()
    {
        targetPlanets = targetConstellation.GetComponent<SetConstellation>().planets;
        GetComponent<Rigidbody>().velocity = Vector3.zero;
        startJumping = true;

        constellationCam.SetActive(true);
        GameObject.FindGameObjectWithTag("MainCamera").SetActive(false);
    }
}
