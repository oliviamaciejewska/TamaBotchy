using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class TamaBaseState
{
    public string name;
    protected TamaStateManager stateMachine;

    public TamaBaseState(string name, TamaStateManager stateMachine)
    {
        this.name = name;
        this.stateMachine = stateMachine;
    }

    public abstract void Enter();

    public abstract void Update();

    public abstract void UpdatePhysics();

    public abstract void Exit();

}
