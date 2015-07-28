using UnityEngine;
using System.Collections;

public class GUIplayer : MonoBehaviour {

	// Use this for initialization

	public GameObject player;
	public GameObject level_system;

	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	void OnGUI()
	{
		GUI.contentColor = Color.yellow;
		GUI.Box (new Rect(10,10, Screen.width/2/ (player.GetComponent<Character>().max_healt
		                  /player.GetComponent<Character>().health) , 20), player.GetComponent<Character>().health 
		         + "/" + player.GetComponent<Character>().max_healt);

		GUI.Box (new Rect(10,35, Screen.width/2/ (player.GetComponent<Character>().max_mana
		                                          /player.GetComponent<Character>().mana) , 20), player.GetComponent<Character>().mana 
		         + "/" + player.GetComponent<Character>().max_mana);

		GUI.Box(new Rect(10,65, 100,22),"Level:" + level_system.GetComponent<LevelSystem>().level);

		GUI.Box(new Rect(120,65, 200,22),"Experience: " + level_system.GetComponent<LevelSystem>().xps + "/" + level_system.GetComponent<LevelSystem>().new_level_xps);


		        
	}
}
