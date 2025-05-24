using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CreatureManagerScript : MonoBehaviour
{
	[SerializeField] private GameObject creaturePrefab;
	[SerializeField] private GameManager gameManager;

	[SerializeField, Tooltip("second * 60fps")] private int[] spawnIntervalTimeArray;
	[SerializeField, Tooltip("creatureSpeedUp")] private int speedCreatureUp;
	[SerializeField, Tooltip("second * 60fps")] private int speedUpIntervalTime;
	private int speedUpLevel;
	private int frame;

	[SerializeField] private float destroyPosition = -7.0f;

	private List<GameObject> creatureList = new List<GameObject>();

	// Start is called before the first frame update
	void Start()
	{
        // Get game manager
        gameManager = Object.FindObjectsOfType<GameManager>()[0];

        //setting 60 fps
        QualitySettings.vSyncCount = 0;
		Application.targetFrameRate = 60;


		CreateCreature();
		speedUpLevel = frame = 0;
	}

	// Update is called once per frame
	void Update()
	{
		//pause
		if (!gameManager.isPaused)
		{
			++frame;

			//spawn Creature
			if (frame % spawnIntervalTimeArray[speedUpLevel] == 0)
			{
				CreateCreature();
			}

			if (frame % speedUpIntervalTime == 0)
			{
				if (spawnIntervalTimeArray.Length != speedUpLevel + 1)
				{
					++speedUpLevel;
					Debug.Log("Speed Up");
				}
			}

			// Destroy creatures if they are inactive
			for (int i = 0; i < creatureList.Count; ++i)
			{
				if (!creatureList[i].activeInHierarchy)
				{
					Destroy(creatureList[i]);
					creatureList.RemoveAt(i);
				}
			}
		}
	}

	//Spawn Creature and Add Creature List
	void CreateCreature()
	{
		var creature = Instantiate(creaturePrefab);
		creatureList.Add(creature);
		creature.GetComponent<CreatureScript>().AddSpeed(speedCreatureUp * speedUpLevel);
	}
}
