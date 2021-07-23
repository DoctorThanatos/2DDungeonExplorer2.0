using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//4.89y -4.89y 5.07x -4.76x

public class CameraMovement : MonoBehaviour
{

    public Transform target;
    public float smoothing;
    public Vector2 maxPosition;
    public Vector2 minPosition;
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
            
            //Set the Camera to not go past the map boundries
            targetPosition.x = Mathf.Clamp(targetPosition.x, minPosition.x, maxPosition.x);
            targetPosition.y = Mathf.Clamp(targetPosition.y, minPosition.y, maxPosition.y);
            
            //Move a percentage of the distance between 2 points
            transform.position = Vector3.Lerp(transform.position, targetPosition, smoothing);
        }
    }
}
