using UnityEngine;
using System.Collections;

public class DraggableGUIElement : MonoBehaviour {
	public static DraggableGUIElement dragging = null;
	public IEnumerator m_followMouse;
	[System.Serializable]
	public class Border
	{
		public float m_minX;
		public float m_maxX;
		public float m_minY;
		public float m_maxY;
	}
	public void Start(){
		m_followMouse = FollowMouse ();
	}
	public Border m_border;
	Vector3 m_lastMousePosition;

	public void OnMouseDown(){
		if (dragging == null) {
			dragging = this;
			StartCoroutine (m_followMouse);
		} else if (dragging == this) {
			dragging = null;
			StopCoroutine (m_followMouse);
		}
		Debug.Log ("DOWN");
		m_lastMousePosition = GetClampedMousePosition ();
	}

	Vector3 GetClampedMousePosition(){
		Vector3 mousePosition = Camera.main.ScreenToWorldPoint (Input.mousePosition);
		Debug.Log (mousePosition);
		return mousePosition;
	}

	public IEnumerator FollowMouse()
	{
		while (true) {
			Debug.Log ("DRAG");
			Vector3 delta = GetClampedMousePosition () - m_lastMousePosition;
			delta = Camera.main.ScreenToViewportPoint (delta);

			transform.position += delta;

			Vector3 position = transform.position;

			position.x = Mathf.Clamp (position.x, m_border.m_minX, m_border.m_maxX);
			position.y = Mathf.Clamp (position.y, m_border.m_minY, m_border.m_maxY);
			position.z = 0;

			transform.position = position;

			m_lastMousePosition = GetClampedMousePosition ();
			yield return new WaitForEndOfFrame ();
		}
	}
}
