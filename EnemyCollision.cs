using UnityEngine;
using System.Collections;

public class EnemyCollision : MonoBehaviour {


	public Transform player;

	public float damage;
	// Use this for initialization
	void Start () {
	
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
		
		if (other.tag == "Player") 
		{
            other.GetComponent<Character>().TakeCloseDamage(damage);
			Destroy(gameObject);
		}
	}
}
