using UnityEngine;
using System.Collections;

public class Gravity_ball_collider : MonoBehaviour {


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
		
		if (other.tag == "Enemy") 
		{
			other.GetComponent<Character>().TakeCloseDamage(damage);
			Vector3 temp = new Vector3(-2, other.GetComponent<Character>().transform.position.y, -2);
			other.GetComponent<Character>().transform.position += temp;
			//other.GetComponent<Character>().rigidbody.AddForce(-transform.forward * 20);



			//Vector3  vec = new Vector3 (other.transform.position.x,other.transform.position.y, other.transform.position.z );
			//vec -= this.transform.position;
			//vec.Normalize();
			//vec *= 10f;
			//other.GetComponent<Character>().rigidbody.AddForce(vec,ForceMode.Impulse);
			Debug.Log (other.GetComponent<Character>().health);
			
			Destroy (gameObject);
			
		}
	}
}
