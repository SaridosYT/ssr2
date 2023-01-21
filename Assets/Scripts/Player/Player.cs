using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Player : MonoBehaviour
{
    [Header("References")]
    public Rigidbody rb;
    public Transform head;
    public Camera caamera;



    [Header("Configurations")]
    public float walkSpeed;
    public float runSpeed;
    public float jumpSpeed;
    public float InpactThreshold;

    [Header("Camera Effects")]
    public float baseCameraFov = 60f;
    public float baseCameraHeight = .85f;

    public float walkBobbingRate = .75f;
    public float runBobbingRate = 1f;
    public float maxWalkBobbingOffset = .2f;
    public float maxRunBobbingOffset = .3f;

    public float cameraShakeThreshold = 10f;
    [Range(0f, 0.03f)] public float cameraShakeRate = .015f;
    public float maxVerticalFallShakeAngle = 40f;
    public float maxHorizontalFallShakeAngle = 40f;

    [Header("Runtime")]
    Vector3 newVelocity;
    bool isGrounded = false;
    bool isJumping = false;
    float vyChase;

    //[Header("Audio")]
   // public AudioSource AudioWalk;
//public AudioSource AudioWind;
   // public float WindPitch;


    // Start is called before the first frame update
    void Start()
    {
        //  Hide and lock the mouse cursor
        Cursor.visible = false;
        Cursor.lockState = CursorLockMode.Locked;
    }




    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.P))
        {
            Cursor.visible = true;
            Cursor.lockState = CursorLockMode.None;
        }
        if (Input.GetKeyDown(KeyCode.B))
        {
            SceneManager.LoadScene(1);
        }
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            Application.Quit();
        }
        // Horizontal rotation
        transform.Rotate(Vector3.up * Input.GetAxis("Mouse X") * 2f);   // Adjust the multiplier for different rotation speed

        newVelocity = Vector3.up * rb.velocity.y;
        float speed = Input.GetKey(KeyCode.LeftShift) ? runSpeed : walkSpeed;
        newVelocity.x = Input.GetAxis("Horizontal") * speed;
        newVelocity.z = Input.GetAxis("Vertical") * speed;

        bool isMovingOnGround = (Input.GetAxis("Vertical") != 0f || Input.GetAxis("Horizontal") != 0f) && isGrounded;


        //  Head bob
        if (isMovingOnGround)
        {
            float bobbingRate = Input.GetKey(KeyCode.LeftShift) ? runBobbingRate : walkBobbingRate;
            float bobbingOffset = Input.GetKey(KeyCode.LeftShift) ? maxRunBobbingOffset : maxWalkBobbingOffset;
            Vector3 targetHeadPosition = Vector3.up * baseCameraHeight + Vector3.up * (Mathf.PingPong(Time.time * bobbingRate, bobbingOffset) - bobbingOffset * .5f);
            head.localPosition = Vector3.Lerp(head.localPosition, targetHeadPosition, .1f);
        }

        if (isGrounded)
        {
            if (Input.GetKeyDown(KeyCode.Space) && !isJumping)
            {
                newVelocity.y = jumpSpeed;
                isJumping = true;
            }
        }
        rb.velocity = transform.TransformDirection(newVelocity);

        //AUDIO
        //help me pls 
        // how r u readind this
        // if you get here hit me up on discord to help me with gamedav\
        //AudioWalk.enabled = isMovingOnGround;
        //AudioWalk.pitch = Input.GetKey(KeyCode.LeftShift) ? 1.75f : 1f;
        //AudioWind.enabled = true;
        //AudioWind.pitch = Mathf.Clamp(Mathf.Abs(rb.velocity.y * WindPitch), 0f, 2f) + Random.Range(-.1f, .1f);
    }

    void FixedUpdate()
    {
        //  Shoot a ray of 1 unit towards the ground
        if (Physics.Raycast(transform.position, Vector3.down, out RaycastHit hit, 1f))
        {
            isGrounded = true;
        }
        else isGrounded = false;
        vyChase = rb.velocity.y;
    }

    void LateUpdate()
    {
        // Vertical rotation
        Vector3 e = head.eulerAngles;
        e.x -= Input.GetAxis("Mouse Y") * 2f;   //  Edit the multiplier to adjust the rotate speed
        e.x = RestrictAngle(e.x, -70f, 70f);    //  This is clamped to 85 degrees. You may edit this.
        head.eulerAngles = e;
    }




    //  This will be called constantly
    void OnCollisionStay(Collision col)
    {
        if (Vector3.Dot(col.GetContact(0).normal, Vector3.up) <= .6f)
            return;

        isGrounded = true;
        isJumping = false;
    }


    void OnCollisionExit(Collision col)
    {
        isGrounded = false;
    }

    void OnCollisionEnter(Collision collision)
    {
        if (Vector3.Dot(collision.GetContact(0).normal, Vector3.up) < .5f)
        {
            if (rb.velocity.y < -5f)
            {
                rb.velocity = Vector3.up * rb.velocity.y;
                return;
            }
        }
        float accseraration = (rb.velocity.y - vyChase) / Time.fixedDeltaTime;
        float inpactforse = rb.mass * Mathf.Abs(accseraration);
        if (inpactforse >= InpactThreshold)
        {
            //Debug.Log("you suck");
        }
    }


    //  A helper function
    //  Clamp the vertical head rotation (prevent bending backwards)
    public static float RestrictAngle(float angle, float angleMin, float angleMax)
    {
        if (angle > 180)
            angle -= 360;
        else if (angle < -180)
            angle += 360;

        if (angle > angleMax)
            angle = angleMax;
        if (angle < angleMin)
            angle = angleMin;

        return angle;
    }
}