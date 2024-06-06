using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class cameraMove : MonoBehaviour
{ 
    // Update is called once per frame
    // basic camera mover
    void Update()
    {
        float ytranslation = Input.GetAxis("Vertical") * 0.1f;
        float xtranslation = Input.GetAxis("Horizontal") * 0.1f;

        // Make it move 10 meters per second instead of 10 meters per frame...
        // translation *= Time.deltaTime;
        // rotation *= Time.deltaTime;

        // Move translation along the object's z-axis
        transform.Translate(xtranslation, ytranslation, 0);
    }
}
