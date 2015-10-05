using UnityEngine;
using System.Collections;

public class PlayerController : MonoBehaviour {

	//PUBLIC INSTANCE VARIABLES
	public float speed;

	//GAMEOBJECTS
	public GameObject PlayerBullet; //the prefab
	public GameObject BulletPosition;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {

		//fire @ spacebar 
		if (Input.GetKeyDown ("space")) {
			//instantiate bullet
			GameObject bullet = (GameObject)Instantiate (PlayerBullet);
			bullet.transform.position = BulletPosition.transform.position; //iniital position

		}

		float x = Input.GetAxisRaw ("Horizontal"); // -1, 0, 1 for left, no input, right
		float y = Input.GetAxisRaw ("Vertical");   // -1, 0, 1 for down, no input, up

		//create dirction vctor, normalize for unit vector
		Vector2 direction = new Vector2 (x, y).normalized;

		//call function that computes/sets player position
		Move (direction);
	}

	void Move(Vector2 direction)
	{
		//fix boundary to players moves
		Vector2 min = Camera.main.ViewportToWorldPoint (new Vector2 (0, 0)); //bottom left
		Vector2 max = Camera.main.ViewportToWorldPoint (new Vector2 (1, 1)); // top right

		max.x = max.x - 0.225f; //half player sprite
		min.x = min.x + 0.225f; // add half sprite

		max.y = max.y - 0.285f; // half height
		min.y = min.y - 0.285f; // add half height

		//current position
		Vector2 pos = transform.position;

		//calculate new position
		pos += direction * speed * Time.deltaTime;

		//keep position in screen
		pos.x = Mathf.Clamp (pos.x, min.x, max.x);
		pos.y = Mathf.Clamp (pos.y, min.y, max.y);

		//update position
		transform.position = pos;
	}

		void OnTriggerEnter2D(Collider2D otherGameObject) {
		if (otherGameObject.tag == "EnemyMissile") {
			Destroy (gameObject);
		}
	}
}
