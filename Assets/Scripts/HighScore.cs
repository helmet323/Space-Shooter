using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HighScore : MonoBehaviour
{

    public int highScore;
    public Text highScoreText;

    // Start is called before the first frame update

    void Start()
    {
        highScore = PlayerPrefs.GetInt ("highScore", highScore);
    }

    // Update is called once per frame
    void Update()
    {
        highScoreText.text = "Highscore: " + highScore;
    }
}
