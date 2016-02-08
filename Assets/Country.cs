using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class Country : MonoBehaviour {
	public int m_nNukes;
	public Text m_nukeText;
	public CursorMode m_cursorMode = CursorMode.Auto;
	public Vector2 m_hotSpot = Vector2.zero;

	public Country [] neighbors;
	// Use this for initialization
	void Start () {
		m_nNukes = 1;
		StartCoroutine (AddNukes());
	}

	private void KillYourNeighbor(Country neighbor){
		//TODO: game over

		Debug.Log ("GameOver");
	}

	private IEnumerator AddNukes(){
		//TODO: replace with a more sensible algorithm
		while (true) {
			int cycles = Random.Range (5, 100);
			float proliferationRate = Random.Range (5.0f, 15.0f);
			for (int i = 0; i < cycles; i++) {
				m_nNukes++;
				m_nukeText.text = "" + m_nNukes;

				//Check to see if we have 50% more nukes than our neighbors
				foreach (Country neighbor in neighbors) {
					if (neighbor.m_nNukes * 1.5f < m_nNukes + 10) {
						KillYourNeighbor (neighbor);
					}
				}
				proliferationRate *= .99f;
				yield return new WaitForSeconds (proliferationRate);
			}
		}
	}

	public void AddNuke(){
		if (Tack.enabled) {
			Tack.enabled = false;

			m_nNukes++;
			m_nukeText.text = "" + m_nNukes;


			Cursor.SetCursor (null, m_hotSpot, m_cursorMode);
		}
	}
}
