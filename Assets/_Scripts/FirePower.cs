using System;
using UnityEngine;

public class FirePower : Power {

    Player player;

    public FirePower(Player player) {
        this.player = player;
    }

    public bool WillChangeVelocity() {
        return false;
    }

    public float GetXVelocity(float xvelocity) { return 0; }

    public float GetYVelocity(float yvelocity) { return 0; }

    public void Update() {
        if (Input.GetKeyDown(KeyCode.X)) {
            var clone = MonoBehaviour.Instantiate(player.basicBulletPrefab, player.transform.position, player.transform.rotation) as GameObject;
            clone.GetComponent<basicBullet>().right = player.Right;
        }
    }
}
