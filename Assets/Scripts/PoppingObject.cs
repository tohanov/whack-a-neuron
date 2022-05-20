using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;


public class PoppingObject : MonoBehaviour
{

    public float max_y = 5f;
    public float min_y = -5f;
    public bool popping = false;
    public float pop_speed = 0.1f;
    private float pop_until = 0f;
    public float pop_duration = 5f;
	public string type; //1 = mole 2 = dynamite
	private int score = 0;
	public BoardScript bs;
	// public GameObject audioSource;
	public AudioSource audioSource;
	
    
    // Start is called before the first frame update
    void Start()
    {
        pop_until = Time.time;
		popping = true;
		Pop();
		
    }

    // Update is called once per frame
    void Update()
    {
        
        // if (pop_until < Time.time)
            // Hide();

        // if (popping && transform.position.y < max_y)
            // transform.Translate(new Vector3(0, pop_speed, 0));
        // if(!popping && transform.position.y > min_y)
            // transform.Translate(new Vector3(0, -pop_speed, 0));


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
	
	private void OnTriggerEnter(Collider other){
		Debug.Log("Mole detected hit");
		transform.Translate(new Vector3(0, -5, 0));
		bs.AddScore(10);
		// audioSource.enabled = true;
		audioSource.Play();
	}
}
