using UnityEngine;
using System.Collections;

public class Mana_potion : MonoBehaviour {

	public float mana_potion_power;


	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}


	
	void OnTriggerEnter(Collider other)
	{
		if (other.tag == "Player")
		{
			if (other.GetComponent<Character>().mana < other.GetComponent<Character>().max_mana)
			{
				other.GetComponent<Character>().mana += mana_potion_power;
				//Debug.Log("trigger");
				Destroy(gameObject);
			}
			
			if (other.GetComponent<Character>().mana >= other.GetComponent<Character>().max_mana)
			{
				other.GetComponent<Character>().mana =  other.GetComponent<Character>().max_mana;
			} 
		}
		
	}
}
