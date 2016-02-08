using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class LoadHighScore : MonoBehaviour {

	public Text m_text;
	// Use this for initialization
	void Start () {
		m_text.text = "High Score: " + PlayerPrefs.GetInt ("High Score", 0);
	}
}
