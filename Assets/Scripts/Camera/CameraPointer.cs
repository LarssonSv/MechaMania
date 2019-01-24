using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraPointer : MonoBehaviour
{
    Camera cam;

    public GameObject Enemy;
    public Vector3 hitPoint;

    [SerializeField]
    LayerMask mask;

    private void Start()
    {
        cam = Camera.main;
    }

    void FixedUpdate()
    {

        RaycastHit hit;
        Ray ray = cam.ViewportPointToRay(new Vector3(0.5F, 0.5F, 0));

        if (Physics.Raycast(ray, out hit, 1000.0f, mask, QueryTriggerInteraction.Collide))
        {
            if(hit.transform.gameObject.CompareTag("Enemy"))
            {
                Enemy = hit.transform.gameObject;
            }
            else
            {
                Enemy = null;
                hitPoint = hit.point;
            }
        }

        


    }

    private void OnDrawGizmos()
    {
        Gizmos.DrawCube(hitPoint, new Vector3(1f, 1f, 1f));
    }


}
