﻿using UnityEngine;
using System.Collections;

public class BigZombieBar : MonoBehaviour {
	
	public GameObject healt_bar;
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
		healt_bar.transform.localScale = new Vector3((transform.GetComponent<Mob>().health/transform.GetComponent<Character>().max_healt)/50,0.002f,0.002f);
		
		
	}
}
