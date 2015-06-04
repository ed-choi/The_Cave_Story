using UnityEngine;
using System.Collections;

public class basicTenemy : MonoBehaviour
{

    Rigidbody2D rb2d;
    public bool moveRand = false;
    int[] forces;

    // Use this for initialization
    void Start()
    {
        forces = new int[4] { 1, -1, 2, -2 };
        rb2d = this.GetComponent<Rigidbody2D>();
        if (!moveRand)
            InvokeRepeating("waitAndMove", 0, 2);

        if (moveRand)
            InvokeRepeating("waitAndMoveRand", 0, 2);
    }

    // Update is called once per frame
    void Update()
    {

    }

    void waitAndMove()
    {
        rb2d.AddForce(Vector2.right * -2, ForceMode2D.Impulse);
        rb2d.AddForce(Vector2.up * 2, ForceMode2D.Impulse);
    }

    void waitAndMoveRand()
    {
        // If given floats does floats if ints does ints max exclusive
        rb2d.AddForce(Vector2.right * forces[Random.Range(0, 4)], ForceMode2D.Impulse);
        rb2d.AddForce(Vector2.up * forces[Random.Range(0, 4)], ForceMode2D.Impulse);
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "basicBullet")
        {
            Destroy(gameObject);
        }
    }

}