using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class FinalScore : MonoBehaviour
{
    [SerializeField] public Text scoreDisplay;

    GameStatus gm;

    // Start is called before the first frame update
    void Start()
    {
        gm = FindObjectOfType<GameStatus>();
        if (gm != null && scoreDisplay != null)
        {
            scoreDisplay.text = gm.ScoreText();
        }
    }

}
