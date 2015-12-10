using UnityEngine;
using System.Collections;

public class OffenseAI : MonoBehaviour {

	public Transform[] pathing;

	public Hashtable pathInfo = new Hashtable();

	public float speed;

	void Start ()
	{
		pathInfo.Add ("path", pathing);
		pathInfo.Add ("orienttopath", true);
		pathInfo.Add ("speed", speed);
		pathInfo.Add ("easetype", iTween.EaseType.linear);

		iTween.MoveTo (gameObject, pathInfo);
	}
}
