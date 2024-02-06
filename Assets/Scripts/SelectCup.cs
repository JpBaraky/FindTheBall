using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SelectCup : MonoBehaviour
{
    public bool hasBall;
   private void OnMouseDown()
    {
        // This method is called when the object is clicked
        Debug.Log("Object Clicked!");
        if(hasBall){
              Debug.Log("You found the ball!");
        } else{
            Debug.Log("You lost");
        }
      
    }
}
