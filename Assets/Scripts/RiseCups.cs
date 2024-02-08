using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class RiseCups : MonoBehaviour
{
  public float riseAmount = 1f;
    public float riseDuration = 1f;
    public bool canClick = true;




    public void RiseObjects(Transform[] objectsToRise)
    {
       

        foreach (Transform objTransform in objectsToRise)
        {
            if(objTransform.gameObject.name == "Cup With Ball"){
                StartCoroutine(RiseCoroutine(objTransform.GetChild(0)));
                
            }else{
            StartCoroutine(RiseCoroutine(objTransform));
            }
        }
    }

    public void DescendObjects(Transform[] objectsToDescend)
    {
        foreach (Transform objTransform in objectsToDescend)
        {
         
            if(objTransform.gameObject.name == "Cup With Ball"){
                StartCoroutine(DescendCoroutine(objTransform.GetChild(0)));
                
            }else{
            StartCoroutine(DescendCoroutine(objTransform));
            }
        }
    }

    private IEnumerator RiseCoroutine(Transform objTransform)
    {
        float elapsedTime = 0f;
        Vector3 startPos = objTransform.position;
        Vector3 endPos = startPos + new Vector3(0f, riseAmount, 0f);

        while (elapsedTime < riseDuration)
        {
            objTransform.position = Vector3.Lerp(startPos, endPos, elapsedTime / riseDuration);
            elapsedTime += Time.deltaTime;
            yield return null;
        }

        objTransform.position = endPos;
        
    }

    private IEnumerator DescendCoroutine(Transform objTransform)
    {
        float elapsedTime = 0f;
        Vector3 startPos = objTransform.position;
        Vector3 endPos = startPos - new Vector3(0f, riseAmount, 0f);

        while (elapsedTime < riseDuration)
        {
            objTransform.position = Vector3.Lerp(startPos, endPos, elapsedTime / riseDuration);
            elapsedTime += Time.deltaTime;
            yield return null;
        }

        objTransform.position = endPos;
        canClick = true;
        yield return new WaitForSecondsRealtime(0.1f);
        if(SelectCup.isChekingBall == true){
              SelectCup.isChekingBall = false;
              CupSuffle.isGame = false;
        }
    }
        
        
    private IEnumerator RiseAndDescend(Transform[] objectsToMove){
        RiseObjects(objectsToMove);
        yield return new WaitForSecondsRealtime(riseDuration);
        DescendObjects(objectsToMove);
        
    }
    public void RideDescend(Transform[] objectsToMove){
        StartCoroutine(RiseAndDescend(objectsToMove));
    }
    

}