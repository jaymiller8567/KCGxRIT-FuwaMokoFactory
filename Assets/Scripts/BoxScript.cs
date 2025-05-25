using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BoxScript : MonoBehaviour
{
	private GameObject hitCreature;
	private List<GameObject> inCreatureArray= new List<GameObject>();
	private int boxInCreatureNum;
	[SerializeField] private int maxCreatureNum;
	[SerializeField] private Sprite[] closeSprite;
	private int closeSpriteNum;
	private bool close;
	private bool spawnNextBoxOnce;
	private int spriteNextTime;
	private bool start = true;
	[HideInInspector] public GameObject boxManager;
	[HideInInspector] public int boxNumber;
	[SerializeField] private AudioClip inBox;

	// Start is called before the first frame update
	void Start()
	{
		boxInCreatureNum = spriteNextTime = closeSpriteNum = 0;
		close = spawnNextBoxOnce = false;
		start = true;
	}

	// Update is called once per frame
	void Update()
	{
		if(start)
		{
			if (this.transform.position.y <= 0)
			{
				this.GetComponent<Rigidbody2D>().velocity = new Vector3(0, 0, 0);
				this.transform.position = new Vector3(this.transform.position.x, 0.7f, 1.0f);
				start = false;
			}
			else
			{
				GetComponent<Rigidbody2D>().velocity += new Vector2(0, -5);
			}
		}

		if(close && !spawnNextBoxOnce)
		{
			ColorChangeAlpha();

			if (closeSpriteNum < closeSprite.Length) 
			{
				//close sprite change
				this.GetComponent<SpriteRenderer>().sprite = closeSprite[closeSpriteNum];
			}
			else
			{
				//change sprite finish
				FinishClose();
			}

			//sprite change number
			if (++spriteNextTime % 3==0)
			{
				++closeSpriteNum;
			}
		}


		if (hitCreature == null) return;
		if (hitCreature.GetComponent<DragAndDrop>() == null) return;

		if(!hitCreature.GetComponent<DragAndDrop>().isDragging)
		{
			InCreatureBox();
		}
	}

	//box close finish
	private void FinishClose()
	{
		if (!spawnNextBoxOnce)
		{
			GetComponent<Rigidbody2D>().velocity += new Vector2(boxNumber == 1 ? 40 : -40, 0);
			
			if(boxNumber==1)
				boxManager.GetComponent<BoxManager>().SpawnBox1();
			if (boxNumber == 2)
				boxManager.GetComponent<BoxManager>().SpawnBox2();

			foreach (var creature in inCreatureArray)
			{
				Destroy(creature);
			}

			spawnNextBoxOnce = true;
		}
	}

	//creature alpha change color
	private void ColorChangeAlpha()
	{
		foreach (var creature in inCreatureArray)
		{
			var color = creature.GetComponent<SpriteRenderer>().color;
			creature.GetComponent<SpriteRenderer>().color = new Color(
				color.r, color.g, color.b, color.a - 0.1f
				);
		}
	}

	private void OnTriggerEnter2D(Collider2D collision)
	{
		//box close
		if (close) return;

		//hit object for creature
		if (collision.GetComponent<DragAndDrop>() == null) return;
		if (!collision.GetComponent<DragAndDrop>().isDragging) return;

		hitCreature = collision.gameObject;
		collision.gameObject.GetComponent<CreatureScript>().inBox = this.gameObject;
	}

	private void OnTriggerExit2D(Collider2D collision)
	{
		//hit object for creature
		if (collision.GetComponent<DragAndDrop>() == null) return;
		if (!collision.GetComponent<DragAndDrop>().isDragging) return;

		hitCreature = null;
		collision.gameObject.GetComponent<CreatureScript>().inBox = null;
	}

	public void InCreatureBox()
	{
		//on box creature
		hitCreature.GetComponent<CreatureScript>().ResetVelocity();
		hitCreature.GetComponent<CreatureScript>().IsCollected = true;
		Destroy(hitCreature.GetComponent<DragAndDrop>());


		//Check fuwa or moco type
		if (hitCreature.GetComponent<CreatureScript>().Type == "moco" && boxNumber == 1)
		{
			ScoreScript.instance.addToScore(hitCreature.GetComponent<CreatureScript>().IsRainbow);
		}
		else if (hitCreature.GetComponent<CreatureScript>().Type == "fuwa" && boxNumber == 2)
		{
			ScoreScript.instance.addToScore(hitCreature.GetComponent<CreatureScript>().IsRainbow);
		}
		else
		{
			//different kind
			ScoreScript.instance.breakCombo();

			//escape out screen
			hitCreature.GetComponent<Rigidbody2D>().velocity = new Vector2(boxNumber == 1 ? 5 : -5, 10);
			hitCreature.AddComponent<FrameDelete>().lifeTime = 120;
			Debug.Log("Different Kind");

			return;
		}

		//num plus
		Num();
	}

	private void Num()
	{
		// add list
		inCreatureArray.Add(hitCreature);

		//creature max in box
		if (++boxInCreatureNum == maxCreatureNum)
		{
			close = true;
		}

		//initialize
		hitCreature = null;

		GetComponent<AudioSource>().PlayOneShot(inBox);
	}
}
