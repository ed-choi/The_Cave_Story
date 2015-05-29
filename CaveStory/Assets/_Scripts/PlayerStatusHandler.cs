using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class PlayerStatusHandler : MonoBehaviour
{
    public Slider health;

    // Use this for initialization
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        // Death or restart whenever.
        if ((health.value <= 0) || (Input.GetKeyDown(KeyCode.R)))
        {
            Application.LoadLevel(Application.loadedLevel);
        }

    }

    void OnCollisionEnter2D(Collision2D coll)
    {
        if (coll.gameObject.tag == "tEnemy")
        {
            health.value--;
        }
    }

}