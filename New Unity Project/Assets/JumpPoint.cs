using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JumpPoint : MonoBehaviour
{
    public Material readyMat;
    public bool readyToJump;

    // Start is called before the first frame update
    void Start()
    {
        readyToJump = false;  
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void SetReady()
    {
        GetComponent<MeshRenderer>().material = readyMat;
        readyToJump = true;
    }

    
}
