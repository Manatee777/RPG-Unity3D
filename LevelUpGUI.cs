using UnityEngine;
using System.Collections;

public class LevelUpGUI : MonoBehaviour {

	// Use this for initialization
	public GameObject level_system;
	public GameObject player;

	public bool show_dialog = true;

	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	void OnGUI()
	{
		GUILayout.BeginArea(new Rect(Screen.width/2-150,250,300,600)); 
		GUI.backgroundColor = Color.grey;

		if (show_dialog && level_system.GetComponent<LevelSystem>().bool_up == true)
		{

			GUILayout.Label("");


			GUILayout.Label("                " +
				"VYBER JEDNO VYLEPSENI");


			if (GUILayout.Button("INTELIGENCE"))
			{
				player.GetComponent<Character>().inteligence += 3;
				player.GetComponent<Character>().str -= 2;
				show_dialog = false; 
				level_system.GetComponent<LevelSystem>().bool_up = false;

			}

			if (GUILayout.Button("ZASOBA MANY"))
			{
				player.GetComponent<Character>().max_mana += 3;
				player.GetComponent<Character>().max_healt -= 3;
				show_dialog = false; 

			}

			if (GUILayout.Button("REGENERACE MANY"))
			{
				player.GetComponent<Combat>().manaregen += 1;

				show_dialog = false; 

			}

			if (GUILayout.Button("REGENERACE ZIVOTA"))
			{
				player.GetComponent<Combat>().hpregen += 1;

				show_dialog = false; 

			}



			if (GUILayout.Button("ODOLNOST"))
			{
				player.GetComponent<Character>().basic_armor += 2;
				player.GetComponent<ClickToMove>().rychlost -= 0.5f;
				show_dialog = false; 

			}

			if (GUILayout.Button("RYCHLOST"))
			{
				player.GetComponent<ClickToMove>().rychlost += 0.5f;
				player.GetComponent<Character>().basic_armor -= 2;
				show_dialog = false; 

			}


			if (GUILayout.Button("VITALITA"))
			{
				player.GetComponent<Character>().max_healt += 3;
				player.GetComponent<Character>().max_mana -= 3;
				show_dialog = false; 

			}


			if (GUILayout.Button("SILA"))
			{
				player.GetComponent<Character>().str += 3;
				player.GetComponent<Character>().inteligence -= 3;
				show_dialog = false; 

			}

		}
		GUILayout.EndArea();
	}
}
