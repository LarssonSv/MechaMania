#pragma warning disable 0414
using System.Collections;
using System.Collections.Generic;
using UnityEngine;


//BIG THANKS TO u/rdnwt  https://www.reddit.com/r/Unity3D/comments/3jj2p5/clamping_angle_of_quaternion_issue/
public class HeadHandler : MonoBehaviour
{
    [SerializeField]
    CameraPointer pointer;

    [SerializeField] float damping = 10.0f;


    [SerializeField] float leftExtent;
    [SerializeField] float rightExtent;
    [SerializeField] float upExtent;
    [SerializeField] float downExtent;

    Quaternion original;

    private Vector3 dirXZ, forwardXZ, dirYZ, forwardYZ;


    private void Start()
    {
        pointer = GameObject.FindGameObjectWithTag("GM").GetComponent<CameraPointer>();
        original = transform.rotation;

    }

    void Update()
    {
        Vector3 lookPos = new Vector3();

        if (pointer.Enemy)
        {
            lookPos = pointer.Enemy.transform.position - transform.position;
        }
        else
        {
            lookPos = pointer.hitPoint - transform.position;
        }


        Vector3 originalForward = original * Vector3.forward;

        Vector3 yAxis = Vector3.up; //Gets World up
        dirXZ = Vector3.ProjectOnPlane(lookPos, yAxis);
        forwardXZ = Vector3.ProjectOnPlane(originalForward, yAxis);
        float yAngle = Vector3.Angle(dirXZ, forwardXZ) * Mathf.Sign(Vector3.Dot(yAxis, Vector3.Cross(forwardXZ, dirXZ)));
        float yClamped = Mathf.Clamp(yAngle, leftExtent, rightExtent);
        Quaternion yRotation = Quaternion.AngleAxis(yClamped, Vector3.up);

        originalForward = yRotation * original * Vector3.forward;
        Vector3 xAxis = yRotation * original * Vector3.right; //Local xAxis
        dirYZ = Vector3.ProjectOnPlane(lookPos, xAxis);
        forwardYZ = Vector3.ProjectOnPlane(originalForward, xAxis);
        float xAngle = Vector3.Angle(dirYZ, forwardYZ) * Mathf.Sign(Vector3.Dot(xAxis, Vector3.Cross(forwardYZ, dirYZ)));
        float xClamped = Mathf.Clamp(xAngle, -upExtent, -downExtent);
        Quaternion xRotation = Quaternion.AngleAxis(xClamped, Vector3.right);

        Quaternion newRotation = yRotation * xRotation * original;

        transform.rotation = newRotation;

        //transform.rotation = Quaternion.Slerp(transform.rotation, newRotation, Time.deltaTime * damping);
    }
}
