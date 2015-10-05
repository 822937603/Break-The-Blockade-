﻿using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class PlayerCollider : MonoBehaviour {

	public Text scoreLabel;
	public Text livesLabel;
	public Text gameOverLabel;
	public Text finalScoreLabel;
	public int  scoreValue = 0;
	public int  livesValue = 5;

	// Use this for initialization
	void Start () {
		this._SetScore ();
	}
	
	// Update is called once per frame
	void Update () {
		//this._SetScore ();
	}
	void OnTriggerEnter2D(Collider2D otherGameObject) {

		if (otherGameObject.tag == "EnemyMissile") {
			//this._cloudAudioSource.Play (); // play thunder sound
			this.livesValue--; // remove one life
			if (this.livesValue == 0) {
				Destroy (gameObject);
			}
			//if(this.livesValue <= 0) {
				//this._EndGame();
			//}
		}
		if (otherGameObject.tag == "Item") {
			this.scoreValue += 1000;
		}
		this._SetScore ();
	}

	private void _SetScore() {
		this.scoreLabel.text = "Score: " + this.scoreValue;
		this.livesLabel.text = "Lives: " + this.livesValue;
	}

	//void OnTriggerEnter2D(Collider2D otherGameObject) {
		//if (otherGameObject.tag == "EnemyMissile" ) {
		//	Destroy (gameObject);
		//}
	//}
}
