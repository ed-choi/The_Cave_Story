using UnityEngine;
using System.Collections;

public class basicBullet : MonoBehaviour {

    public float bulletSpeed;
    public bool right;

    // Use this for initialization
    void Start() {
        // Lifetime of bullet, destroy after x seconds.
        Destroy(gameObject, 1);
    }

    void Update() {
        //rb.AddRelativeForce(transform.right * bulletSpeed, ForceMode2D.Force);
        var dir = transform.right;
        if (!right) {
            dir *= -1;
        }
        transform.Translate(dir * bulletSpeed);
    }

}