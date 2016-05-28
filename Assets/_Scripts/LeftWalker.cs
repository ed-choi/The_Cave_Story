using UnityEngine;

[RequireComponent(typeof(Controller2D))]
public class LeftWalker : MonoBehaviour, Enemy {

    public Player player;
    public float moveSpeed = 3;
    Controller2D controller;

    Player.PowerType powerType = Player.PowerType.Speed;
    public Player.PowerType PowerType {
        get {
            return powerType;
        }
    }

    int damage = 2;
    public int Damage {
        get {
            return damage;
        }
    }

    // Use this for initialization
    void Start() {
        controller = GetComponent<Controller2D>();
    }

    // Update is called once per frame
    void Update() {
        controller.Move(new Vector3(-moveSpeed, player.Gravity, 0) * Time.deltaTime);
    }
}
