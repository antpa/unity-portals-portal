using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PortalCamera : MonoBehaviour
{

    public Transform playerCamera;
    public Transform portal;
    public Transform otherPortal;

    private Quaternion initialRotation;

    void Start()
    {
        Vector3 director = new Vector3(0, 1, 0);
        var dirActual = portal.transform.rotation * director;
        var opposit = -dirActual;
        transform.rotation = Quaternion.LookRotation(opposit, Vector3.up);

        var dirOtherPortal = otherPortal.transform.rotation * director;
        initialRotation = Quaternion.FromToRotation(dirOtherPortal, dirActual);
        transform.position = portal.position;
    }

    // Update is called once per frame
    void Update()
    {
        // Move
        Vector3 offset = playerCamera.position - otherPortal.position;
        transform.position = portal.position + initialRotation * offset;

        // Rotate
        Vector3 newCameraDirection = initialRotation * playerCamera.forward;
        transform.rotation = Quaternion.LookRotation(newCameraDirection, Vector3.up);
    }
}
