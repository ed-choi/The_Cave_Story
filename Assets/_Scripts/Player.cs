using UnityEngine;

[RequireComponent(typeof(Controller2D))]
public class Player : MonoBehaviour {

    public enum PowerType {
        Fire, Speed, Zip, Spring
    }

    public float jumpHeight = 4;
    public float timeToJumpApex = .4f;
    float accelerationTimeAirborne = .2f;
    float accelerationTimeGrounded = .1f;
    float moveSpeed = 6;

    //Ed Powers
    PowerType powerType;
    Power power;

    public GameObject basicBulletPrefab;
    public bool showPositionInConsole = false; // Tick this to show position in console.

    private Vector3 playerPos;

    // For restoring jump height when no spring is true.
    float originalJumpHeight;

    bool right = true;
    public bool Right {
        get {
            return right;
        }
    }

    float gravity;
    float jumpVelocity;
    Vector3 velocity;
    float velocityXSmoothing;

    Controller2D controller;
    SpriteRenderer sr;

    [HideInInspector]
    public Vector2 input;

    void Start() {
        sr = GetComponent<SpriteRenderer>();
        controller = GetComponent<Controller2D>();
        originalJumpHeight = jumpHeight;
        powerType = PowerType.Speed;
        updateGrav();
        SetPower(powerType);
    }

    void Update() {

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

        if (power.WillChangeVelocity()) {
            velocity.x = power.GetXVelocity(velocity.x);
            velocity.y = power.GetYVelocity(velocity.y);
        } else {
            velocity.x = GetXVelocity(velocity.x);
            velocity.y = GetYVelocity(velocity.y);
        }

        controller.Move(velocity * Time.deltaTime);

        power.Update();
    }

    void SetPower(PowerType powerType) {
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
        }
    }

    private void updateGrav() {
        gravity = -(2 * jumpHeight) / Mathf.Pow(timeToJumpApex, 2);
        jumpVelocity = Mathf.Abs(gravity) * timeToJumpApex;
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
}
