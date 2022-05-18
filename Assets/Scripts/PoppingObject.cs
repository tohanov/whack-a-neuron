using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PoppingObject : MonoBehaviour
{

    public float max_y = 5f;
    public float min_y = -5f;
    public bool popping = false;
    public float pop_speed = 0.1f;
    private float pop_until = 0f;
    public float pop_duration = 5f;
    
    // Start is called before the first frame update
    void Start()
    {
        pop_until = Time.time;
    }

    // Update is called once per frame
    void Update()
    {
        
        if (pop_until < Time.time)
            Hide();

        if (popping && transform.position.y < max_y)
            transform.Translate(new Vector3(0, pop_speed, 0));
        if(!popping && transform.position.y > min_y)
            transform.Translate(new Vector3(0, -pop_speed, 0));


    }

    void Pop()
    {
        pop_until = Time.time + pop_duration;
        popping = true;
    }

    void Hide()
    {
        popping = false;
    }
}
