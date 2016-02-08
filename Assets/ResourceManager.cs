using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class ResourceManager : MonoBehaviour {
	public static ResourceManager instance; 
	public static int UraniumStockpile = 0;
	// Use this for initialization

	public GameObject m_tack;
	public GameObject m_tackSpawnLocation;
	public GameObject m_tackParent;

	public Text m_cashText;

	public int cash;

	void Start () {
		instance = this;
		cash = 0;
	}

	// Update is called once per frame
	void Update () {
	
	}

	public static void AddCash(){
		instance.cash += 100000;
		instance.m_cashText.text = "" + instance.cash;
	}

	public static void GameOver(){
		int prevHighScore = PlayerPrefs.GetInt ("High Score", 0);
		if (instance.cash < prevHighScore) {
			PlayerPrefs.SetInt ("High Score", instance.cash);
		}

		PlayerPrefs.SetInt ("Your Score", instance.cash);
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
