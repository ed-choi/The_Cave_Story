using UnityEngine;
using System.Collections;

public class Ed_Powers : MonoBehaviour {

    public GameObject basicBulletPrefab;
    public bool fire, speed, zip, spring, fight, sword;
    public bool showPositionInConsole = false; // Tick this to show position in console.

    private Player player;
    private Vector3 playerPos;

    // For restoring jump height when no spring is true.
    float originalJumpHeight;

    // Use this for initialization
    void Start() {
        player = GetComponent<Player>();
        originalJumpHeight = player.jumpHeight;
    }

    void newPower(int powNum) {
        fire = false;
        speed = false;
        zip = false;
        spring = false;
        fight = false;
        sword = false;
        switch (powNum) {
            case 0:
                fire = true;
                break;
            case 1:
                speed = true;
                break;
            case 2:
                zip = true;
                break;
            case 3:
                spring = true;
                break;
            case 4:
                fight = true;
                break;
            case 5:
                sword = true;
                break;
        }
    }
    // Update is called once per frame
    void Update() {
        playerPos = GameObject.Find("Ed-Player").transform.position;

        if (showPositionInConsole)
            Debug.Log(playerPos);

        if (fire) {
            if (Input.GetKeyDown(KeyCode.X)) {
                var clone = Instantiate(basicBulletPrefab, transform.position, transform.rotation) as GameObject;
                clone.GetComponent<basicBullet>().right = player.Right;
            }
        }

        if (speed) {

        }
        if (zip) {
            if (Input.GetKey(KeyCode.Z)) {
                if (Input.GetKeyDown(KeyCode.UpArrow)) {
                    Vector3 temp = new Vector3(0, 5, 0);
                    GameObject.Find("Ed-Player").transform.position += temp;
                }
                if (Input.GetKeyDown(KeyCode.RightArrow)) {
                    Vector3 temp = new Vector3(5, 0, 0);
                    GameObject.Find("Ed-Player").transform.position += temp;
                }
                if (Input.GetKeyDown(KeyCode.LeftArrow)) {
                    Vector3 temp = new Vector3(-5, 0, 0);
                    GameObject.Find("Ed-Player").transform.position += temp;
                }
            }
        }

        if (spring) {
            player.setJumpHeight(8);
        } else if (!spring) {
            player.setJumpHeight(originalJumpHeight);
        }

        if (fight) {
        }
        if (sword) {
        }


    }
}