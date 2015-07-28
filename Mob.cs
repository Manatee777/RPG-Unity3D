using UnityEngine;
using System.Collections;

public class Mob : Character {


	public float rychlost;
	public float dosah;
	public float dosahZbrane;



	public float nextposatack;
	public float timebetweenatacks;
	public float atackperminute;

	public CharacterController charcontroler;
	public Transform player;

	public GameObject koliznik;

	public AnimationClip beh;
	public AnimationClip klid;
	public AnimationClip utok;

	public bool utocim_npc;
	public bool umiram_npc;

	public bool umrel_jsem = false;

	public GameObject die_efekt;

	public GameObject heal_potion_model;
	public GameObject mana_potion_model;


	public bool dosahBool = false;

	//waypoints
	public GameObject[] waypoints;
	public int current_waypoint = 0;
	public Vector3 range;

	public AudioClip kousanec;

	// Use this for initialization
	void Start ()
	{
		timebetweenatacks = 60 / atackperminute;
		get_damage = str * 2;
	}
	
	// Update is called once per frame
	void Update () {
	
		if (vDosahu ()) 
		{
		dosahBool = true;
		Vyrazit ();
	    
		
		} 

		else 
		{

		animation.CrossFade (klid.name);
			//WAYPOINTY
		//	range = waypoints[current_waypoint].transform.position - transform.position;
			
			//if (range.magnitude < 1)
			//{
			//	current_waypoint++;
				
			//	if (current_waypoint == waypoints.Length)
			//	{
			//	current_waypoint = 0;
			//}
			//}
			
			//else 
			//{
			//	rigidbody.velocity = range.normalized * transform.GetComponent<Mob>().rychlost;
			//	animation.CrossFade(gameObject.GetComponent<Mob>().beh.name);
			//	transform.LookAt(waypoints[current_waypoint].transform);
			//}
		
	     }


		if (vDosahuUderu ()) 
		{
			if (player.GetComponent<Character>().health>0)
			{
			  if (CasUtoku () )
			  {
			
				StartCoroutine(WaitAttack());
				animation.CrossFade (utok.name);  
				nextposatack = Time.time + timebetweenatacks;
		  
				Debug.Log("je cas");
				StartCoroutine(WaitAttack());
				
				
				StartCoroutine(WaitAndCallback(animation[utok.name].length));
			  }
			}
		}
						    
	
		
		if(!animation.IsPlaying(utok.name))
		{
			utocim_npc = false;

		}

		
		if(animation.IsPlaying(utok.name))
		{
			utocim_npc = true;

		}
	

	}


    bool vDosahuUderu()
	{
	if (Vector3.Distance (transform.position, player.position) < dosahZbrane) 
	{
	return true;

    } 
	else return false;
	}



	bool vDosahu()
	{
	 if (Vector3.Distance (transform.position, player.position) < dosah)
	 {
	 return true;
	 //bool pro waypointy

     } 
	 else return false;
	}



	void Vyrazit()
	{

		if (player.GetComponent<Character>().health>0)
		{
		 if ((!utocim_npc) && (umrel_jsem == false))
			{
		    transform.LookAt (player.position);
		    charcontroler.SimpleMove (transform.forward * rychlost);
		    animation.CrossFade (beh.name);
		    }
		}
	}


	void Zautoc()
	{
		if (player != null) 
		{
			if (!Combat.invul)
			{
			player.GetComponent<Character> ().TakeCloseDamage (get_damage);
				audio.Play();
			}
		} 
	}


	IEnumerator WaitAttack()
	{
		yield return new WaitForSeconds(0.5f);
		Zautoc();
	}


	IEnumerator WaitAndCallback(float waitTime)
	{
		yield return new WaitForSeconds(waitTime);	   
	}



	private bool CasUtoku()
	{
		bool casUtoku = true;
	    if (Time.time < nextposatack)
		{
     	casUtoku = false;
		}
	return casUtoku;
	}

	public override void Die()
	{
		base.Die();
		umrel_jsem = true;
		Instantiate(die_efekt, transform.position, transform.rotation);
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
	
	void OnMouseOver ()
	{
		//instance_kolizí;.GetComponent<CollisionTriggers> ().nepritel = gameObject;
		player.GetComponent<Combat> ().nepritel = gameObject;
		player.GetComponent<CastSystem> ().nepritel = gameObject;
		player.GetComponent<TemplarSpells> ().nepritel = gameObject;
	}
}
