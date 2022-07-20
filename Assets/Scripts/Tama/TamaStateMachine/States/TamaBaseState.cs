using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class TamaBaseState
{
    public string name;
    protected TamaStateMachine stateMachine;

    public TamaBaseState(string name, TamaStateMachine stateMachine)
    {
        this.name = name;
        this.stateMachine = stateMachine;
    }
    public abstract void Enter();

    public abstract void Update();

    public abstract void UpdatePhysics();

    public abstract void Exit();

}
