using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HammerHolderScript : MonoBehaviour
{
    private Vector3 velocity = Vector3.zero;
    public float dampTime = 0.4f;
    private Vector3 dest;
	private Vector3 initial_pos = new Vector3(0,25,-3);

    // Start is called before the first frame update
    void Start()
    {
        dest = transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        if(!transform.position.Equals(dest))
            transform.position = Vector3.SmoothDamp(dest, transform.position, ref velocity, dampTime);
    }

    public void AimHammers(GameObject destObject)
    {
        this.dest = destObject.transform.position + initial_pos;
    }

}
