using UnityEngine;
using System;

[RequireComponent(typeof(Controller2D))]
public class Player : MonoBehaviour {

    public enum PowerType {
        Fire, Speed, Zip, Spring, None
    }

    public LayerMask grabMask;

    public float jumpHeight = 4;
    public float timeToJumpApex = .4f;
    float accelerationTimeAirborne = .2f;
    float accelerationTimeGrounded = .1f;
    float moveSpeed = 6;

    //Ed Powers
    public PowerType powerType;
    Power power;

    public GameObject basicBulletPrefab;
    public bool showPositionInConsole = false; // Tick this to show position in console.

    bool right = true;
    public bool Right {
        get {
            return right;
        }
    }

    float gravity;
    public float Gravity {
        get {
            return gravity;
        }
    }
    float jumpVelocity;
    public Vector3 velocity;
    float velocityXSmoothing;

    Controller2D controller;

    [HideInInspector]
    public Vector2 input;

    void Start() {
        controller = GetComponent<Controller2D>();
        updateGrav();
        SetPower(powerType);
        grabTimer = new UnityTimer(grabTime);
    }

    void Update() {

        Cheat();

        if (controller.collisions.above || controller.collisions.below) {
            velocity.y = 0;
        }

        input = new Vector2(Input.GetAxisRaw("Horizontal"), Input.GetAxisRaw("Vertical"));
        controller.playerInput = input;

        if (input.x == 1 && !right) {
            right = true;
        } else if (input.x == -1 && right) {
            right = false;
        }

        if (Input.GetKeyDown(KeyCode.Space) && controller.collisions.below) {
            jump();
        }

        if (power == null) {
            var newPower = Grab();
            if (newPower != PowerType.None) {
                SetPower(newPower);
            }
        }

        if (power != null && power.WillChangeVelocity()) {
            velocity.x = power.GetXVelocity(velocity.x);
            velocity.y = power.GetYVelocity(velocity.y);
        } else {
            velocity.x = GetXVelocity(velocity.x);
            velocity.y = GetYVelocity(velocity.y);
        }

        controller.Move(velocity * Time.deltaTime);

        if (power != null) {
            power.Update();
        }
    }

    public void SetPower(PowerType powerType) {
        this.powerType = powerType;
        switch (powerType) {
            case PowerType.Fire:
                power = new FirePower(this);
                break;
            case PowerType.Speed:
                power = new SpeedPower(this);
                break;
            case PowerType.Spring:
                power = new SpringPower(this);
                break;
            case PowerType.Zip:
                power = new ZipPower(this);
                break;
            default:
                power = null;
                break;
        }
    }

    private void updateGrav() {
        gravity = -(2 * jumpHeight) / Mathf.Pow(timeToJumpApex, 2);
        jumpVelocity = Mathf.Abs(gravity) * timeToJumpApex;
    }

    public float grabTime = 300.0f;
    private UnityTimer grabTimer;

    private PowerType Grab() {
        if (grabTimer.State == UnityTimer.TimerState.Ticking || Input.GetKeyDown(KeyCode.Z)) {
            grabTimer.Tick(Time.deltaTime);
            var boxCastOrigin = new Vector2(transform.position.x, transform.position.y);
            var boxCastSize = new Vector2(3, 3);
            var boxCastAngle = 0;
            var boxCastDirection = right ? Vector2.right : -Vector2.right;
            var boxCastDistance = 25;

            Debug.Log(String.Format("{0} {1} {2} {3} {4}", boxCastOrigin, boxCastSize, boxCastAngle, boxCastDirection, boxCastDistance));

            float half_width = boxCastSize.x / 2;
            float half_height = boxCastSize.y / 2;

            // 4 points of the origin box
            Vector2 p1 = new Vector2(boxCastOrigin.x - half_width, boxCastOrigin.y + half_height);
            Vector2 p2 = new Vector2(boxCastOrigin.x + half_width, boxCastOrigin.y + half_height);
            Vector2 p3 = new Vector2(boxCastOrigin.x - half_width, boxCastOrigin.y - half_height);
            Vector2 p4 = new Vector2(boxCastOrigin.x + half_width, boxCastOrigin.y - half_height);

            // 4 points of the destination box
            Vector2 dest_origin = boxCastOrigin + (boxCastDistance * boxCastDirection);
            Vector2 t1 = new Vector2(dest_origin.x - half_width, dest_origin.y + half_height);
            Vector2 t2 = new Vector2(dest_origin.x + half_width, dest_origin.y + half_height);
            Vector2 t3 = new Vector2(dest_origin.x - half_width, dest_origin.y - half_height);
            Vector2 t4 = new Vector2(dest_origin.x + half_width, dest_origin.y - half_height);

            Color box_color = Color.red;

            Debug.DrawLine(p1, p2, box_color);
            Debug.DrawLine(p2, p4, box_color);
            Debug.DrawLine(p4, p3, box_color);
            Debug.DrawLine(p3, p1, box_color);

            Debug.DrawLine(t1, t2, box_color);
            Debug.DrawLine(t2, t4, box_color);
            Debug.DrawLine(t4, t3, box_color);
            Debug.DrawLine(t3, t1, box_color);

            Debug.DrawLine(p1, t1, box_color);
            Debug.DrawLine(p2, t2, box_color);
            Debug.DrawLine(p3, t3, box_color);
            Debug.DrawLine(p4, t4, box_color);

            RaycastHit2D enemyCollision = Physics2D.BoxCast(boxCastOrigin, boxCastSize, boxCastAngle, boxCastDirection, boxCastDistance, grabMask);
            if (enemyCollision != null && enemyCollision.collider != null) {
                var enemy = enemyCollision.collider.gameObject.GetComponent<Enemy>();
                return enemy.PowerType;
            }
        }

        return PowerType.None;
    }

    public void setJumpHeight(float jumpH) {
        jumpHeight = jumpH;
        updateGrav();
    }

    public void jump() {
        velocity.y = jumpVelocity;
    }

    public float GetXVelocity(float xvelocity) {
        var targetVelocityX = input.x * moveSpeed;
        return Mathf.SmoothDamp(xvelocity, targetVelocityX, ref velocityXSmoothing, (controller.collisions.below) ? accelerationTimeGrounded : accelerationTimeAirborne);
    }

    public float GetYVelocity(float yvelocity) {
        return yvelocity + gravity * Time.deltaTime;
    }

    public float DampenMovement(float velocity, float targetVelocity) {
        return Mathf.SmoothDamp(velocity, targetVelocity, ref velocityXSmoothing, (controller.collisions.below) ? accelerationTimeGrounded : accelerationTimeAirborne);
    }

    public void Cheat() {
        if (Input.GetKeyDown(KeyCode.Alpha1)) {
            SetPower(PowerType.Fire);
        } else if (Input.GetKeyDown(KeyCode.Alpha2)) {
            SetPower(PowerType.Speed);
        } else if (Input.GetKeyDown(KeyCode.Alpha3)) {
            SetPower(PowerType.Spring);
        } else if (Input.GetKeyDown(KeyCode.Alpha4)) {
            SetPower(PowerType.Zip);
        } else if (Input.GetKeyDown(KeyCode.BackQuote)) {
            SetPower(PowerType.None);
        }
    }
}
