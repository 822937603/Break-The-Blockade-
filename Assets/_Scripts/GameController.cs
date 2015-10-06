/// Jonathan Lee
/// File: GameController.cs
/// Last Updated: October 5th, 2015
/// Instantiates the missiles and items

using UnityEngine;
using System.Collections;

public class GameController : MonoBehaviour {

	// PUBLIC INSTANCE VARIABLES
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

	//instantiates # of missiles
	public void _Missiles() {
		for (int count=0; count < this.missileCount; count++) {
			Instantiate (missile);
		}
		//Spawner ();
	}

	//instantiates item crates
	public void _Item()
	{
		for (int countItem=0; countItem < this.itemCount; countItem++) {
			Instantiate(Item);
		}
	}

	//was experimenting pretty sure this is not used
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
