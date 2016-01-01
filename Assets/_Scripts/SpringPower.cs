using System;
using UnityEngine;

public class SpringPower : Power {
    Player player;

    public SpringPower(Player player) {
        this.player = player;
    }

    public bool WillChangeVelocity() {
        return false;
    }

    public float GetXVelocity(float xvelocity) {
        return player.GetXVelocity(xvelocity);
    }

    public float GetYVelocity(float yvelocity) {
        return player.GetYVelocity(yvelocity);
    }

    // Update is called once per frame
    public void Update() {

    }
}
