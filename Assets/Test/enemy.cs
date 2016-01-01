using UnityEngine;
using System.Collections;

public class enemy : MonoBehaviour {
    float amplitudeX = 10.0f;
    float amplitudeY = 5.0f;
    float omegaX = 1.0f;
    float omegaY = 5.0f;
    public float startx;
    public float starty;
    float index;
    public void Update()
    {
        index += Time.deltaTime;
        float x = amplitudeX * Mathf.Cos(omegaX * index);
        float y = Mathf.Abs(amplitudeY * Mathf.Sin(omegaY * index));
        transform.localPosition = new Vector3(x+startx, y+starty, 0);
    }
    /*private Vector3 left = new Vector3(-1,0,0);
    private Vector3 up = new Vector3(0, 1, 0);
    private Vector3 down = new Vector3(0, -1, 0);
    private float movetime = 1;
    // Use this for initialization
    void Start () {
        Invoke("movementupleft", 0);
        Invoke("movementdownleft", .1f);
    }
	
	// Update is called once per frame
	void Update () {
        left = new Vector3(-1 * Time.deltaTime, 0, 0);
        up = new Vector3(0, 1*Time.deltaTime, 0);
        down = new Vector3(0, -1*Time.deltaTime, 0);
        movetime = Time.deltaTime;
        //Invoke("moveupleft", 0);
        //Invoke("movedownleft", 0.01f);
        //Invoke("movedownleft", 0.02f);
        //Invoke("moveupleft", 0.03f);
    }
    void moveupleft()
    {
        transform.position += up;
        transform.position += left;
    }
    void movedownleft()
    {
        transform.position += down;
        transform.position += left;
    }
    void movementupleft()
    {
        InvokeRepeating("moveupleft", .1f, .1f);
    }
    void movementdownleft()
    {
        InvokeRepeating("movedownleft", .1f, .1f);
    }*/
}
