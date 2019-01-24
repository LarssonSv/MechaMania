using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LootComponent : InteractableSchematic
{
    [SerializeField] string InteractionName;
    [SerializeField] float InteractionTime;

    public override string interactionName { get { return InteractionName; } set { InteractionName = value; } }
    public override float interactionTime { get { return InteractionTime; } set { InteractionTime = value; } }

    bool used = false;

    public override float LowerInteractionTime()
    {
        InteractionTime -= 0.1f;
        
        return InteractionTime;
    }

    public override void OnCompletion(InteractorComponent interactor)
    {
        if(used == false)
        {
            Debug.Log("Completed");

            used = true;
        }
    }

    public override void OnEnter(InteractorComponent interactor)
    {
        Debug.Log("Entered");
    }
    public override void OnLeave(InteractorComponent interactor)
    {
        Debug.Log("Exit");
    }


}

