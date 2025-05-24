using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CreatureManagerScript : MonoBehaviour
{
	[SerializeField] private GameObject creaturePrefab;

	[SerializeField] private GameManager gameManager;


	[SerializeField, Tooltip("second")] private int[] spawnIntervalTimeArray;
	private int speedUpLevel;
	private int frame;
	[SerializeField, Tooltip("second")] private int speedUpIntervalTime;

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
		if (gameManager.GetComponent<GameManager>().isPaused) return;

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
		}
	}

	//Spawn Creature and Add Creature List
	void CreateCreature()
	{
		creatureList.Add(Instantiate(creaturePrefab));
	}
}
