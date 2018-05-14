using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LookAround : MonoBehaviour
{
    public float sensitivity;
    Vector3 xRotation;
    Vector3 yRotation;
    public GameObject cameraY;

    void Update ()
    {
        Look();
	}

    void Look()
    {
        xRotation.x = -Input.GetAxis("Mouse Y");
        yRotation.y = Input.GetAxis("Mouse X");

        transform.Rotate(xRotation * (sensitivity * 10) * Time.deltaTime);

        cameraY.transform.Rotate(yRotation * (sensitivity * 10) * Time.deltaTime);
    }
}
