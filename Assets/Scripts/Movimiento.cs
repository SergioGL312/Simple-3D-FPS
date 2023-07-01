using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movimiento : MonoBehaviour
{
    /*float velocidad = 10f;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        float x = Input.GetAxis("Horizontal");
        float y = Input.GetAxis("Vertical");
        float rotacion = Input.GetAxis("Mouse X");
        transform.Translate(new Vector3(x, 0, y) * Time.deltaTime * velocidad);
        transform.Rotate(new Vector3(0, rotacion * velocidad, 0));

        if (Input.GetKeyDown(KeyCode.Space))
        {
            Rigidbody fisica = GetComponent<Rigidbody>();
            fisica.AddForce(new Vector3(0, 8, 0), ForceMode.Impulse);
        }
    }*/
    public Transform cam;

    [Space]
    [Space]

    [Header("Movement")]
    //Move
    public float speed;

    [Space]
    [Space]

    [Header("Rotation")]
    public float xSensitivity;
    public float ySensitivity;

    private float pitch;

    private Rigidbody rb;

    private void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    private void FixedUpdate()
    {
        Movement();
        Rotation();
        if (Input.GetKeyDown(KeyCode.Space))
        {
            Jump();
        }

    }

    void Movement()
    {
        float x = Input.GetAxis("Horizontal");
        float z = Input.GetAxis("Vertical");

        Vector3 movZ = transform.forward * z;
        Vector3 movX = transform.right * x;
        Vector3 mov = (movZ + movX).normalized * speed;

        rb.MovePosition(rb.position + mov * Time.fixedDeltaTime);
    }

    void Rotation()
    {
        // X
        float yRot = Input.GetAxis("Mouse X") * xSensitivity;
        Vector3 rot = new Vector3(0f, yRot, 0f);
        rb.MoveRotation(rb.rotation * Quaternion.Euler(rot));

        // Y
        pitch -= Input.GetAxis("Mouse Y") * ySensitivity;
        pitch = Mathf.Clamp(pitch, -85, 85);

        Vector3 camRot = new Vector3(pitch, 0f, 0f);
        cam.localEulerAngles = camRot;
    }

    void Jump()
    {
        float jumpForce = 8f;
        rb.AddForce(Vector3.up * jumpForce, ForceMode.Impulse);
    }

}
