using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CutterScript : MonoBehaviour
{
    public Vector3 translate_vector = new Vector3(0, 0, 0);
    public float move_speed = 0.001f;
    public bool up = true;
    private bool moving = false;
    private float n = 0;
    private int count = 0;
    private Vector3 initial_pos = new Vector3(0, 0, 0);
    
    // Start is called before the first frame update
    void Start()
    {
        initial_pos = transform.position;
        n = 1 / move_speed;
    }

    // Update is called once per frame
    void Update()
    {
        
        if (!up && count < n)
        {

            transform.position += move_speed*translate_vector;
            count++;
            if (count >= n)
                HammerUp();
        }
        if (up && count > 0)
        {
            transform.position -= move_speed*translate_vector;
            count--;
            if (count == 0)
                moving = false;
        }

		if (Input.GetKeyDown(KeyCode.A))
		{
			HammerDown();			
		}
    }

    
    public void HammerDown()
    {
        moving = true;
        up = false;
    }
	
    public void HammerUp()
    {
        up = true;
    }
}
