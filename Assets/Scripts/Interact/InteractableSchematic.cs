using System.Collections;
using System.Collections.Generic;
using UnityEngine;


[RequireComponent(typeof(BoxCollider))]
public abstract class InteractableSchematic : MonoBehaviour
{
    private void Awake()
    {
        GetComponent<BoxCollider>().isTrigger = true;
    }


    public abstract string interactionName { get; set; }
    public abstract float interactionTime { get; set; }
    public abstract float LowerInteractionTime();
    public abstract void OnCompletion(InteractorComponent interactor);
    public abstract void OnEnter(InteractorComponent interactor);
    public abstract void OnLeave(InteractorComponent interactor);

}
