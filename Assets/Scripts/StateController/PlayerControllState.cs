using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "StateController/Actions/Patrol")]
public class PlayerControllState : Action {

    public override void Act(StateController controller) {

        SetPlayerControlls(controller);

    }

    private void SetPlayerControlls(StateController controller) {

        if (!controller.PlayerController.isActiveAndEnabled) {
            controller.PlayerController.enabled = true;
        }
    }
}

