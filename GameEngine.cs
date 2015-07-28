using UnityEngine;
using System.Collections;

public class GameEngine : MonoBehaviour {

	public GUIText max_hp_text;
	public GUIText current_hp_text;
	public GUIText max_mana_text;
	public GUIText current_mana_text;

	public bool escape_menu = false;
	bool show_dialog = true;
	public bool game_over_menu = false;

	public GameObject dragon_boss;

	public GameObject player; 

	public AudioSource main_theme;
	// Use this for initialization
	void Start () {
	
		audio.Play();
	}
	
	// Update is called once per frame
	void Update () {



	
		max_hp_text.text = player.GetComponent<Character>().max_healt.ToString();
		current_hp_text.text = player.GetComponent<Character>().health.ToString();

		max_mana_text.text = player.GetComponent<Character>().max_mana.ToString();
		current_mana_text.text = player.GetComponent<Character>().mana.ToString();


		if (player.GetComponent<Character>().health < 31)
		{
			current_hp_text.color = Color.red;
		}

		if (player.GetComponent<Character>().health > 30)
		{
			current_hp_text.color = Color.white;
		}

		if (player.GetComponent<Character>().mana < 31)
		{
			current_mana_text.color = Color.red;
		}

		if (player.GetComponent<Character>().mana > 30)
		{
			current_hp_text.color = Color.white;
		}




		if (Input.GetKeyDown (KeyCode.Escape))
		{
			escape_menu = true;
		}

		if (Input.GetKeyDown (KeyCode.Escape))
		{
			escape_menu = true;
		}



	}


	void OnGUI()
	{
		GUILayout.BeginArea(new Rect(Screen.width/2-150,250,300,600)); 
		GUI.backgroundColor = Color.grey;



		if (escape_menu && show_dialog)
		{
			GUILayout.Label("                          " +
			                "GAME PAUSED");

			Time.timeScale = 0;

			if (GUILayout.Button("POKRACOVAT"))
			{
				

				escape_menu = false;
				if (player.GetComponent<Character>().health > 0){
				Time.timeScale = 1;
				}
			}

			if (GUILayout.Button("RESTART"))
			{

				Application.LoadLevel("scene1");
				escape_menu = false;
				Time.timeScale = 1;
			}
		


			if (GUILayout.Button("KONEC HRY"))
			{
				
				Application.Quit();
				escape_menu = false;
				Time.timeScale = 1;
			}
		}

		if (game_over_menu && show_dialog)
		{

			StartCoroutine(game_over_menu_skok());

			GUILayout.Label("                          " +
			                "GAME OVER");
			
			GUILayout.Label("                          ");
			
			GUILayout.Label("Plenitel byl poražen! Dokázal jsi to hrdino! Sláva!");

			if (GUILayout.Button("RESTART"))
			{
				
				Application.LoadLevel("scene1");
				escape_menu = false;
				Time.timeScale = 1;
			}

			if (GUILayout.Button("KONEC HRY"))
			{
				
				Application.Quit();
				escape_menu = false;
				Time.timeScale = 1;
			}
			
		}


		GUILayout.EndArea();
	}

	IEnumerator game_over_menu_skok()
	{
		
		yield return new WaitForSeconds(3); // wait for two seconds.

		Time.timeScale = 0;


	
		
		
	}
}
