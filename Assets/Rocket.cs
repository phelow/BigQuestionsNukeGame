using UnityEngine;
using System.Collections;

public class Rocket : MonoBehaviour {

    public float rocketSpeed;

	// Use this for initialization
	void Start () {

	}
	
	// Update is called once per frame
	void Update () {
        transform.Translate(Vector3.up * Time.deltaTime * rocketSpeed);
	}

    void OnTriggerEnter2D(Collider2D col)
    {
        print("RocketTrigger");
        Destroy(gameObject);
    }

    void OnCollisionEnter2D(Collision2D col)
    {
        print("RocketCollision");
        Destroy(gameObject);
    }
}
