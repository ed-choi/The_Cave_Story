using UnityEngine;
using System.Collections;
using System;

public class ZipPower : Power {
    Player player;

    public ZipPower(Player player) {
        this.player = player;
    }
    public bool WillChangeVelocity() {
        return false;
    }

    public float GetXVelocity(float xvelocity) {
        return player.GetXVelocity(xvelocity);
    }

    public float GetYVelocity(float yvelocity) {
        return 0;
    }

    // Update is called once per frame
    public void Update() {
        if (Input.GetKey(KeyCode.Z)) {
            if (Input.GetKeyDown(KeyCode.UpArrow)) {
                Vector3 temp = new Vector3(0, 5, 0);
                player.transform.position += temp;
            }
            if (Input.GetKeyDown(KeyCode.RightArrow)) {
                Vector3 temp = new Vector3(5, 0, 0);
                player.transform.position += temp;
            }
            if (Input.GetKeyDown(KeyCode.LeftArrow)) {
                Vector3 temp = new Vector3(-5, 0, 0);
                player.transform.position += temp;
            }
        }
    }
}
