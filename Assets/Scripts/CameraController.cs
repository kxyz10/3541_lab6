using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    Vector3 homePos;
    public float moveSpeed = 5f;
    public float rotateAngle = 30;
    public float rotationSpeed = 100;
    public GeneratePPM ppmScript;
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
            if (Input.GetKey(KeyCode.Return))
            {
                float rotation = rotateAngle * Time.deltaTime;
                transform.Rotate(0, -rotation, 0);
            }
            else
            {
                float rotation = rotateAngle * Time.deltaTime;
                transform.Rotate(0, rotation, 0);
            }

        }

        if (Input.GetKey(KeyCode.Y))
        {
            if (Input.GetKey(KeyCode.Return))
            {
                float rotation = rotateAngle * Time.deltaTime;
                transform.Rotate(-rotation, 0, 0);
            }
            else
            {
                float rotation = rotateAngle * Time.deltaTime;
                transform.Rotate(rotation, 0, 0);
            }

        }

        if (Input.GetKey(KeyCode.Space))
        {
            System.Threading.Thread.Sleep(500);
            Debug.Log("space bar pressed");
            ppmScript.Generate(3);
        }
            


    }
}
