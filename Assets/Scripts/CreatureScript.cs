using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CreatureScript : MonoBehaviour
{
    [SerializeField] private Rigidbody2D rb;
    [SerializeField] private BoxCollider2D boxCollider;
    [SerializeField] private SpriteRenderer spriteRenderer;
    [SerializeField] private Vector2 startPosition;
    [SerializeField] private Vector3 velocity;

    [SerializeField] private List<Sprite> sprites = new List<Sprite>();
    [SerializeField] private List<Color> colors = new List<Color>();

    private GameManager gameManager;

    // Start is called before the first frame update
    void Start()
    {
        // Set position
        transform.position = startPosition;

        // Get game manager
        gameManager = Object.FindObjectsOfType<GameManager>()[0];

        // Set random color and sprite
        spriteRenderer.color = colors[Random.Range(0, colors.Count)];
        spriteRenderer.sprite = sprites[Random.Range(0, sprites.Count)];
    }

    // Update is called once per frame
    void Update()
    {
        if (!gameManager.isPaused)
        { 
            transform.position += velocity * Time.deltaTime;
        }
    }
}
