using UnityEngine;
using System.Collections;

public class ResourceManager : MonoBehaviour {
	public static ResourceManager instance; 
	public static int UraniumStockpile = 0;
	// Use this for initialization

	public GameObject m_tack;
	public GameObject m_tackSpawnLocation;
	public GameObject m_tackParent;

	void Start () {
		instance = this;
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	public static void AddUranium(){
		//Instantiate a tack
		GameObject go = GameObject.Instantiate(instance.m_tack);
		go.transform.position = new Vector3(
			instance.m_tackSpawnLocation.transform.position.x + Random.Range(-1.0f,1.0f), 
			instance.m_tackSpawnLocation.transform.position.y + Random.Range(-1.0f,1.0f),
			instance.m_tackSpawnLocation.transform.position.z);
		go.transform.parent = instance.m_tackParent.transform;
	}
}
