using UnityEngine;
using System.Collections;

public class LevelSystem : MonoBehaviour {

	public float level;
	public float xps;
	public float new_level_xps;
	public GameObject player;
	public bool bool_up;
	public GameObject death_sound;
	public GameObject level_up_instance;
	// Use this for initialization
	void Start () {
	
		level = 1;
	}
	
	// Update is called once per frame
	void Update () {


	
	}

	public void gain(float xp)
	{
		xps += xp;

		//audio.Play ();
		if (xps > new_level_xps)
		{
			Debug.Log ("level up");
			audio.Play ();
			level += 1;
			levelup();
			new_level_xps = (level * 250);


		}

	}

	public void levelup()
	{
		player.GetComponent<Character>().str += 5;
		player.GetComponent<Character>().dex += 0.5f;

		player.GetComponent<Character>().inteligence += 5;
		player.GetComponent<Character>().max_mana += 10;
		player.GetComponent<Character>().max_healt += 10;
		player.GetComponent<Character>().basic_armor += 2;

		player.GetComponent<Combat>().manaregen += 1;
		player.GetComponent<Combat>().hpregen += 1;

		bool_up = true;
		level_up_instance.GetComponent<LevelUpGUI>().show_dialog = true;
	}
}
