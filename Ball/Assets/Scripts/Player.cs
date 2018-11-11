using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    public GameObject cameraPivot;
    public GameObject camera;
    public Vector3 respawnPosition;

    //public bool grounded;
    public int jumpForce;
    int jumpCount = 2;
    public int jumpCooldown = 20;
    int nextJumpCooldown;
    public int speed;
    public int boostForce;
    public int maxSpeed;


    public Vector3 camAngle;
    public int camAngleLimit;
    public Vector2 input;
    Vector3 camF, camR, camU;



    Rigidbody rb;

    private void Start()
    {
        //Physics.gravity = new Vector3(0,-20,0);
        rb = GetComponent<Rigidbody>();
        respawnPosition = transform.position;
    }

    void Update()
    {

        MovementControls();
        CameraControls();

        nextJumpCooldown++;

        if (Input.GetButtonDown("Boost"))
        {
            Boost();
        }
        if (Input.GetButtonDown("Jump") && jumpCount > 0 && nextJumpCooldown >= jumpCooldown)
        {
            Jump();
        }
        if (Input.GetButtonDown("Respawn"))
        {
            Respawn();
        }
    }

    void Respawn()
    {
        transform.position = respawnPosition;
        rb.velocity = Vector3.zero;
        rb.angularVelocity = Vector3.zero;
        
    }

    void Boost()
    {
        Vector2 force = input;
        force = force.normalized;
        rb.AddForce((camF * force.y + camR * force.x) * boostForce);
    }

    void Jump()
    {
        jumpCount--;
        nextJumpCooldown = 0;
        rb.AddForce(Vector3.up * jumpForce);

    }

    void CameraControls()
    {
        camAngle.x += Input.GetAxis("Mouse X") * Time.deltaTime * 180;
        camAngle.y += Input.GetAxis("Mouse Y") * Time.deltaTime * 180;

        camAngle.y = Mathf.Clamp(camAngle.y, -camAngleLimit, camAngleLimit);
        cameraPivot.transform.rotation = Quaternion.Euler(camAngle.y, camAngle.x, camAngle.z);
        cameraPivot.transform.position = transform.position;


    }

    void OnCollisionStay(Collision collision)
    {
        foreach (ContactPoint contact in collision.contacts)
        {
            print(contact.thisCollider.name + " hit " + contact.otherCollider.name);


            //Debug.DrawRay(contact.point, contact.normal, Color.blue);
            Debug.DrawLine(transform.position, contact.point - contact.normal, Color.red);
            Vector3 dir = contact.point - contact.normal;
            //camAngle.z = 90;
            Debug.DrawLine(transform.position, dir);

            // camAngle.z = Vector3.Angle(collision.transform.right, dir);
        }


    }

    void MovementControls()
    {

        input = new Vector2(Input.GetAxis("Horizontal"), Input.GetAxis("Vertical"));
        input = Vector2.ClampMagnitude(input, 1);

        camF = camera.transform.forward;
        camR = camera.transform.right;
        camF.y = 0;
        camR.y = 0;
        camF = camF.normalized;
        camR = camR.normalized;


        if (rb.velocity.magnitude <= maxSpeed)
        {
            if (IsGrounded())
            {
                jumpCount = 2;
                rb.AddForce((camF * input.y + camR * input.x) * speed);
            }
            else
            {
                rb.AddForce((camF * input.y + camR * input.x) * (speed / 2));
            }

        }
    }

    bool IsGrounded()
    {
        Collider collider = GetComponent<Collider>();
        float distToGround = collider.bounds.extents.y;

        return Physics.Raycast(transform.position, -Vector3.up, distToGround + 0.1f);
    }



}
