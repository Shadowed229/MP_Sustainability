using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class State
{
    protected Player player;
    protected StateMachine stateMachine;

    protected State(Player player, StateMachine stateMachine)
    {
        this.player = player;
        this.stateMachine = stateMachine;
    }
    /*
    protected void DisplayOnUI(UIManager.Alignment alignment)
    {
        UIManager.Instance.Display(this, alignment);
    }
    */
    public virtual void Enter()
    {
        //DisplayOnUI(UIManager.Alignment.Left);
    }

    public virtual void HandleInput()
    {

    }

    public virtual void LogicUpdate()
    {

    }

    public virtual void PhysicsUpdate()
    {

    }

    public virtual void Exit()
    {

    }
}
