using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

namespace Assets.Scripts
{
    class CameraContoroll:MonoBehaviour
    {
        [SerializeField] private Transform player;
        [SerializeField] private float distance;
        [SerializeField] private float sensevity = 5;
        private Ray ray;
        private void Start()
        {

            Cursor.lockState = CursorLockMode.Locked;
            Ray ray = new Ray(player.position, -transform.forward);
        }

        private void Update()
        {
            float x = Input.GetAxis("Mouse X");
            float y = Input.GetAxis("Mouse Y");
            Vector3 localEuler = transform.localEulerAngles;
            localEuler.x += -y * sensevity;
            localEuler.y += x * sensevity;
            transform.localEulerAngles = localEuler;
        }
    }
}
