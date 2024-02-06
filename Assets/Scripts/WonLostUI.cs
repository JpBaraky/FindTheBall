using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class WonLostUI : MonoBehaviour
{
    public TextMeshProUGUI[] winLostTexts; // Put the win and lost Ui texts in editor here
    public float resetTimer = 2f; // Set the time that the player can interact again with the game
    
    public void ShowWonLostUI(int textNumber){
       StartCoroutine(TextTimer(textNumber));
    }
    IEnumerator TextTimer(int textNumber){
         winLostTexts[textNumber].enabled = true;
        yield return new WaitForSeconds(resetTimer);
        winLostTexts[textNumber].enabled = false;
      
    }
    public void HideWonLostUI(){
        winLostTexts[0].enabled = false;
        winLostTexts[1].enabled = false;
    }
    }


