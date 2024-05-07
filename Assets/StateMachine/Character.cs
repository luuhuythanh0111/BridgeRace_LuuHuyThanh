using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Character : MonoBehaviour
{
    [SerializeField] private Animator anim;
    
    private IState<Character> currentState;
    private string currentAnimName;
    
    private void Start()
    {
        OnInit();
    }

    #region StateMachine

    // Update is called once per frame
    void Update()
    {
        if (currentState != null)
        {
            currentState.OnExecute(this);
        }
    }

    public void ChangeState(IState<Character> state)
    {
        if (currentState != null)
        {
            currentState.OnExit(this);
        }

        currentState = state;

        if (currentState != null)
        {
            currentState.OnEnter(this);
        }
    }

    public virtual void OnInit()
    {
        //ChangeState(new IdleState());
    }
    #endregion
    
    #region  Animation

    public void ChangeAnim(string animName)
    {
        if(currentAnimName!=null)
            anim.ResetTrigger(currentAnimName);
        currentAnimName = animName;
        if(currentAnimName!=null)
            anim.SetTrigger(currentAnimName);
    }

    public void ChangeAnimVictory(int index)
    {
        anim.SetInteger("Victory", index);
    }
    
    #endregion
}
