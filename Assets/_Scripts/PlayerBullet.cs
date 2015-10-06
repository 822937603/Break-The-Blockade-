/// Jonathan Lee
/// File: PlayerBullet.cs
/// Last Updated: October 5th, 2015
/// Controls the Player Missile and some scoring

using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class PlayerBullet : MonoBehaviour {

	// PUBLIC INSTANCE VARIABLES
	float speed;

	public Text scoreLabel;
	public int  scoreValue;


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

	//Collision Code for hits Destroy and score calculates
	void OnTriggerEnter2D(Collider2D otherGameObject) {
		if (otherGameObject.tag == "EnemyMissile") {
			//this._missileExplodeAudioSource.Play();
			Destroy (gameObject);
		}

		if (otherGameObject.tag == "Item") {
			//this._itemCollectAudioSource.Play();
			this.scoreValue -= 1000;
			Destroy (gameObject);
		}
	}

	//Sets the score
		private void _SetScore() {
		this.scoreLabel.text = "Score: " + -(this.scoreValue);

	}	
}
