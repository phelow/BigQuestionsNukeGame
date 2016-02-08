using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class CashManager : MonoBehaviour {
	private static int cash;
	public Text m_text;
	public static CashManager instance;
	// Use this for initialization
	void Start () {
		instance = this;
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	public static void SellNuke(){
		cash += 100000;
		instance.m_text.text = "" + cash;
	}
}
