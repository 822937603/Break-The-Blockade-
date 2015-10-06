/// Jonathan Lee
/// File: BackgroundController.cs
/// Last Updated: October 5th, 2015
/// Controls the background scroll


using UnityEngine;
using System.Collections;

public class BackgroundController : MonoBehaviour {

	// PUBLIC INSTANCE VARIABLES
	public float speed;
	
	// Use this for initialization
	void Start () {
		this._Reset ();
	}
	
	// Update is called once per frame
	void Update () {
		Vector2 currentPosition = gameObject.GetComponent<Transform> ().position;
		currentPosition.x -= speed;
		gameObject.GetComponent<Transform> ().position = currentPosition;
		
		// Check bottom boundary
		if (currentPosition.x <= -26.23) {
			this._Reset();
		}
	}

	//Resets the background to create scroll effect
	private void _Reset() {
		Vector2 resetPosition = new Vector2 (74.3f, -0.3f);
		gameObject.GetComponent<Transform> ().position = resetPosition;
}
}
