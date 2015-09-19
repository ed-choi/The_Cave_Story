using UnityEngine;
using System.Collections;

public class EdWalk : MonoBehaviour {

    Animator animator;
    Player player;

    // Use this for initialization
    void Start() {
        animator = GetComponent<Animator>();
        player = GetComponent<Player>();
    }

    // Update is called once per frame
    void Update() {
        animator.SetBool("Right", player.Right);
    }
}
