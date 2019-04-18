using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BlockScript : MonoBehaviour
{
    private Vector3 posi;
    // Start is called before the first frame update
    void Start()
    {
      
        
        posi += transform.position;
        posi += GetComponent<BoxCollider>().center + new Vector3(0, 0.5f, 0); ;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public Vector3 GetPosition()
    {

        return posi;
    }
}
