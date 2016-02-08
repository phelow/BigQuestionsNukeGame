using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class Refinery : MonoBehaviour {
	public float m_generationRate;
	public float m_overheatRate;
	public Image m_sprite;

	public int m_heatLevel = 0;
	// Use this for initialization
	void Start () {
		m_generationRate = Random.Range (5.0f, 15.0f);
		m_overheatRate = Random.Range (.5f, 1.5f);

		StartCoroutine (GenerateUranium ());
		StartCoroutine (OverHeat ());
	}

	private IEnumerator GenerateUranium(){
		while (true) {
			yield return new WaitForSeconds (m_generationRate);
			ResourceManager.AddUranium ();
			m_generationRate *= .99f;
		}
	}

	private IEnumerator OverHeat(){
		while (true) {
			yield return new WaitForSeconds (m_overheatRate);
			m_overheatRate *= .99f;
			m_heatLevel++;

			m_sprite.color = Color.Lerp (Color.white, Color.red, m_heatLevel / 100.0f);

			if (m_heatLevel > 100) {
				Explode ();
			}
		}
	}

	public void CoolDown(){
		if (FireHose.enabled) {
			m_heatLevel -= 10;
			if (m_heatLevel < 0) {
				m_heatLevel = 0;
			}
			m_sprite.color = Color.Lerp (Color.white, Color.red, m_heatLevel / 100.0f);
		} else {
			//TODO: error sound and accompanying tutorial text
			Debug.LogError("Tutorial system not implemented");
		}
	}

	private void Explode(){
		Destroy (this.gameObject);
	}
}
