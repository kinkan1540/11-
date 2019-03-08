using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlanetScript : MonoBehaviour {

    //重力　G
    public float gravity = -10;

    public void Attract(Transform playerTransform)
    {
        //重力方向の反対
        Vector3 gravityUp = (playerTransform.position - transform.position).normalized;
        //プレイヤーの上方向
        Vector3 localUp = playerTransform.up;

        //プレイヤーに重力を与える
        playerTransform.GetComponent<Rigidbody>().AddForce(gravityUp * gravity);

        //プレイヤーが表面に立つ
        Quaternion targetRotation = Quaternion.FromToRotation(localUp, gravityUp) * playerTransform.rotation;
        playerTransform.rotation = Quaternion.Slerp(playerTransform.rotation, targetRotation, 50f * Time.deltaTime);
    }
}
