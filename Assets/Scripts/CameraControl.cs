using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraControl : MonoBehaviour
{
    public GameObject player;

    private Vector3 offset;
    // Use this for initialization
    void Start()
    {
        offset = transform.position - player.transform.position;
        //transform.position references the transform's position for the camera, as they are both attached to the camera
    }

    // Update is called once per frame
    void LateUpdate()
    {
        
        transform.position = player.transform.position + offset;
        //camera is moved into a new position aligned with the player object
        //FOR FOLLOWING CAMERAS (WHAT WE WANT TO DO, USE LateUpdate()
    }
}
