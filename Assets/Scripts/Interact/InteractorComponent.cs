using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InteractorComponent : MonoBehaviour
{

    [SerializeField] Transform firePoint;
    [SerializeField] float interactionRange = 3.0f;
    [SerializeField] LayerMask mask;

    public GameObject LastObject;
    InteractableSchematic x;


    private void Update()
    {
        RaycastHit hit;

        if (Physics.Raycast(firePoint.position, firePoint.transform.forward, out hit, interactionRange, mask, QueryTriggerInteraction.Collide))
        {
            if (x == null) //On Raycast Enter
            {
                x = hit.transform.gameObject.GetComponent<InteractableSchematic>();
                LastObject = hit.transform.gameObject;




                x.OnEnter(this);
            }

            else//On Raycast Stay
            {
                if(x.LowerInteractionTime() < 0)
                {
                    x.OnCompletion(this);
                }

                LastObject = hit.transform.gameObject;
            }

        }
        else                                         //On Raycast leave
        {
            if (LastObject != null)
            {
                x.OnLeave(this);
                x = null;
                LastObject = null;
            }


        }
    }

}


