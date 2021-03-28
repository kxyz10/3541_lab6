using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;

public class GeneratePPM : MonoBehaviour
{
    public string fileName;
    // Start is called before the first frame update
    void Start()
    {
        fileName = "raytrace.ppm";
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
        writer.Write("P3\n");
        writer.Write($"{size} {size}\n");
        writer.Write("255\n");
        writer.Write("255 255 255 020 222 145 255 255 255\n000 000 000 255 255 255 000 000 000\n255 255 255 000 000 000 255 255 255");
        writer.Close();
    }
}
