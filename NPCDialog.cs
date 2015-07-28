using UnityEngine;
using System.Collections;

public class NPCDialog : MonoBehaviour {

	public string [] answer_buttons;
	public string [] questions;
	bool show_dialog = false;
	bool activate_quest = false;
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}


	void OnGUI()
	{
		GUILayout.BeginArea(new Rect(70,100,600,600));
		GUI.backgroundColor = Color.blue;
		if (show_dialog &&  !activate_quest)
		{
			GUILayout.Label(questions[0]);
			GUILayout.Label(questions[1]);
			if (GUILayout.Button(answer_buttons[0]))
			{
				activate_quest = true;
				show_dialog = false;
			}
			if (GUILayout.Button(answer_buttons[1]))
			{
				show_dialog = false;
			}
		}

		if (show_dialog && activate_quest)
		{
			GUILayout.Label(questions[2]);
			 if (GUILayout.Button(answer_buttons[2]))
			{
				show_dialog = false;
			}
		}
		GUILayout.EndArea();
	}

	void OnTriggerEnter()
	{
		show_dialog = true;
		Debug.Log("in the dialog");
	}

	void OnTriggerExit()
	{
		show_dialog  = false;
	}
}
