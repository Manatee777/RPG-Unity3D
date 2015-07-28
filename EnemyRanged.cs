using UnityEngine;
using System.Collections;

public class EnemyRanged : Character {
	   

	public Transform player;

	public float dosah;
	public float dosahMagie;

	public AnimationClip beh;
	public AnimationClip klid;

	public float rychlost;

	public CharacterController charcontroler;

	public GameObject die_efekt;

	public GameObject heal_potion_model;
	public GameObject mana_potion_model;
	public GameObject game_engine_instance;


	public bool umiram_menu;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {

		if (vDosah ()) 
		{
			Priblizit();
		}

		else	animation.CrossFade (klid.name);
	
	}



	bool vDosah()
	{
		if (Vector3.Distance (transform.position, player.transform.position) < dosah) 
		{
		return true;
		} 
		else return false;
	}



	void Priblizit()
	{
		if (player.GetComponent<Character>().health>0)
		{
		 transform.LookAt (player.position);
		 if (Vector3.Distance (transform.position, player.transform.position) > 5) 
		 {
			charcontroler.SimpleMove (transform.forward * rychlost);
			animation.CrossFade (beh.name);
		 }
		}
	}


	void Zacasti()
	{
		if (player != null) 
		{
		}
	}


	void OnMouseOver ()
	{
		//instance_kolizí;.GetComponent<CollisionTriggers> ().nepritel = gameObject;
		player.GetComponent<Combat> ().nepritel = gameObject;
		player.GetComponent<CastSystem> ().nepritel = gameObject;
		player.GetComponent<TemplarSpells> ().nepritel = gameObject;

	}

	public override void Die()
	{
		base.Die();
		Instantiate(die_efekt, transform.position, transform.rotation);

		if (gameObject.name == "RedDragon"){
	    
			game_engine_instance.GetComponent<GameEngine>().game_over_menu = true;
		}
		RandomLoot();
		Destroy(gameObject);
	}

	public void RandomLoot()
	{
		int random_loot = Random.Range(1,4);
		switch(random_loot)
		{
		case 1: 
			//Debug.Log("jednicka");
			Instantiate(heal_potion_model, transform.position, transform.rotation);
			break;
			
		case 2: 
			//Debug.Log("dvojka");
			Instantiate(mana_potion_model, transform.position, transform.rotation);
			break;
			
		case 3: 
			//Debug.Log("trojka");
			break;
		}
		
	}
	
}
