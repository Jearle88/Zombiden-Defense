using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class tracker : MonoBehaviour
{
   public int slide = 0;

   private void Update(){
    if (slide < 0)
        slide = 0;
    if (slide > 3)
        slide = 3;
   }
}
