using UnityEngine;
using System.Collections;

public class ManaFountain : MonoBehaviour {

	public float next_pos_mana;
	public float time_between_mana;
	public float mana_power;

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
			
			if (other.GetComponent<Character>().mana < other.GetComponent<Character>().max_mana)
			{
				if (manaTime ()) 
				{
					next_pos_mana = Time.time + time_between_mana;
					other.GetComponent<Character>().mana += mana_power;
				}

				if (other.GetComponent<Character>().mana >= other.GetComponent<Character>().max_mana)
				{
					other.GetComponent<Character>().mana =  other.GetComponent<Character>().max_mana;
				} 
			}
		}
	}

	
	public bool manaTime()
	{
		bool casMany = true;
		
		if (Time.time < next_pos_mana) 
		{
			casMany = false;
		}

		return casMany;
	}
}
