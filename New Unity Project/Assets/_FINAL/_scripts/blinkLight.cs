using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Experimental.Rendering.Universal;

public class blinkLight : MonoBehaviour
{
   private Light2D Light2D;
   public bool blink;
   public float speed;
   public float minBlink;
   public float maxBlink;

   private void Start()
   {
      Light2D = GetComponent<Light2D>();
   }

   private void Update()
   {
      if (blink == true)
      {
         Light2D.intensity -= speed * Time.deltaTime;

         if (Light2D.intensity >= maxBlink || Light2D.intensity <= minBlink)
         {
            speed *= -1;
         }
      }
   }
}
