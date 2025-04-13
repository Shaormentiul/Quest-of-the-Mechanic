    using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Splines;

public class FanPlatform : MonoBehaviour
{
    public SplineAnimate splineAnim;
    public GameObject fanObject;
    public float time;
    public bool play;
    public bool animationFinish;
    public bool isAtEnd;
    public bool notTurnedOn;
    public float rotationSpeed = 2.0f; 
    private bool isRotating = false;
    private Quaternion targetRotation;
    public bool rotated;
    public bool isAtStart;
    public PlatfromCollision plat;
    public bool isPlaying;
    public bool paused;
    void Start()
    {
        isAtStart = true;
        isPlaying = false;
    }

   

    public void Update()
    {

        if(splineAnim.NormalizedTime > 0 && splineAnim.NormalizedTime < 1)
        {
            isPlaying = true;
        }
        else isPlaying = false;

        if(isPlaying && notTurnedOn)
        {
            paused = true;
        }

        if(isPlaying && !notTurnedOn && paused)
        {
            if(rotated)
            {
                PlayBackward();
                paused = false;
            }
            else 
            {
                PlayAnimation();
                paused = false;
            }
        }
        
        if(fanObject != null)
        {
            if(splineAnim.ElapsedTime >= splineAnim.Duration && !rotated && !isAtEnd)
            {
                fanObject.GetComponent<Fan>().onOrOff = false;
                isAtEnd = true;
                Debug.Log("HAIDE");
                TriggerRotation();
                
                
                
                
            }

            if(!fanObject.GetComponent<Fan>().onOrOff)
            {
                notTurnedOn = true;
            }
            else 
            {
                notTurnedOn = false;
            }

            if(isAtEnd && !notTurnedOn && rotated)
            {
                PlayBackward();
                //isAtEnd = false;
            }

            if(isAtEnd || notTurnedOn)
            {
                StopAnimation();
            }

            else if(fanObject.GetComponent<Fan>().onOrOff && isAtStart && !rotated)
            {
                PlayAnimation();
                isAtStart = false;
            }

            


            
        }

       
    }

    public void TriggerRotation()
    {

        
        if (!isRotating)
        {
            StartCoroutine(Rotate180());
        }
    }

    private IEnumerator Rotate180()
    {
        yield return new WaitUntil(() => !plat.isOnPlatform);
        yield return new WaitForSeconds(1f);
        isRotating = true;
        float elapsedTime = 0f;
        Quaternion startRotation = transform.rotation;
        targetRotation = Quaternion.Euler(transform.eulerAngles.x, transform.eulerAngles.y + 180f, transform.eulerAngles.z);

        while (elapsedTime < 1f)
        {
            transform.rotation = Quaternion.Slerp(startRotation, targetRotation, elapsedTime);
            elapsedTime += Time.deltaTime * rotationSpeed;
            yield return null;
        }

        transform.rotation = targetRotation; // Ensure precise final rotation
        isRotating = false;
        if(!isAtStart)
        rotated = true;
        else 
        {
            rotated = false;
            
        }
        if(isAtStart)
        splineAnim.Restart(false);
    }

    public void PlayBackward()
    {
       
       
        StartCoroutine(ReverseSpline());
    }

    private IEnumerator ReverseSpline()
    {
        
        while (splineAnim.NormalizedTime > 0)
        {
            splineAnim.NormalizedTime -=  0.004f * Time.deltaTime / splineAnim.Duration;
            if(paused)
                break;
            yield return null;
        }
        if(!paused)
        splineAnim.NormalizedTime = 0; // Ensure precise stopping at start
        
        if(rotated && !paused)
        {
            isAtStart = true;
            isAtEnd = false;
            fanObject.GetComponent<Fan>().onOrOff = false;
            Debug.Log("reverse");
            TriggerRotation(); 
            rotated = false;
        }
        

    }



    public void StopAnimation()
    {
        splineAnim.Pause();
     
    }

    public void PlayAnimation()
    {
        splineAnim.Play();
    }

    
}
