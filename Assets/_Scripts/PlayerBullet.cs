using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class PlayerBullet : MonoBehaviour {

	float speed;

	public Text scoreLabel;
	public int  scoreValue;

	//private AudioSource[] _audioSources;
	//private AudioSource _missileExplodeAudioSource, _itemCollectAudioSource;
	// Use this for initialization
	void Start () {
		speed = 8f;
		//this._audioSources = this.GetComponents<AudioSource> ();
		//this._missileExplodeAudioSource = this._audioSources [1];
		//this._itemCollectAudioSource = this._audioSources [2];
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
			//this._missileExplodeAudioSource.Play();
			Destroy (gameObject);
		}

		if (otherGameObject.tag == "Item") {
			//this._itemCollectAudioSource.Play();
			this.scoreValue -= 1000;
			Destroy (gameObject);
		}
	}

		private void _SetScore() {
		this.scoreLabel.text = "Score: " + -(this.scoreValue);
		//this._islandAudioSource.Play (); // play yay sound
	}	//this.scoreValue += 100; // add 100 points
}
