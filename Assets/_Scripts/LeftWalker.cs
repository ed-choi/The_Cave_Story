using UnityEngine;

[RequireComponent(typeof(Player))]
[RequireComponent(typeof(Controller2D))]
public class LeftWalker : MonoBehaviour {

    public Player player;
    Controller2D controller;

    // Use this for initialization
    void Start() {
        controller = GetComponent<Controller2D>();
    }

    // Update is called once per frame
    void Update() {
        var vec = new Vector3(-Vector3.right.x, -Vector3.down.y * player.Gravity, 0);
        controller.Move(vec * Time.deltaTime);
    }
}
