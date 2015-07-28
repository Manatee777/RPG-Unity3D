using UnityEngine;
using System.Collections;

public  class CollisionTriggers : MonoBehaviour {

	// Use this for initialization

	public GameObject nepritel;


	public float damage;
	public float spelldamage;

	public GameObject player;



	void Start () 
	{

	}
	
	// Update is called once per frame
	void Update () {


	
	}

	void OnTriggerEnter(Collider other)
	{
		if (other.tag == "Construction") 
		{
		 Destroy (gameObject);
		}

		if (other.tag == "Enemy") 
		{

			other.GetComponent<Character>().TakeCloseDamage(damage + player.GetComponent<Combat>().inteligence);
			Debug.Log (other.GetComponent<Character>().health);
		
			Destroy (gameObject);
		}
	}

	


}
