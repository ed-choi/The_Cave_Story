using UnityEngine;
using System.Collections;

[RequireComponent(typeof(Controller2D))]
public class Player : MonoBehaviour {

    public float jumpHeight = 4;
    public float timeToJumpApex = .4f;
    float accelerationTimeAirborne = .2f;
    float accelerationTimeGrounded = .1f;
    float moveSpeed = 6;

    //Ed Powers
    public GameObject basicBulletPrefab;
    public bool fire, speed, zip, spring, fight, sword;
    public bool showPositionInConsole = false; // Tick this to show position in console.

    public float speedTime = 5;

    float superSpeed = 12;
    float speedTimer;
    bool speedActivated = false;

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
        speedTimer = speedTime;
        updateGrav();
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

        if (Input.GetKeyDown(KeyCode.Z)) {
            speedActivated = true;
        }

        float targetVelocityX;

        if (speed && speedActivated && speedTimer > 0) {
            speedTimer -= Time.deltaTime;
            if (right) {
                targetVelocityX = superSpeed;
            } else {
                targetVelocityX = -superSpeed;
            }

            Debug.Log(speedTimer);
        } else {
            Debug.Log("dank memes");
            speedActivated = false;
            speedTimer = speedTime;
            targetVelocityX = input.x * moveSpeed;
        }

        velocity.x = Mathf.SmoothDamp(velocity.x, targetVelocityX, ref velocityXSmoothing, (controller.collisions.below) ? accelerationTimeGrounded : accelerationTimeAirborne);

        velocity.y += gravity * Time.deltaTime;
        controller.Move(velocity * Time.deltaTime);

        Powers();
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

    void Powers() {
        playerPos = transform.position;

        if (showPositionInConsole)
            Debug.Log(playerPos);

        if (fire) {
            if (Input.GetKeyDown(KeyCode.X)) {
                var clone = Instantiate(basicBulletPrefab, transform.position, transform.rotation) as GameObject;
                clone.GetComponent<basicBullet>().right = right;
            }
        }

        if (zip) {
            if (Input.GetKey(KeyCode.Z)) {
                if (Input.GetKeyDown(KeyCode.UpArrow)) {
                    Vector3 temp = new Vector3(0, 5, 0);
                    transform.position += temp;
                }
                if (Input.GetKeyDown(KeyCode.RightArrow)) {
                    Vector3 temp = new Vector3(5, 0, 0);
                    transform.position += temp;
                }
                if (Input.GetKeyDown(KeyCode.LeftArrow)) {
                    Vector3 temp = new Vector3(-5, 0, 0);
                    transform.position += temp;
                }
            }
        }

        if (spring) {
            setJumpHeight(8);
        } else if (!spring) {
            setJumpHeight(originalJumpHeight);
        }

        if (fight) {
        }
        if (sword) {
        }


    }
}
