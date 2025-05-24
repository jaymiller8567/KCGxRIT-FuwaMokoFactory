using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SubsystemsImplementation;

public class CreatureScript : MonoBehaviour
{
    private GameManager gameManager;
    [SerializeField] private Rigidbody2D rb;
    [SerializeField] private BoxCollider2D boxCollider;
    [SerializeField] private SpriteRenderer spriteRenderer;
    [SerializeField] private Vector2 startPosition;
    [SerializeField] private Vector3 velocity;

    [SerializeField] private List<Sprite> sprites = new List<Sprite>();
    [SerializeField] private List<Color> colors = new List<Color>();

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

        // TODO: add small chance for sprite to be rainbow and color changing (3% chance as requested)
    }

    // Update is called once per frame
    void Update()
    {
        if (!gameManager.isPaused)
        { 
            transform.position += velocity * Time.deltaTime;

            CheckToBeRemoved();
        }
    }

    public void AddSpeed(float addVelocity)
    {
        velocity.y += addVelocity;
    }

    private void CheckToBeRemoved()
    {
        // Destroy creature if set to inactive
        if (transform.position.y < -7.0f)
        {
            gameObject.SetActive(false);
        }
    }
}
