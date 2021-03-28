using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;

public class GeneratePPM : MonoBehaviour
{
    public string fileName;
    GameObject camera;
    float distanceToImageFrame;
    // Start is called before the first frame update
    void Start()
    {
        fileName = "raytrace.ppm";
        camera = GameObject.Find("Main Camera");
        distanceToImageFrame = 5.0f;
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
        //need to have case for even and odd size
        return chart;
    }
}
