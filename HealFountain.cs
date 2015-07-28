using UnityEngine;
using System.Collections;

public class HealFountain : MonoBehaviour {

	public float next_pos_heal;
	public float time_between_heal;
	public float heal_power;

	public GameObject heal_efect;
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}


	void OnTriggerEnter(Collider other) //musi byt takto pojmenovana, je to systemova metoda
	{
		if (other.tag == "Player") 
		{
		
			if (other.GetComponent<Character>().health < other.GetComponent<Character>().max_healt)
			{
				if (healTime ()) 
				{
					next_pos_heal = Time.time + time_between_heal;
					other.GetComponent<Character>().health += heal_power; 
					Instantiate(heal_efect, transform.position, transform.rotation);
					audio.Play ();
				}

				if (other.GetComponent<Character>().health >= other.GetComponent<Character>().max_healt)
				{
					other.GetComponent<Character>().health =  other.GetComponent<Character>().max_healt;
				} 
		    }
	    }
	}



	
	public bool healTime()
	{
		bool casHealu = true;
		if (Time.time < next_pos_heal) 
		{
			casHealu = false;
		}
		return casHealu;
	}
}
