using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    Vector3 homePos;
    public float moveSpeed = 5f;
    public float rotateAngle = 1.0f;
    public float rotationSpeed = 10;
    // Start is called before the first frame update
    void Start()
    {
        homePos = transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKey(KeyCode.W))
            transform.Translate(Vector3.up * moveSpeed * Time.deltaTime);

        if (Input.GetKey(KeyCode.S))
            transform.Translate(Vector3.down * moveSpeed * Time.deltaTime);

        if (Input.GetKey(KeyCode.A))
            transform.Translate(Vector3.left * moveSpeed * Time.deltaTime);

        if (Input.GetKey(KeyCode.D))
            transform.Translate(Vector3.right * moveSpeed * Time.deltaTime);

        if (Input.GetKey(KeyCode.Q))
            transform.Translate(Vector3.forward * moveSpeed * Time.deltaTime);

        if (Input.GetKey(KeyCode.E))
            transform.Translate(-Vector3.forward * moveSpeed * Time.deltaTime);

        if (Input.GetKey(KeyCode.X))
        {
            Vector3 rotation = transform.eulerAngles;

            rotation.x += Input.GetAxis("Horizontal") * rotationSpeed * 10.0f; // Standart Left-/Right Arrows and A & D Keys

            transform.eulerAngles = rotation;
        }

        if (Input.GetKey(KeyCode.Y))
        {
            Vector3 rotation = transform.eulerAngles;

            rotation.y += Input.GetAxis("Vertical") * rotationSpeed * 10.0f; // Standart Left-/Right Arrows and A & D Keys

            transform.eulerAngles = rotation;
        }

        if (Input.GetKey(KeyCode.Space))
        {
            System.Threading.Thread.Sleep(500);
            Debug.Log("space bar pressed");
        }
            


    }
}
