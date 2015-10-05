using UnityEngine;
using System.Collections;

[System.Serializable]
public class Speed {
	public float minSpeed, maxSpeed;
}

[System.Serializable]
public class Drift {
	public float minDrift, maxDrift;
}

[System.Serializable]
public class Boundary {
	public float xMin, xMax, yMin, yMax;
}

public class EnemyController : MonoBehaviour {
	//float speed;
	public Speed speed;
	public Drift drift;
	public Boundary boundary;

	AudioSource enemySound;
	
	// PRIVATE INSTANCE VARIABLES
	private float _CurrentSpeed;
	private float _CurrentDrift;
	
	// Use this for initialization
	void Start () {
		this._Reset ();
		enemySound = GetComponent<AudioSource> ();
	}
	
	// Update is called once per frame
	void Update () {
		Vector2 currentPosition = gameObject.GetComponent<Transform> ().position;
		currentPosition.x -= this._CurrentDrift;
		currentPosition.y += this._CurrentSpeed;
		gameObject.GetComponent<Transform> ().position = currentPosition;
		
		// Check bottom boundary
		if (currentPosition.x <= boundary.xMin) {
			this._Reset();
		}
	}
	
	// resets the gameObject
	private void _Reset() {
		this._CurrentDrift = Random.Range (drift.minDrift, drift.maxDrift);
		this._CurrentSpeed = Random.Range (speed.minSpeed, speed.maxSpeed);
		Vector2 resetPosition = new Vector2 (boundary.xMax, Random.Range(boundary.yMin, boundary.yMax));
		gameObject.GetComponent<Transform> ().position = resetPosition;
}

	void OnTriggerEnter2D(Collider2D otherGameObject) {
		if (otherGameObject.tag == "Missile") {
			enemySound.Play();
			this._Reset();
			//Destroy (gameObject);

		}
		if (otherGameObject.tag == "Player") {
			enemySound.Play();
			this._Reset();
			//Destroy (gameObject);
	}
	}
}
