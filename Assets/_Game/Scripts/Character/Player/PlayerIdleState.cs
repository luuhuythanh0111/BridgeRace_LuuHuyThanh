using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerIdleState : IState<Character>
{
    public void OnEnter(Character t)
    {
        t.ChangeAnim("Idle");
    }

    public void OnExecute(Character t)
    {
        if (((Player)t).GetInput())
        {
            if (((Player)t).OnSlope() == true)
                t.ChangeState(new PLayerStairState());
            else
                t.ChangeState(new PlayerPatrolState());
        }
        ((Player)t).Move();
    }

    public void OnExit(Character t)
    {
        
    }
}
