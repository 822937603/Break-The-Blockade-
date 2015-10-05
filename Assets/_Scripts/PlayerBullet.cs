using UnityEngine;
using System.Collections;

public class PlayerBullet : MonoBehaviour {

	float speed;

	// Use this for initialization
	void Start () {
		speed = 8f;
	}
	
	// Update is called once per frame
	void Update () {
	
		//get bullets position
		Vector2 position = transform.position;

		//find new position
		position = new Vector2 (position.x + speed * Time.deltaTime, position.y);

		//update position
		transform.position = position;

		//top right screen
		Vector2 max = Camera.main.ViewportToWorldPoint (new Vector2 (1, 1));

		//distroy bullet when outside
		if (transform.position.x > max.x) 
		{
			Destroy (gameObject);
		}


	}
	void OnTriggerEnter2D(Collider2D otherGameObject) {
		if (otherGameObject.tag == "EnemyMissile") {
			Destroy (gameObject);
		}

		if (otherGameObject.tag == "Item") {
			Destroy (gameObject);
		}
		//this._islandAudioSource.Play (); // play yay sound
	}	//this.scoreValue += 100; // add 100 points
}
