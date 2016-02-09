using UnityEngine;
using System.Collections;

public class RocketLauncher : MonoBehaviour {

    private Vector3 mousePosition;
    private Vector3 startPosition;
    public GameObject rocketPrefab;

	// Use this for initialization
	void Start () {
        startPosition = transform.position;

	}
	
	// Update is called once per frame
	void Update () {
        Vector3 pos = Input.mousePosition;
        pos.z = transform.position.z - Camera.main.transform.position.z;
        transform.position = new Vector3(Camera.main.ScreenToWorldPoint(pos).x, startPosition.y, Camera.main.ScreenToWorldPoint(pos).z);
        if(Input.GetMouseButtonDown(0))
        {
            GameObject rocket;
            rocket = Instantiate(rocketPrefab, transform.position, transform.rotation) as GameObject;
            rocket.transform.parent = transform.parent;
        }
	}
}
