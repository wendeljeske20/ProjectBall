using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    public GameObject cameraPivot;
    public GameObject camera;
    public int jumpForce;
    int jumpCount = 2;
    public int speed;
    public int boostForce;
    public int maxSpeed;
    public Vector2 camAngle;
    Vector2 input;
    Vector3 camF, camR;

    Rigidbody rb;

    private void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    void Update()
    {

        MovementControls();
        CameraControls();

        if (Input.GetButtonDown("Boost"))
        {
            Boost();
        }
        if (Input.GetButtonDown("Jump") && jumpCount > 0)
        {
            Jump();
        }
    }

    void Boost()
    {
        rb.AddForce((camF * input.y + camR * input.x) * boostForce);
    }

    void Jump()
    {
        jumpCount--;
        rb.AddForce(Vector3.up * jumpForce);

    }

    void CameraControls()
    {
        camAngle.x += Input.GetAxis("Mouse X") * Time.deltaTime * 180;
        camAngle.y += Input.GetAxis("Mouse Y") * Time.deltaTime * 180;

        camAngle.y = Mathf.Clamp(camAngle.y, -5, 5);
        cameraPivot.transform.rotation = Quaternion.Euler(camAngle.y, camAngle.x, 0);
        cameraPivot.transform.position = transform.position;
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
        rb.AddForce((camF * input.y + camR * input.x) * speed);
        if (rb.velocity.magnitude > maxSpeed)
        {
            rb.velocity = rb.velocity.normalized * maxSpeed;

        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        jumpCount = 2;
    }


}
