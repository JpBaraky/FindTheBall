using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class SelectCup : MonoBehaviour
{

  // List of clickable objects
    public List<GameObject> clickableObjects = new List<GameObject>();
    private WonLostUI wonLostUI;

    private void Start(){
        wonLostUI = FindFirstObjectByType<WonLostUI>();
        wonLostUI.HideWonLostUI(); //Hide the UI when the game start
       
    }

    private void Update() //Updated each frame
    {
        CheckClick();
    }
    private void CheckClick(){
          // Check for mouse clicks
 if (Input.GetMouseButtonDown(0))
        {
            CheckClickObject();
        }
    }
    private void CheckClickObject(){
         // Cast a ray from the camera to the mouse position
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            RaycastHit hit;
  

            // Check if the ray hits an object with a collider
            if (Physics.Raycast(ray, out hit))
            {
                // Check if the clicked object is in the list of clickableObjects
                if (clickableObjects.Contains(hit.collider.gameObject))
                {
                    CheckForBall(hit.collider.gameObject);
                }
            }

    }
    private void CheckForBall(GameObject gameObject){
        // Check if the object clicked have the ball or not, by cheking his parent
        if(gameObject.transform.parent.name == "Ball"){
            wonLostUI.ShowWonLostUI(0);
        }
        else{
            wonLostUI.ShowWonLostUI(1);    
                }
    }
}