using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerPatrolState : IState<Character>
{
    public void OnEnter(Character t)
    {
        t.ChangeAnim("Running");
    }

    public void OnExecute(Character t)
    {
        if (((Player)t).GetInput() == false)
        {
            t.ChangeState(new PlayerIdleState());
        }
        else if (((Player)t).OnSlope())
        {
            t.ChangeState(new PLayerStairState());
        }
        else
        {
            ((Player)t).Move();
            ((Player)t).LookAtMoveDirection();
        }
    }

    public void OnExit(Character t)
    {
        
    }
}
