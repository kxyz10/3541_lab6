using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    Vector3 homePos;
    Quaternion origRot;
    public float moveSpeed = 5f;
    public float rotateAngle = 30;
    public float rotationSpeed = 100;
    public GeneratePPM ppmScript;
    public int size = 100;
    public bool mode = true;
    // Start is called before the first frame update
    void Start()
    {
        homePos = transform.position;
        origRot = transform.rotation;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKey(KeyCode.W))
        {
            if (mode)
            {
                transform.Translate(Vector3.up * moveSpeed * Time.deltaTime);
            }
            else
            {
                transform.position = new Vector3(0, 10, 0);
                Vector3 v = new Vector3(90,0,0);
                transform.rotation = Quaternion.Euler(v);
            }
        }

        if (Input.GetKey(KeyCode.S))
        {
            if (mode)
            {
                transform.Translate(Vector3.down * moveSpeed * Time.deltaTime);
            }
            else
            {
                transform.position = new Vector3(homePos.x, 0, homePos.z);
                Vector3 v = Vector3.zero;
                transform.rotation = Quaternion.Euler(v);
            }
        }

        if (Input.GetKey(KeyCode.A) && mode)
            transform.Translate(Vector3.left * moveSpeed * Time.deltaTime);

        if (Input.GetKey(KeyCode.D))
        {
            if (mode)
            {
                transform.Translate(Vector3.right * moveSpeed * Time.deltaTime);
            }
            else
            {
                transform.position = new Vector3(10, 0, 0);
                Vector3 v = new Vector3(0, -90, 0);
                transform.rotation = Quaternion.Euler(v);
            }
        }

        if (Input.GetKey(KeyCode.Q) && mode)
            transform.Translate(Vector3.forward * moveSpeed * Time.deltaTime);

        if (Input.GetKey(KeyCode.E))
        {
            if (mode)
            {
                transform.Translate(-Vector3.forward * moveSpeed * Time.deltaTime);
            }
            else
            {
                transform.position = new Vector3(10, 10, -10);
                Vector3 v = new Vector3(45, -45, 0);
                transform.rotation = Quaternion.Euler(v);
            }
        }

        if (Input.GetKey(KeyCode.X) && mode)
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

        if (Input.GetKey(KeyCode.Y) && mode)
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
            ppmScript.Generate(size);
        }

        if (Input.GetKey(KeyCode.O) && mode)
        {
            transform.position = new Vector3(homePos.x, 0, homePos.z);
            Vector3 v = Vector3.zero;
            transform.rotation = Quaternion.Euler(v);
            mode = false;
        }

        if (Input.GetKey(KeyCode.P) && !mode) 
        {
            transform.position = homePos;
            transform.rotation = origRot;
            mode = true; 
        }

    }
}
