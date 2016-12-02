using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class expSystem : MonoBehaviour {
	
	public float skillPoint = 0;
	public float level = 1;

	bool levelUp = false;
	
	public Text skillPointText;
	private int totalSkillPoints = 0;

	public Text levelText;
	private int totalLevel = 1;

	// Use this for initialization
	void Start () {
		UpdateSkillPointText();
		UpdateLevelText();
	}
	
	// Update is called once per frame
	void Update () {

		if (levelUp == true)
		{
			skillPoint++;
			Debug.Log(skillPoint);

			level++;
			Debug.Log(level);

			levelUp = false;

			UpdateLevelText();
			UpdateSkillPointText();
		}
	}

	public void islevelUp ()
	{
		levelUp = true;
	}

	private void UpdateSkillPointText()
	{
		string skillPointMessage = "Skill Points:   " + skillPoint;
		skillPointText.text = skillPointMessage;
	}

	private void UpdateLevelText()
	{
		string levelMessage = "Level:   " + level;
		levelText.text = levelMessage;
	}
}