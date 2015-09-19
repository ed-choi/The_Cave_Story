using UnityEngine;
using System.Collections;

[RequireComponent(typeof(Controller2D))]
public class Player : MonoBehaviour {

    public float jumpHeight = 4;
    public float timeToJumpApex = .4f;
    float accelerationTimeAirborne = .2f;
    float accelerationTimeGrounded = .1f;
    float moveSpeed = 6;

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
    public Sprite leftsprite;
    public Sprite rightsprite;
    SpriteRenderer sr;

    [HideInInspector]
    public Vector2 input;

    void Start() {
        sr = GetComponent<SpriteRenderer>();
        controller = GetComponent<Controller2D>();
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

        var changed = false;
        if (input.x == 1 && !right) {
            changed = true;
            right = true;
        } else if (input.x == -1 && right) {
            changed = true;
            right = false;
        }
        if (changed) {
            if (right == false) {
                sr.sprite = leftsprite;
            }
            if (right == true) {
                sr.sprite = rightsprite;
            }
        }

        if (Input.GetKeyDown(KeyCode.Space) && controller.collisions.below) {
            jump();
        }

        float targetVelocityX = input.x * moveSpeed;
        velocity.x = Mathf.SmoothDamp(velocity.x, targetVelocityX, ref velocityXSmoothing, (controller.collisions.below) ? accelerationTimeGrounded : accelerationTimeAirborne);

        velocity.y += gravity * Time.deltaTime;
        controller.Move(velocity * Time.deltaTime);
    }
}
