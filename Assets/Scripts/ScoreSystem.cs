using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class ScoreSystem : MonoBehaviour
{
    public static float playerScore;
    private float playerHiScore;
    private TextMeshProUGUI playerScoreText;
    private TextMeshProUGUI playerHiScoreText;
    // Start is called before the first frame update
    void Start()
    {
        playerHiScore = PlayerPrefs.GetFloat("HighScore", 0);
        playerHiScoreText = GameObject.Find("HiScore").GetComponent<TextMeshProUGUI>();
        playerScoreText = GameObject.Find("Score").GetComponent<TextMeshProUGUI>();
        playerHiScoreText.text = "HiScore: " + playerHiScore;

    }

    // Update is called once per frame
    void Update()
    {
        
        UpdateScoreText();
    }
    private void UpdateScoreText(){
        playerScoreText.text = "Score: " + playerScore;
        if(playerScore > playerHiScore){
            playerHiScore = playerScore;
            playerHiScoreText.text = "HiScore: " + playerHiScore;
            PlayerPrefs.SetFloat("HighScore", playerHiScore);
		}
        }
        }

    

