using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

namespace Assets.Scripts
{
    class CameraContorol:MonoBehaviour
    {
        [SerializeField] private Transform player;
        [SerializeField] private float distance;
        [SerializeField] private float sensevity = 5;
        private Ray ray;
        // Start is called before the first frame update
        void Start()
        {
            Cursor.lockState = CursorLockMode.Locked;
        }

        // Update is called once per frame
        void Update()
        {
            float x = Input.GetAxis("Mouse X");
            float y = Input.GetAxis("Mouse Y");
            Vector3 localEuler = transform.localEulerAngles;
            localEuler.x += -y * sensevity;
            localEuler.y += x * sensevity;
            transform.localEulerAngles = localEuler;
            transform.position = player.position+ray.direction; 
        }
    }
}
