using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Splines;

public class PlatformaOuza : MonoBehaviour
{
   public Fan fanObject;
   public SplineAnimate spline;

   void Update()
   {
        if(fanObject.onOrOff)
        spline.Pause();
        else spline.Play();

        
   }
}
