using UnityEngine;
using System.Collections;

public class Movement : MonoBehaviour {

	public float speed;
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
		if (Input.GetKey (KeyCode.LeftArrow))
			transform.Translate (-speed * Time.deltaTime, 0, 0);
	}
}
