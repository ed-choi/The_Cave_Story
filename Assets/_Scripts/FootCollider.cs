using UnityEngine;
using System.Collections;

public class FootCollider : MonoBehaviour {

    // Use this for initialization
    void Start() {

    }

    // Update is called once per frame
    void Update() {

    }

    void OnTriggerEnter2D(Collider2D other) {
        if (other.gameObject.tag == "tEnemy") {
            transform.parent.GetComponent<Player>().jump();
            Destroy(other.gameObject);
        }
    }

}