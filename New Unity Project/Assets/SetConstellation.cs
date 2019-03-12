using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SetConstellation : MonoBehaviour
{

    public Transform[] planets;

    public Transform startPlanetTrs;
    // Start is called before the first frame update

    public float totallength;

    private void Awake()
    {
        totallength += (startPlanetTrs.position - planets[0].position).magnitude;

        for (int i = 0; i < planets.Length-1; i++)
        {
            totallength += (planets[0].position - planets[1].position).magnitude;
        }
        Debug.Log(totallength);
    }
    public float GetTotalLength()
    {
        return totallength;
    }

}
