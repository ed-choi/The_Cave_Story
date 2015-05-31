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
	void newPower(int powNum){
		fire = false;
		speed = false;
		zip = false;
		spring = false;
		fight = false;
		sword = false;
		switch (powNum) {
		case 0:
			fire = true;
		case 1:
			speed = true;
		case 2:
			zip = true;
		case 3:
			spring = true;
		case 4:
			fight = true;
		case 5:
			sword = true;
		}
	}
	// Update is called once per frame
	void Update () {
		playerPos = GameObject.Find ("Ed-Player-ARTNOTFINISHED").transform.position;
		Debug.Log (playerPos);
		if (fire) {
		}
		if (speed) {
			
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
		if (spring) {
			player.setJumpHeight (8);
		}
		if (fight) {
		}
		if (sword) {
		}


	
	}
}
