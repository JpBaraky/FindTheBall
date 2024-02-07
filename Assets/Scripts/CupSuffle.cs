using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CupSuffle : MonoBehaviour
{
    
    public Transform[] cups; // Drag your cup GameObjects here in the Inspector
    public int swapCount = 5; // Number of times to swap cups
    public float swapSpeed = 5f; // Speed of cup swapping
    public float swapDelay = 1f; // Delay between cup swaps
    public Button button;
    private RiseCups riseCups;

    private void Start(){

        riseCups = FindFirstObjectByType<RiseCups>();
    }

 
    private IEnumerator SwapCupsRoutine()
    
    {
        riseCups.RideDescend(cups);
        yield return new WaitForSecondsRealtime(riseCups.riseDuration* 2);
        for (int i = 0; i < swapCount; i++)
        {
            // Randomly choose two cups to swap
           int cupIndex1 = Random.Range(0, cups.Length);
            int cupIndex2;
            do
            {
                cupIndex2 = Random.Range(0, cups.Length);
            } while (cupIndex2 == cupIndex1);

            // Swap the two cups in a semi-circle motion
            yield return StartCoroutine(SwapCupsSemiCircle(cups[cupIndex1], cups[cupIndex2]));

            // Add a delay between swaps if needed
            yield return new WaitForSeconds(swapDelay);
        }
   
    }

    private IEnumerator SwapCupsSemiCircle(Transform cup1, Transform cup2)
    {
    Vector3 finalPositionCup1 = cup2.position; // Store the initial position of cup1
    Vector3 finalPositionCup2 = cup1.position; // Store the initial position of cup2
     Vector3 center = (cup1.position + cup2.position) / 2f; // Center of the semi-circle
    float initialDistance = Vector3.Distance(cup1.position, cup2.position);
   

    for (float t = 0; t < 1; t += Time.deltaTime * swapSpeed)
    {
        float semiCircleRadius = initialDistance / 2f; // Dynamic radius based on initial positions
        float angle = Mathf.Lerp(0, Mathf.PI, t); // Angle for cup1 (forward)
        

        float x1 = center.x - Mathf.Cos(angle) * semiCircleRadius;
        float z1 = center.z - Mathf.Sin(angle) * semiCircleRadius;

        float x2 = center.x + Mathf.Cos(angle) * semiCircleRadius;
        float z2 = center.z + Mathf.Sin(angle) * semiCircleRadius;

        cup2.position = new Vector3(x1, cup1.position.y, z1);
        cup1.position = new Vector3(x2, cup2.position.y, z2);

        yield return null;
    }

    // Ensure final positions are correct
    cup1.position = finalPositionCup1;
    cup2.position = finalPositionCup2;
}
    public void Shuffle(){
        StartCoroutine(SwapCupsRoutine());
        button.interactable = false;
    }
}