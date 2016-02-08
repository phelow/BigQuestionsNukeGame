using UnityEngine;
using System.Collections;

public class Tack : MonoBehaviour {
	public Texture2D m_fireHoseCursor;
	public CursorMode m_cursorMode = CursorMode.Auto;
	public Vector2 m_hotSpot = Vector2.zero;

	public static bool enabled;

	// Use this for initialization
	public void PickupMouseCursor(){
		Cursor.SetCursor (m_fireHoseCursor, m_hotSpot, m_cursorMode);
		enabled = true;
		FireHose.enabled = false;
		Destroy (this.gameObject);
	}
}
