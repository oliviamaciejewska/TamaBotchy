using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AdultState : TamaBaseState
{
    public AdultState(TamaStateManager stateMachine) : base("Adult", stateMachine) { }

    public override void Enter()
    {
        stateMachine.ChangeSprite(1);
    }

    public override void Update()
    {
    }

    public override void UpdatePhysics()
    {
    }

    public override void Exit()
    {
    }
}
