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
    private bool isCollected = false;

    [HideInInspector] public GameObject inBox;

    [SerializeField] private List<Sprite> sprites = new List<Sprite>();
    [SerializeField] private List<Color> colors = new List<Color>();
    [SerializeField] private List<Sprite> rainbowSprites = new List<Sprite>();

    private int spriteIndex;
    private int colorIndex;

    public bool IsCollected { get { return isCollected; } set { isCollected = value; } }

    // Start is called before the first frame update
    void Start()
    {
        // Set position
        transform.position = startPosition;

        // Get game manager
        gameManager = Object.FindObjectsOfType<GameManager>()[0];

        // Set random color and sprite
        colorIndex = Random.Range(0, colors.Count);
        spriteRenderer.color = colors[colorIndex];
        spriteIndex = Random.Range(0, sprites.Count);
        spriteRenderer.sprite = sprites[spriteIndex];

        // Small chance for sprite to be rainbow and color changing (3% chance as requested)
        if (Random.value < 0.03f)
        {
            spriteRenderer.color = Color.white;
            spriteRenderer.sprite = sprites[spriteIndex];
        }
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
        if (!isCollected)
        {
            velocity.y += addVelocity;
        }
    }

    private void CheckToBeRemoved()
    {
        // Destroy creature if set to inactive
        if (transform.position.y < -7.0f)
        {
            gameObject.SetActive(false);
        }
    }

    public void ResetVelocity()
    {
        velocity = new Vector3(0, 0, 0);
    }
}
