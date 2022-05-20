using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class calibrationFlickerScript : MonoBehaviour
{
    public float frequency;
	
	//float[] frequencies = { 4.0, 5.0, 6.0, 7.5 };
	
    public MeshRenderer mesh_renderer;
    
    private float updateTime = 0;
    private float T = 0;
    private bool colors_flag = true;
    
    private float x = 10f;
    private Color c;
    // Start is called before the first frame update
    void Start()
    {
        updateTime = Time.time;
        c = new Color(x / 255, x / 255, x / 255, 0);
        T = 1 / frequency;        
    }

    // Update is called once per frame
    void Update()
    {
        if (Time.time > updateTime + T)
        {
            updateTime = Time.time;
            if(colors_flag)
            {

                this.GetComponent<MeshRenderer>().material.color += c;
                transform.Find("ObjectHolder").Find("Mole").GetComponent<MeshRenderer>().material.color += c;
                transform.Find("Hole").GetComponent<MeshRenderer>().material.color += c;
                transform.Find("ObjectHolder").Find("Dynamite").GetComponent<MeshRenderer>().material.color += c;
            }
            else
            {
                this.GetComponent<MeshRenderer>().material.color -= c;
                transform.Find("ObjectHolder").Find("Mole").GetComponent<MeshRenderer>().material.color -= c;
                transform.Find("Hole").GetComponent<MeshRenderer>().material.color -= c;
                transform.Find("ObjectHolder").Find("Dynamite").GetComponent<MeshRenderer>().material.color -= c;
            }
            colors_flag = !colors_flag;
        }
    }
	
    public void UpdateFrequency(float freq)
    {
        frequency = freq;
        T = 1 / freq;
    }
}
