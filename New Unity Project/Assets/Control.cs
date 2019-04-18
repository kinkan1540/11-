using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Control : MonoBehaviour
{
    public Transform target;
    public int distanciaMax;
    private Vector3 offset;
    private int distancia;
   private int rot;
    public GameObject target2;


    private void Start()
    {

        distancia = 1;
        
      rot = 0;

    }
    void Update()
    {
        
        rotateCameraAngle();
    }


    void jumpStart()
    {

    }
    private void rotateCameraAngle()
    {


        offset = GetComponent<Transform>().position - target.position;
        offset.Normalize();
        GetComponent<Transform>().position = (target.position + offset * distancia);
        if (distanciaMax < distancia)
            return;
        distancia += 4;

        Vector3 angle = new Vector3(0, 1, 0);
        transform.RotateAround(target.transform.position, Vector3.up, angle.x);
        transform.RotateAround(target.transform.position, Vector3.right, angle.y);



    }
}
