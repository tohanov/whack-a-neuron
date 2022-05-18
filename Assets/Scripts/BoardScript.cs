using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BoardScript : MonoBehaviour
{
    public GameObject[] tiles;
    public GameObject tile_example;
    public HammerScript HammerRight, HammerLeft;
    public HammerHolderScript hammerHolder;
    public int N = 2;

	private KeyCode[] keyCodes = {
		KeyCode.Alpha1,
		KeyCode.Alpha2,
		KeyCode.Alpha3,
		KeyCode.Alpha4,
		KeyCode.Alpha5,
		KeyCode.Alpha6,
		KeyCode.Alpha7,
		KeyCode.Alpha8,
		KeyCode.Alpha9,
		KeyCode.Keypad0,
		KeyCode.Keypad1,
		KeyCode.Keypad2,
		KeyCode.Keypad3,
		KeyCode.Keypad4,
		KeyCode.Keypad5,
		KeyCode.Keypad6
	};


    // Start is called before the first frame update
    void Start()
    {
        tiles = new GameObject[N*N];
        for(int i = 0; i < N; i++)
        {
            for(int j=0;j<N;j++)
            {
                if (i == 0 && j == 0)
                {
                    tiles[0] = tile_example;
                    continue;
                }
                tiles[i*N + j] = Object.Instantiate(tile_example, this.transform);
                tiles[i*N + j].transform.Translate(new Vector3(10 * j, 0, 10 * i));
                tiles[i*N + j].name = "Tile" + (i * 3 + j + 1);
                FlickerScript script = tiles[i * N + j].GetComponent<FlickerScript>();
                script.UpdateFrequency(4 + (i * N + j) * 2);
                
            }
        }
        
    }


    // Update is called once per frame
    void Update()
    {
		// limited by existing tiles number so won't get out of bounds error
        for (int i = 0; i < N*N; ++i) {
			if (Input.GetKeyDown(keyCodes[i])) {
            	hammerHolder.MoveHammer(tiles[i]);
				break;
			}
		}
    }

    
}
