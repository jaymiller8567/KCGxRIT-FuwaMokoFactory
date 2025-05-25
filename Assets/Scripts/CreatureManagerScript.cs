using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CreatureManagerScript : MonoBehaviour
{
	[SerializeField] private GameObject creaturePrefab;
	[SerializeField] private GameManager gameManager;
	[SerializeField] private Image speedUpText;
	private int speedUpTextFrame = 0;

	[SerializeField, Tooltip("second * 60fps")] private int[] spawnIntervalTimeArray;
	[SerializeField, Tooltip("creatureSpeedUp")] private float speedCreatureUp;
	[SerializeField, Tooltip("second * 60fps")] private int speedUpIntervalTime;
	[SerializeField, Tooltip("ConveyorBeltImage")] private Image conveyorBeltImage;
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

		speedUpText.enabled = false;
	}

	// Update is called once per frame
	void Update()
	{
		//pause
		if (!gameManager.isPaused)
		{
			++frame;

			if (frame % speedUpIntervalTime == 0)
			{
				if (spawnIntervalTimeArray.Length != speedUpLevel + 1)
				{
					++speedUpLevel;
					Debug.Log("Speed Up");
					speedUpText.enabled = true;

					conveyorBeltImage.GetComponent<ConveyorBeltLoop>().SpeedUp();

					// Speed up existing creatures
					foreach (var creature in creatureList)
					{
						if (creature != null)
						{
                            creature.GetComponent<CreatureScript>().AddSpeed(speedCreatureUp * speedUpLevel);
                        }
                    }
				}
			}
			if (speedUpText.enabled)
			{
				speedUpTextFrame += 1;

				if (speedUpTextFrame >= 90)
				{
					speedUpText.enabled = false;
					speedUpTextFrame = 0;
				}
			}

            //spawn Creature
            if (frame % spawnIntervalTimeArray[speedUpLevel] == 0)
            {
                CreateCreature();
            }

            // Destroy creatures if they are inactive
            for (int i = 0; i < creatureList.Count; ++i)
			{
				if (creatureList[i] == null) continue;

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
