using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PLayerStairState : IState<Character>
{
    public void OnEnter(Character t)
    {
        t.ChangeAnim("Running");
    }

    public void OnExecute(Character t)
    {
        if (((Player)t).OnSlope() == false)
        {
            t.ChangeState(new PlayerPatrolState());
        }
        else if (((Player)t).GetInput() == false)
        {
            t.ChangeState(new PlayerIdleState());
        }
        else
        {
            ((Player)t).SlopeMove();
            ((Player)t).LookAtMoveDirection();
            
        }
    }

    public void OnExit(Character t)
    {
        
    }
}
