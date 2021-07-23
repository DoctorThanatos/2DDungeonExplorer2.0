using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//4.89y -4.89y 5.07x -4.76x

public class CameraMovement : MonoBehaviour
{

    public Transform target;
    public float smoothing;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called based on math
    void FixedUpdate()
    {
        if(transform.position != target.position)
        {
            //Set the Camera to Line up with the 2D Frame
            Vector3 targetPosition = new Vector3(target.position.x, target.position.y, transform.position.z);
            //Move a percentage of the distance between 2 points
            transform.position = Vector3.Lerp(transform.position, targetPosition, smoothing);
        }
    }
}
