using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEditor.SearchService;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ScoreScript : MonoBehaviour
{
    // Start is called before the first frame update

    private float currentScore = 0;
    private int currentCombo = 0;
    private float currentMultiplier = 1;
    private float numberMissed = 0;
    private int maxCombo = 0;

    private float maxMultiplier = 2.5f;
    private List<int> comboLevels;

    private int numSorted;

    private static ScoreScript _instance;

    // Properties
    public float FinalScore { get { return currentScore; } }
    public int MaxCombo { get { return maxCombo; } }

    public int NumEscaped { get { return numberMissed; } }
    public int TotalNumberSorted { get { return numSorted; } }


    // UI
    public GameObject comboText;
    public GameObject currentScoreText;
    public GameObject currentMultiplierText;

   public static ScoreScript instance
    {
        get
        {
            if (_instance == null)
            {
                _instance = GameObject.FindObjectOfType<ScoreScript>();
            }

            return _instance;
        }
    }


    void Start()
    {

    }

    void Awake()
    {
        DontDestroyOnLoad(gameObject);
    }

    // Update is called once per frame
    void Update()
    {
      
    }

    /// <summary>
    /// Called when the player successfully sorts a fuzzy. 
    /// </summary>
    /// <param name="isRainbow"></param>
    public void addToScore(bool isRainbow)
    {
        if (isRainbow == true)
        {
            currentScore += 600 * currentMultiplier;
        }
        else
        {
            currentScore += 200 * currentMultiplier;
        }

        numSorted++;

        currentCombo++;
        Debug.Log("Current Combo: " +  currentCombo);

        if (currentCombo % 5 == 0 && currentCombo != 0)
        {
            currentMultiplier += 0.3f;
        }

        if (maxCombo < currentCombo)
        {
            maxCombo = currentCombo;
        }
    }

    /// <summary>
    /// Called when either a fuzzy is missed, incorrectly sorted, or a spiky is touched.
    /// </summary>
    public void breakCombo()
    {
        currentMultiplier = 1;
        currentCombo = 0;
        numberMissed++;
    }
}
