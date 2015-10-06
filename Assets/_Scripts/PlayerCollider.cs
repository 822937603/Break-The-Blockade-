/// Jonathan Lee
/// File: PlayerCollider.cs
/// Last Updated: October 5th, 2015
/// Controls the collisions related to Player, also handles majority of the scoring and UI

using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class PlayerCollider : MonoBehaviour {

	// PUBLIC INSTANCE VARIABLES
	public Text scoreLabel;
	public Text livesLabel;
	public Text gameOverLabel;
	public Text finalScoreLabel;
	public int  scoreValue = 0;
	public int  livesValue = 5;



	// Use this for initialization
	void Start () {
		this._SetScore ();
		this.gameOverLabel.enabled = false;
		this.finalScoreLabel.enabled = false;
	}
	
	// Update is called once per frame
	void Update () {
		//this._SetScore ();
	}

	//Collision events and scoring
	void OnTriggerEnter2D(Collider2D otherGameObject) {

		if (otherGameObject.tag == "EnemyMissile") {
			//this._cloudAudioSource.Play ();
			this.livesValue--; // remove one life
			if (this.livesValue == 0) {
				Destroy (gameObject);
			}
			if(this.livesValue <= 0) {
				this._EndGame();
			}
		}
		if (otherGameObject.tag == "Item") {
			this.scoreValue += 1000;
		}

		this._SetScore ();
	}

	//scoring set
	private void _SetScore() {
		this.scoreLabel.text = "Score: " + this.scoreValue;
		this.livesLabel.text = "Lives: " + this.livesValue;
	}

	//For the Game Over
	private void _EndGame() {
		Destroy(gameObject);
		this.scoreLabel.enabled = false;
		this.livesLabel.enabled = false;
		this.gameOverLabel.enabled = true;
		this.finalScoreLabel.enabled = true;
		this.finalScoreLabel.text = "Final Score: " + this.scoreValue;
	}

	//void OnTriggerEnter2D(Collider2D otherGameObject) {
		//if (otherGameObject.tag == "EnemyMissile" ) {
		//	Destroy (gameObject);
		//}
	//}
}
