using UnityEngine;
using System.Collections;

public class basicBullet : MonoBehaviour
{

    public float bulletSpeed;
    private Rigidbody2D rb;

    // Use this for initialization
    void Start()
    {
        // Lifetime of bullet, destroy after x seconds.
        Destroy(gameObject, 1);
        rb = GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        //rb.AddRelativeForce(transform.right * bulletSpeed, ForceMode2D.Force);
        transform.Translate(transform.right * bulletSpeed);
    }

}