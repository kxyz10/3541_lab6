using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;

public class GeneratePPM : MonoBehaviour
{
    public string fileName;
    public Camera camera;
    float distanceToImageFrame;
    float pixelSize;
    // Start is called before the first frame update
    void Start()
    {
        fileName = "raytrace.ppm";
        //camera = GameObject.Find("Main Camera");
        camera = Camera.main;
        distanceToImageFrame = 10f;
        pixelSize = 1.0f;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void Generate(int size)
    {
        Debug.Log("Generating ppm");



        FileStream fs = File.Create(fileName);
        StreamWriter writer = new StreamWriter(fs);
        Vector3[,] pixelCenters = MakePixelChart(size);
        printArray(pixelCenters, size);
        int i = 0;
        while (i < size)
        {
            int j = 0;
            while (j < size)
            {
                // Bit shift the index of the layer (8) to get a bit mask
                int layerMask = 1 << 8;

                // This would cast rays only against colliders in layer 8.
                // But instead we want to collide against everything except layer 8. The ~ operator does this, it inverts a bitmask.
                layerMask = ~layerMask;
                Vector3 direction = pixelCenters[i, j] - camera.transform.position;
                RaycastHit hit;
                // Does the ray intersect any objects excluding the player layer
                if (Physics.Raycast(camera.transform.position, direction, out hit, Mathf.Infinity, layerMask))
                {
                    Debug.DrawRay(camera.transform.position, direction * hit.distance, Color.black, 1000, false);
                    Debug.Log("Did Hit");
                }
                else
                {
                    Debug.DrawRay(camera.transform.position, direction * 1000, Color.red, 1000, false);
                    Debug.Log("Did not Hit");
                }
                j += 1;
            }
            i += 1;
        }

        writer.Write("P3\n");
        writer.Write($"{size} {size}\n");
        writer.Write("255\n");
        writer.Write("255 255 255 020 222 145 255 255 255\n000 000 000 255 255 255 000 000 000\n255 255 255 000 000 000 255 255 255");
        writer.Close();
    }

    public Vector3[,] MakePixelChart(int size)
    {
        //Create the 2D array of the image pixels
        //Values of the array represent the center of the pixel
        Vector3[,] chart = new Vector3[size, size];
        Vector3 center = camera.transform.position + camera.transform.forward * distanceToImageFrame;
        //assume size is odd
        //since arrays start at 0 dont need to add 1 
        int mid = size / 2;
        chart[mid, mid] = center;
        int rowDistance = 0;
        int colDistance = 0;
        int i = 0;
        while(i< size)
        {
            int j = 0;
            while (j < size)
            {
                rowDistance = i - size;
                colDistance = j - size;
                chart[j, i] = center + pixelSize * colDistance * camera.transform.right + pixelSize * rowDistance * camera.transform.up;
                j += 1;
            }
            i += 1;
        }
        return chart;
    }

    public void printArray(Vector3[,] array, int size)
    {
        int i = 0;
        while (i < size)
        {
            int j = 0;
            while (j < size)
            {
                Debug.Log(array[i, j]);
                j += 1;
            }
            Debug.Log("\n");
            i += 1;
        }
    }
}
