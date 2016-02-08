using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class Country : MonoBehaviour {
	public int m_nNukes;
	public Text m_nukeText;
	public CursorMode m_cursorMode = CursorMode.Auto;
	public Vector2 m_hotSpot = Vector2.zero;

	// Use this for initialization
	void Start () {
		m_nNukes = 1;
		StartCoroutine (AddNukes());
	}

	private void KillYourNeighbor(GameObject neighbor){
		//TODO: game over

		Debug.Log ("GameOver");
		ResourceManager.GameOver ();
	}

	private IEnumerator AddNukes(){
		//TODO: replace with a more sensible algorithm
		while (true) {
			int cycles = Random.Range (5, 100);
			float proliferationRate = Random.Range (2.0f, 15.0f);
			for (int i = 0; i < cycles; i++) {
				m_nNukes++;
				m_nukeText.text = "" + m_nNukes;

				GameObject [] neighbors = GameObject.FindGameObjectsWithTag("Country");
				//Check to see if we have 50% more nukes than our neighbors
				foreach (GameObject neighbor in neighbors) {
					if (neighbor.GetComponent<Country>().m_nNukes + 5 < m_nNukes) {
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
			ResourceManager.AddCash ();

			Cursor.SetCursor (null, m_hotSpot, m_cursorMode);
		}
	}
}
