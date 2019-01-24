using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StateController : MonoBehaviour {

    public State currentState;
    public State remainState;
    public bool Active = true;

    [HideInInspector]
    public float stateTimeElapsed;
    [HideInInspector]
    public ThirdPersonUserControl PlayerController;





    void Awake() {
        PlayerController = GetComponent<ThirdPersonUserControl>();
    }



    private void Update() {

        if (!Active) {
            return;
        }

        currentState.UpdateState(this);
    }

    public void TransitionToState(State nextState) {

        if (nextState != remainState) {
            currentState = nextState;
        }


    }

    public bool CheckIfCDElapsed(float duration) {

        stateTimeElapsed += Time.deltaTime;
        return (stateTimeElapsed >= duration);

    }

    private void OnExitState() {

        stateTimeElapsed = 0;

    }



}
