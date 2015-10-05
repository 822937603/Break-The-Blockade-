using UnityEngine;
using System.Collections;

public class GameController : MonoBehaviour {

	public int missileCount;
	public GameObject missile;
	public float speed;
	public GameObject Item;
	public int itemCount;

	float maxSpawnRate = 5f;

	// Use this for initialization
	void Start () {
		speed = 5f;
		this._Missiles ();
		//this._Item ();
		InvokeRepeating ("_Missiles", 0f, 7f);
		InvokeRepeating ("_Item", 0f, 20f);
	}
	
	// Update is called once per frame
	void Update () {

	}

	public void _Missiles() {
		for (int count=0; count < this.missileCount; count++) {
			Instantiate (missile);
		}
		//Spawner ();
	}

	public void _Item()
	{
		for (int countItem=0; countItem < this.itemCount; countItem++) {
			Instantiate(Item);
		}
	}

	void Spawner()
	{
		float spawnSeconds;
		if (maxSpawnRate > 1f) {
			spawnSeconds = Random.Range (1f, maxSpawnRate);
		} 
		else {
			spawnSeconds = 1f;
			Invoke("_Missiles", spawnSeconds);
		}
	}
}
