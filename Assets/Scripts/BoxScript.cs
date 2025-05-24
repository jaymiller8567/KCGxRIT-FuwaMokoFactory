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
	[SerializeField] private GameObject box;
	private int closeSpriteNum;
	private bool close;
	private bool spawnNextBoxOnce;
	private int spriteNextTime;
	[HideInInspector] public GameObject boxManager;
	[HideInInspector] public int boxNumber;

	// Start is called before the first frame update
	void Start()
	{
		boxInCreatureNum = spriteNextTime = closeSpriteNum = 0;
		close = spawnNextBoxOnce = false;
	}

	// Update is called once per frame
	void Update()
	{
		if(close && !spawnNextBoxOnce)
        {
			ColorChangeAlpha();

			if (closeSpriteNum < closeSprite.Length) 
            {
				//close sprite change
				this.GetComponent<SpriteRenderer>().sprite = closeSprite[closeSpriteNum];

				Debug.Log(this.gameObject);
			}
            else
            {
				//change sprite finish
				FinishClose();
			}

			//sprite change number
            if (++spriteNextTime % 10==0)
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
			GetComponent<Rigidbody2D>().velocity += new Vector2(0, -40);
			
			if(boxNumber==1)
				boxManager.GetComponent<BoxManager>().SpawnBox1();
			if (boxNumber == 2)
				boxManager.GetComponent<BoxManager>().SpawnBox2();

			foreach (var creature in inCreatureArray)
			{
				//Destroy(creature);
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
		hitCreature.GetComponent<CreatureScript>().ResetVelocity();
		Destroy(hitCreature.GetComponent<DragAndDrop>());
		inCreatureArray.Add(hitCreature);

		hitCreature = null;


		Num();
	}

	private void Num()
    {
		if (++boxInCreatureNum == maxCreatureNum)
		{
			close = true;
		}
	}
}
