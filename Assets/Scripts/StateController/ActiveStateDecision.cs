using System.Collections;
using System.Collections.Generic;
using UnityEngine;


[CreateAssetMenu (menuName = "StateController/Decisions/ActiveState")]
public class ActiveStateDecision : Decision {

    public override bool Decide (StateController controller) {

        
        return true;

    }


}
