using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using System.Collections.Generic;
using System.Runtime.Serialization.Formatters.Binary;
using System.IO;

public class PauseMenu : MonoBehaviour {

	public GameObject PauseUI;
	public GameObject OptionsUI;
	public GameObject MainMenuUI;

	private bool paused = false;

	public levelingMenu attackMenu;

	//public static List<Game> savedGames = new List<Game>();

	// Use this for initialization
	void Start () {

		paused = false;

		//OptionsUI.SetActive (false);
		//MainMenuUI.SetActive (false);

		attackMenu = GetComponent<levelingMenu>();
		attackMenu.spMenu = false;
	}
	
	// Update is called once per frame
	void Update () {
	
		if (Input.GetKeyDown (KeyCode.Escape)) {

			paused = !paused;

		}

		if (paused) {

			//UnityEngine.Cursor.visible = true;
			PauseUI.SetActive (true);
			Time.timeScale = 0;
		}

		if (!paused) {

			//UnityEngine.Cursor.visible = false;
			PauseUI.SetActive (false);
			Time.timeScale = 1;
		}

	}

	public void Resume()
	{
		paused = false;
		attackMenu.spMenu = false;

	}

	public void Restart()
	{
		Application.LoadLevel (Application.loadedLevel);
	}

	//it's static so we can call it from anywhere
	/*public static void Save() 
	{
		savedGames.Add(Game.current);
		
		BinaryFormatter bf = new BinaryFormatter();
		
		//Application.persistentDataPath is a string, so if you wanted you can put that into debug.log if you want to know where save games are located
		
		FileStream file = File.Create (Application.persistentDataPath + "/savedGames.gd"); //you can call it anything you want
		
		bf.Serialize(file, savedGames);
		
		file.Close();
	}   */
	
	/*public static void Load() {
		if(File.Exists(Application.persistentDataPath + "/savedGames.gd")) {
			
			BinaryFormatter bf = new BinaryFormatter();
			
			FileStream file = File.Open(Application.persistentDataPath + "/savedGames.gd", FileMode.Open);
			
			savedGames = (List<Game>)bf.Deserialize(file);
			
			file.Close();
		}*/
	//}

	public void attackSkillMenu()
	{
		attackMenu.spMenu = true;

		paused = false;
	}

	public void Options()
	{
		OptionsUI.SetActive (true);

		/*if (Input.GetKeyDown (KeyCode.Escape))
		{
			OptionsUI.SetActive (false);
		}*/
	}

	public void MainMenu()
	{
		//MainMenuUI.SetActive (true);

		Application.LoadLevel ("Hub");
	}

	public void Exit ()
	{
		Application.Quit();
	}
}