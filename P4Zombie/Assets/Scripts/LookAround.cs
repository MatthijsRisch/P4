using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LookAround : MonoBehaviour
{
    public int clampAmount;

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
        xRotation.x += Input.GetAxis("Mouse Y") * sensitivity;
        yRotation.y = Input.GetAxis("Mouse X");

        cameraY.transform.Rotate(yRotation * (sensitivity * 20) * Time.deltaTime);

        xRotation.x = Mathf.Clamp(xRotation.x, -clampAmount, clampAmount);
        transform.localEulerAngles = new Vector3(-xRotation.x, transform.localEulerAngles.y, transform.localEulerAngles.z);
    }
}
