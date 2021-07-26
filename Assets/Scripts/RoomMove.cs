using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class RoomMove : MonoBehaviour
{
    //public Vector2 cameraChangemax; Used for Different Sized Rooms
    //public Vector2 cameraChangemin; User for Different Sized Rooms
    public Vector2 cameraChange;
    public Vector3 playerChange;
    private CameraMovement cam;
    public bool needText;
    public string areaName;
    public GameObject text;
    public Text placeText;

    // Start is called before the first frame update
    void Start()
    {
        cam = Camera.main.GetComponent<CameraMovement>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    //Unity Prebuilt Function
    private void OnTriggerEnter2D(Collider2D other)
    {
        if(other.CompareTag("Player"))
        {
            cam.minPosition += cameraChange;
            cam.maxPosition += cameraChange;
            other.transform.position += playerChange;

            if(needText)
            {
                StartCoroutine(placenameCo());
            }

        }
    }
    private IEnumerator placenameCo()
    {
        text.SetActive(true);
        placeText.text = areaName;
        yield return new WaitForSeconds(2.5f);
        text.SetActive(false);
    }
}


