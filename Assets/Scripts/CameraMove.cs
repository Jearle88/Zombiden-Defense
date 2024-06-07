using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class cameraMove : MonoBehaviour
{
    // Update is called once per frame
    // basic camera mover
    public float xmax;
    public float xmin;
    public float zmax;
    public float zmin;
    [System.NonSerialized]public float xtranslation;
    [System.NonSerialized]public float ztranslation;
    void Update()
    {
        {
            xtranslation = Input.GetAxis("Horizontal") * 0.1f;
            ztranslation = Input.GetAxis("Vertical") * 0.1f;
            if(xtranslation + transform.position.x > xmax || xtranslation + transform.position.x < xmin)
            {
                xtranslation = 0.0f;
            }
            if (ztranslation + transform.position.z > zmax || ztranslation + transform.position.z < zmin)
            {
                ztranslation = 0.0f;
            }
            // Make it move 10 meters per second instead of 10 meters per frame...
            // translation *= Time.deltaTime;
            // rotation *= Time.deltaTime;

            // Move translation along the object's z-axis and x axis
            transform.Translate(xtranslation, ztranslation, 0);
        }
    }
}
