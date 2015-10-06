/// Jonathan Lee
/// File: CratePickuoController.cs
/// Last Updated: October 5th, 2015
/// Controls the item pickup, movement and collider function

using UnityEngine;
using System.Collections;

[System.Serializable]
public class Area {
	public float xMin, xMax, yMin, yMax;
}

[System.Serializable]
public class SpeedItem {
	public float minSpeedy, maxSpeedy;
}
public class CratePickupController : MonoBehaviour {

	// PUBLIC INSTANCE VARIABLES
	public SpeedItem Speedy;
	public Drift drift;
	public float speed;
	public Area boundary;

	AudioSource itemSound;

	// PRIVATE INSTANCE VARIABLES
	private float _CurrentSpeed;
	private float _CurrentDrift;
	
	// Use this for initialization
	void Start () {
		this._Reset ();
		itemSound = GetComponent<AudioSource> ();
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

	// resets crate position
	private void _Reset() {
		this._CurrentDrift = Random.Range (drift.minDrift, drift.maxDrift);
		this._CurrentSpeed = Random.Range (Speedy.minSpeedy, Speedy.maxSpeedy);
		Vector2 resetPosition = new Vector2 (boundary.xMax, Random.Range(boundary.yMin, boundary.yMax));
		gameObject.GetComponent<Transform> ().position = resetPosition;
	}

	//Collision code for sound and reset
	void OnTriggerEnter2D(Collider2D otherGameObject) {

		if (otherGameObject.tag == "Player") {
			//AudioSource.PlayClipAtPoint(itemSound, transform.position);
			itemSound.Play();
			//Destroy (this.gameObject);
			this._Reset();
		}
	}
	}


