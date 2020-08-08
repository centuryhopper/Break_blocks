using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class GameStatus : MonoBehaviour
{
    [Range(0.0f, 1.0f)]
    [SerializeField] public float gameSpeed = 1f;
    [SerializeField] public int pointsPerBlockDestroyed = 83;
    [SerializeField] int currentScore = 0;
    [SerializeField] public TextMeshProUGUI scoreDisplay;

    private void Awake()
    {
        int gameStatusCount = FindObjectsOfType<GameStatus>().Length;

        if (gameStatusCount > 1)
        {
            gameObject.SetActive(false);
            Destroy(gameObject);
        }
        else
            DontDestroyOnLoad(gameObject);
    }

    public void ResetGame()
    {
        Destroy(gameObject);
    }

    public void IncreaseScore()
    {
        currentScore += pointsPerBlockDestroyed;
    }

    public string ScoreText()
    {
        return currentScore.ToString();
    }

    // Start is called before the first frame update
    void Start()
    {
        scoreDisplay.text = currentScore.ToString();
    }

    // Update is called once per frame
    void Update()
    {
        Time.timeScale = gameSpeed;
        scoreDisplay.text = currentScore.ToString();
    }
}
