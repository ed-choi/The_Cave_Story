using UnityEngine;
using System.Collections;

public class LarsController : MonoBehaviour {

    public float speed;
    public Vector3 move;
    Animator LarsAnimController;

    // Use this for initialization
    void Start() {
        LarsAnimController = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update() {
        move = new Vector3(Input.GetAxis("Horizontal"), Input.GetAxis("Vertical"), 0);
        transform.position += move * speed * Time.deltaTime;

        if ((move.x == 0) && (move.y == 0)) {
            LarsAnimController.SetBool("WalkingUp", false);
            LarsAnimController.SetBool("WalkingDown", false);
            LarsAnimController.SetBool("WalkingLeft", false);
            LarsAnimController.SetBool("WalkingRight", false);
        }

        if (move.x < 0)
            LarsAnimController.SetBool("WalkingLeft", true);

        if (move.x > 0)
            LarsAnimController.SetBool("WalkingRight", true);

        if (move.y > 0)
            LarsAnimController.SetBool("WalkingUp", true);

        if (move.y < 0)
            LarsAnimController.SetBool("WalkingDown", true);
    }

}