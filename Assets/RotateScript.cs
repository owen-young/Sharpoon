using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rotator : MonoBehaviour
{
    void Start ()
    {

    }

    void Update()
    {
        transform.Rotate(new Vector3(0, 0, 45) * Time.deltaTime);
        //needs to be smooth and timerate indepenent, so multiply by delta time (????)
    }
}
