using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovementScript : MonoBehaviour {

    public float moveSpeed;
    public bool allowUpDown;

    public int HpTimer;
    public int HpDown;
    private int HpSetTimer;


    public int hitCount;
    public float jumpForce;
    public float jumpDown;

    private Vector3 moveDirection;
    private Rigidbody rb;

    public Animator playerAnimator;
    public GameObject planet;

    public new GameObject  camera;
    public GameObject camera2;
    public GameObject player;

    float inputHorizontal;
    float inputvertcal;

    private GameObject hitobj;
    public Timer timer;

    public GameObject crater;
    public GameObject LinePrefab;
    public float line;
    private bool hitCube1 = false,hitCube2=false;

    private bool isJumping, jumpOne = false, jumptwo = false, jumpthree = false;
    private void Start()
    {
        rb = GetComponent<Rigidbody>();
        isJumping = false;
        line = 0;
        HpSetTimer = HpTimer;
        transform.position = new Vector3(transform.position.x,(planet.transform.localScale.y), transform.position.z);
    }
    
    private void Move()
    {
        moveDirection = new Vector3(0, 0, 1).normalized;
        MoveInput();
    }

    private void MoveInput()
    {
        if (!hitCube1)
        {
            if (Input.GetKey(KeyCode.LeftArrow))
            {
                line-=0.5f;
            }
        }
        if (!hitCube2)
        {
            if (Input.GetKey(KeyCode.RightArrow))
            {
                line+=0.5f;
            }
        }
    }
    private void HpChange()
    {
        HpTimer--;
        if(HpTimer<=0)
        {
            GetComponent<PlayerStatus>().Damage(HpDown);
            HpTimer = HpSetTimer;
        }
    }
    private void InputJump()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            jumpOne = true;
            playerAnimator.SetBool("isJumping", true);
        }
    }

    void Update()
    {
        Move();
        InputJump();
        DeathPlayer();
        HpChange();
    }
    void FixedUpdate()
    {
        float dis = Vector3.Distance(rb.position, planet.transform.position);

        PositionControl();
        Jump();
        JumpFall();
    }
    void DeathPlayer()
    {

        if (hitCount <= 0||GetComponent<PlayerStatus>().GetHp()<=0)
        {
            timer.PlayerDaed();
            camera.SetActive(false);
            camera2.SetActive(true);
            Destroy(player);
        }
    }
    void PositionControl()
    {
        Vector3 posi = transform.position;
        posi = rb.position + transform.TransformDirection(moveDirection) * moveSpeed * Time.deltaTime;
        posi.x = 0;
        transform.position = posi;
    }
    void Jump()
    {
        if (isJumping && !jumpOne)
        {
            rb.AddForce(transform.up * jumpForce);
            isJumping = false;
            playerAnimator.SetBool("isJumping", false);
        }
    }
    void JumpFall()
    {
        if (jumpOne)
        {
            rb.AddForce(transform.up * -jumpDown);
            isJumping = false;
            jumptwo = false;
            jumpOne = false;
            jumpthree = true;
            playerAnimator.SetBool("isJumping", false);
        }
    }


    private void OnTriggerEnter(Collider other)
    {
        GameObject _parent = other.transform.gameObject;
        if (other.name == "crater(Clone)")
        {
            if (hitobj != null)
                return;
            hitCount--;
        }
        if (other.transform.root.name=="batterys")
        {
            Destroy(other.gameObject);
            GetComponent<PlayerStatus>().HpRecovery(10);
        }

        if (_parent.name == "Cube")
        {
            line++;
            hitCube1 = true;
        }
        if (_parent.name == "Cube (1)")
        {
            line--;
            hitCube2 = true;
        }

    }
    private void OnTriggerStay(Collider other)
    {

    }
    private void OnTriggerExit(Collider other)
    {
        GameObject _parent = other.transform.gameObject;
        if (_parent.name == "Cube")
        {
            hitCube1 = false;
        }
        if (_parent.name == "Cube (1)")
        {
            hitCube2 = false;
        }
        if(other.name == "crater(Clone)")
        {
            if (hitobj !=null)
            {
                hitobj = null;
            }
        }
    }
    void OnCollisionEnter(Collision collision)
    {
        GameObject _parent = collision.transform.gameObject;

        if (_parent.name == "Planet")
        {
            Vector3 vec = (transform.position- planet.transform.position).normalized;
            GameObject s = crater;
            Quaternion rot = s.transform.rotation;
            rot = transform.rotation;
            s.transform.up = vec;
            Instantiate(s, transform.position, s.transform.rotation);

            jumpthree = false;
            hitobj = s;
        }
        jumpOne = false;
        jumptwo = false;
        jumpthree = false;
        isJumping = true;

    }
    public float Getline()
    {
        return line;
    }

}
