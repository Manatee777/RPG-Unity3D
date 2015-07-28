using UnityEngine;
using System.Collections;

public class SpellMover : MonoBehaviour {

	public float projectile_speed;
	// Use this for initialization
	void Start () {
	
		rigidbody.velocity = transform.forward * projectile_speed;
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
