using UnityEngine;
using System.Collections;

public class enemy2 : MonoBehaviour {
    public float speed = 5;
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
        Vector3 moveleft = new Vector3(-1 * speed * Time.deltaTime, 0, 0);
        transform.position += moveleft;
	}
}
