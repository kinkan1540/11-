using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraControl : MonoBehaviour
{
    public GameObject player;
    public GameObject mainCamera;
    private Vector3 prePosition;
    private Vector3 posi;
    private Vector3 offset;
    private Vector3 camPosi;
    private Vector3 playPosi;
    // Start is called before the first frame update
    void Start()
    {

    }
    // Update is called once per frame
    void Update()
    {
        if (player == null)
            return;

        MovePosition();
    }
    private void MovePosition()
    {       
        Vector3 pos = transform.position;

        pos.y += 4;
        transform.position = pos;

        mainCamera.transform.LookAt(player.transform);
    }
}
