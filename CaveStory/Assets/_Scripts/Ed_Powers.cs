using UnityEngine;
using System.Collections;

public class Ed_Powers : MonoBehaviour {

	public bool fire, speed, zip, spring, fight, sword;
	private Player player;
	private Vector3	playerPos;
	// Use this for initialization
	void Start () {
		player = GetComponent<Player>();
	}
	
	// Update is called once per frame
	void Update () {
		playerPos = GameObject.Find ("Ed-Player-ARTNOTFINISHED").transform.position;
		Debug.Log (playerPos);
		if (spring) {
			player.setJumpHeight (8);
		}
		if (zip) {
			if (Input.GetKey (KeyCode.Z)) {
				if (Input.GetKeyDown (KeyCode.UpArrow)) {
					Vector3 temp = new Vector3 (0, 5, 0);
					GameObject.Find ("Ed-Player-ARTNOTFINISHED").transform.position += temp;
				}
				if (Input.GetKeyDown (KeyCode.RightArrow)) {
					Vector3 temp = new Vector3 (5, 0, 0);
					GameObject.Find ("Ed-Player-ARTNOTFINISHED").transform.position += temp;
				}
				if (Input.GetKeyDown (KeyCode.LeftArrow)) {
					Vector3 temp = new Vector3 (-5, 0, 0);
					GameObject.Find ("Ed-Player-ARTNOTFINISHED").transform.position += temp;
				}
			}
		}
		if (speed) {
		}

	
	}
}
