using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CreatureScript : MonoBehaviour
{
    [SerializeField] private Rigidbody2D rb;
    [SerializeField] private BoxCollider2D boxCollider;
    [SerializeField] private Vector2 startPosition;
    [SerializeField] private Vector3 velocity;
    private GameManager gameManager;

    // Start is called before the first frame update
    void Start()
    {
        transform.position = startPosition;
        gameManager = Object.FindObjectsOfType<GameManager>()[0];
    }

    // Update is called once per frame
    void Update()
    {
        if (!gameManager.isPaused) { 
            if (transform.position.y > -1.5)
            {
                transform.position += velocity * Time.deltaTime;
            }
            else
            {
            
            }
        }
    }
}
