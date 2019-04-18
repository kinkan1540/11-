using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using UnityEngine.UI;

public class CollectBattery : MonoBehaviour
{
    public Text Batterytext;
    public int Ready;
    public GameObject ReadyText;
    public GameObject jumpPointobj;
    private bool isJumpOut;
    private int batterycount;
    public Timer timer;
    public GameObject constellationCam;
    public GameObject constellationCam2;
    private void Start()
    {
        batterycount = 0;
        isJumpOut = false;
    }

    private void Update()
    {
        if(batterycount>Ready)
        {
            ReadyText.SetActive(true);
            jumpPointobj.GetComponent<JumpPoint>().SetReady();
        }

        if (timer.TimerEnd())
        {
            ReadyText.GetComponent<Text>().text = "ジャンプ！";
            GetComponent<Rigidbody>().AddForce(transform.up * 1000f);
            GetComponent<PlayerGravityBody>().attractorPlanet = null;
            GetComponent<Jumping>().StartJumping();
            isJumpOut = true;
                constellationCam.SetActive(false);
                constellationCam2.SetActive(true);
            
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        //if (other.gameObject.CompareTag("Battery"))
        //{
        //    batterycount++;
        //    Debug.Log("Get buttery!");
        //    Destroy(other.gameObject);
        //    Batterytext.text = "集めたエネルギ：" + batterycount + "個";
        //}
        
    }
    private void OnTriggerStay(Collider other)
    {
        //if (other.gameObject.CompareTag("JumpPoint"))
        //{
        //    if (jumpPointobj.GetComponent<JumpPoint>().readyToJump && Input.GetButtonDown("Jump"))
        //    {
        //        ReadyText.GetComponent<Text>().text = "ジャンプ！";
        //        //GetComponent<Rigidbody>().AddForce(transform.up * 1000f);
        //        GetComponent<PlayerGravityBody>().attractorPlanet = null;
        //        GetComponent<Jumping>().StartJumping();
        //        isJumpOut = true;
        //    }
        //}

    }

    public bool IsJumpOut()
    {
        return isJumpOut;
    }
}
