using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// Basic script to allow 2D objects be dragged and dropped
public class DragAndDrop : MonoBehaviour
{
    // PRIVATE VARIABLES
    // - - - - - - - - - 
    // Is the mouse in the right spot to drag the item?
    private bool isDraggable;

    // Is it currently being dragged?
    private bool isDragging;

    // Can it be moved (is it locked?)
    public bool isLocked;

    // Collider for the object
    private Collider2D objectCollider;

    // Start is called before the first frame update
    void Start()
    {
        objectCollider = GetComponent<Collider2D>();
        isDraggable = false;
        isDragging = false;
        isLocked = false;
    }

    void Update()
    {
        DragAndDropMethod();
    }

    void DragAndDropMethod()
    {
        // Determine mouse's position in 2D space
        Vector2 mousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);

        // If it's not locked (due to animation)
        if (!isLocked)
        {

            // If the mouse clicks down
            if (Input.GetMouseButtonDown(0))
            {
                // And and it overlaps with the point of the mouse position
                if (objectCollider == Physics2D.OverlapPoint(mousePosition))
                {
                    // It can be dragged
                    isDraggable = true;
                }
                else
                {
                    // Otherwise, it can't be dragged
                    isDraggable = false;
                }

                if (isDraggable)
                {
                    // If it's currently draggable and the mouse is clicked, it's being dragged
                    isDragging = true;
                }
            }
            // If it's currently dragging
            if (isDragging)
            {
                // Change the position of the object
                Vector3 positionForItem = new Vector3(mousePosition.x, mousePosition.y, -1);
                this.transform.position = positionForItem;
            }

            // Once you let go, reset the isDraggable and isDragging booleans.
            if (Input.GetMouseButtonUp(0))
            {
                isDraggable = false;
                isDragging = false;

                // ADDED BY HENRY
                transform.position = new Vector3(0, Mathf.Clamp(transform.position.y, -1, 10), 0);
            }
        }
    }
}
