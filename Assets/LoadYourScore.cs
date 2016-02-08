using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class LoadYourScore : MonoBehaviour {
	public Text m_text;
	// Use this for initialization
	void Start () {
		m_text.text = "Your Score: " + PlayerPrefs.GetInt ("Your Score", 0);
	}

}
