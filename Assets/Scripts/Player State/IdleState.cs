using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IdleState : MoveState
{
    public IdleState(Player player, StateMachine stateMachine) : base (player, stateMachine){

    }
    public override void Enter()
    {
        base.Enter();
    }

    public override void Exit()
    {
        base.Exit();
    }

    public override void HandleInput()
    {
        base.HandleInput();
    }

    public override void PhysicsUpdate()
    {
        base.PhysicsUpdate();
    }
}
