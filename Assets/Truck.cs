using UnityEngine;
using System.Collections;

public class Truck : MonoBehaviour {

    public float truckSpeed;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
        transform.Translate(Vector3.up * Time.deltaTime * -truckSpeed);
	}

    void OnTriggerEnter2D(Collider2D col)
    {
        print("TruckTrigger");
        Destroy(gameObject);
    }

    void OnCollisionEnter2D(Collision2D col)
    {
        print("TruckCollision");
        Destroy(gameObject);
    }
}
