using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.AI;
using UnityEngine.UI;

public class SelectCup : MonoBehaviour
{

  // List of clickable objects
    public List<GameObject> clickableObjects = new List<GameObject>();
    private WonLostUI wonLostUI;
    private RiseCups riseCups;
    Transform[] transformArray;
    private Button button;
    public static bool isChekingBall;



    private void Start(){
        wonLostUI = FindFirstObjectByType<WonLostUI>();
        riseCups = FindFirstObjectByType<RiseCups>();    
        wonLostUI.HideWonLostUI(); //Hide the UI when the game start
        transformArray = clickableObjects.Select(go => go.transform).ToArray();
        button = GameObject.Find("Shuffle Button").GetComponent<Button>();
       
    }

    private void Update() //Updated each frame
    {
        if(!CupSuffle.isShuffling && riseCups.canClick){
       
        CheckClick();
        }
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
        isChekingBall = true;
        CupSuffle.isShuffling = true;
        riseCups.canClick = false;
        riseCups.RideDescend(transformArray);

        // Check if the object clicked have the ball or not, by cheking his parent
        if(gameObject.transform.parent.name == "Cup With Ball"){
            wonLostUI.ShowWonLostUI(0);
        }
        else{
            wonLostUI.ShowWonLostUI(1);    
                }
      
    }

}