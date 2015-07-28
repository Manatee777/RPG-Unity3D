using UnityEngine;
using System.Collections;

public class TemplarSpells : CastSystem {

	public GameObject gravity_ball_efekt;

	public GameObject fireball_efekt;
	public Transform fireball_spawn;

	public GameObject heal_efekt;
	public Transform heal_spawn;

	public GameObject player;




	// Use this for initialization
	void Start () {
	

		}
	// Update is called once per frame
	void Update () {



		heal_efekt.transform.position = player.transform.position;


	    if (Input.GetKeyDown (KeyCode.Mouse1)) 
		{
			fireball ();
		}


		
		if (Input.GetKeyDown (KeyCode.F3)) {
			gravity_Ball ();
		}


		if (Input.GetKeyDown (KeyCode.F2)) 
		{
			heal ();
		}
	
	 }


	public override void UtocneKouzlo (float distance, float casttime, float mana_cost)
	{
		base.UtocneKouzlo (distance, casttime, mana_cost);

	}

	public override void ObranneKouzlo (float healed, float casttime, float mana_cost)
	{
		base.ObranneKouzlo (healed, casttime, mana_cost);
		
	}

	void fireball()
	{
		UtocneKouzlo (15, 0.5f,10);

		if (efect_release == true) 
		{
			Instantiate (fireball_efekt, fireball_spawn.position, fireball_spawn.rotation);
			audio.Play();
		}
				
	}



	void gravity_Ball()
	{
		UtocneKouzlo (15, 2,10);

		if (efect_release == true) 
		{
			Instantiate (gravity_ball_efekt, fireball_spawn.position, fireball_spawn.rotation);
		}
		
	}

	void heal()
	{
		ObranneKouzlo(5,3, 10);

		if (efect_release == true)
		{

			if (player.GetComponent<Character>().health < player.GetComponent<Character>().max_healt)
			{
			player.GetComponent<Character>().health += 5;

				if (player.GetComponent<Character>().health >= player.GetComponent<Character>().max_healt)
				{
					player.GetComponent<Character>().health =  player.GetComponent<Character>().max_healt;
				}
			    Instantiate(heal_efekt, heal_spawn.position, heal_spawn.rotation);
			}
		}

	}


	}




		


 
