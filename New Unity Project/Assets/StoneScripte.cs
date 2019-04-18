using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class StoneScripte : MonoBehaviour
{
    public GameObject myObject;
    public Text score;
    public GameObject planet;
    private bool invincible=false;
    public GameObject Clon;

    private Vector3 moveDirection;
    private Vector3 nextPosition;
    int moveSpeed = 30;
    bool isEnd = false;
    private GameObject hitObj;
    // Start is called before the first frame update
    void Start()
    {
        invincible = false;
        isEnd = false;
    }

    // Update is called once per frame
    void Update()
    {

    }
    private void FixedUpdate()
    {
        if (isEnd)
        {
            Dead();
        }
    }
    private void OnTriggerEnter(Collider other)
    {       
        GameObject obj = other.gameObject;
        if(obj==hitObj)
        {
            Debug.Log("s");
        }

        Debug.Log(obj);
        if (!invincible)
        {
            if (obj.name == "crater(Clone)")
            {

                isEnd = true;
                hitObj = obj;
            }
        }
    }
    private void Dead()
    {
        NewCube(5);     
        score.GetComponent<ScoreScript>().ScoreUp(10);    
        isEnd = false;
        Destroy(myObject);
    }
    private void NewCube(int num)
    {

        GameObject cube = Clon;
        Vector3 vec = (transform.position - planet.transform.position).normalized;

        Quaternion rot = cube.transform.rotation;
        rot = transform.rotation;
        cube.transform.up = vec;
        cube.transform.position = transform.position;
        cube.GetComponent<StoneScripte>().HItObj(hitObj);
        cube.transform.position += cube.transform.forward * -3;
        cube.GetComponent<StoneScripte>().SetPlanet(planet);
        cube.GetComponent<StoneScripte>().SetScore(score);
       /// cube.GetComponent<StoneScripte>().InvicibleOn();
        Instantiate(cube,cube.transform.position, cube.transform.rotation);
    }
    private void InvicibleOn()
    {
        invincible = true;
    }
    private void InvicibleFalse()
    {
        invincible = false;
    }

    public void SetScore(Text score)
    {
        this.score = score;
    }
    public void SetPlanet(GameObject planet)
    {
       this.planet=planet;
    }
    public void HItObj(GameObject obj)
    {
        hitObj = obj;
    }

}
