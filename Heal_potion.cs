using UnityEngine;
using System.Collections;

public class Heal_potion : MonoBehaviour {

	// Use this for initialization




	public float potion_power;

	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	void OnTriggerEnter(Collider other)
	{
		if (other.tag == "Player")
		{
			if (other.GetComponent<Character>().health < other.GetComponent<Character>().max_healt)
			{
				other.GetComponent<Character>().health += potion_power;
				//Debug.Log("trigger");
				Destroy(gameObject);
			}

			if (other.GetComponent<Character>().health >= other.GetComponent<Character>().max_healt)
			{
				other.GetComponent<Character>().health =  other.GetComponent<Character>().max_healt;
			} 
		}

	}
}
