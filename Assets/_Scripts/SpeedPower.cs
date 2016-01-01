using UnityEngine;

public class SpeedPower : Power {

    bool speedActivated = false;
    const float SPEEDTIME = 5;
    float speedTimer;
    Player player;
    float superSpeed = 12;

    public SpeedPower(Player player) {
        speedTimer = SPEEDTIME;
        this.player = player;
    }

    public bool WillChangeVelocity() {
        if (speedTimer < 0) {
            speedActivated = false;
            speedTimer = SPEEDTIME;
        }

        if (Input.GetKeyDown(KeyCode.Z)) {
            speedActivated = true;
        }

        return speedActivated;
    }

    public float GetXVelocity(float xvelocity) {
        speedTimer -= Time.deltaTime;

        float targetVelocityX;
        if (player.Right) {
            targetVelocityX = superSpeed;
        } else {
            targetVelocityX = -superSpeed;
        }

        return player.DampenMovement(xvelocity, targetVelocityX);
    }

    public float GetYVelocity(float yvelocity) {
        return player.GetYVelocity(yvelocity);
    }

    public void Update() { }
}
