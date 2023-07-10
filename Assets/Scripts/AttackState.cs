using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AttackState : State
{
    private float timePassed;
    private float clipLenght;
    private float clipSpeed;
    private bool attack;

    
    
    
    
    public AttackState(Character _character, StateMachine _stateMachine) : base(_character, _stateMachine)
    {
        character = _character;
        stateMachine = _stateMachine;
    }

    public override void Enter()
    {
        base.Enter();
        character.animator.SetBool("isAttacking",true);
        attack = false;
        character.animator.applyRootMotion = true;
        timePassed = 0f;
        character.animator.SetFloat("speed",0f);

    }

    public override void HandleInput()
    {
        base.HandleInput();

        if (attackAction.triggered)
        {
            attack = true;
        }
        
    }

    public override void LogicUpdate()
    {
        base.LogicUpdate();

        timePassed = timePassed + Time.deltaTime; //timePassed += Time.deltaTime
        //clipLenght = character.animator.GetCurrentAnimatorClipInfo(1)[0].clip.length;
        clipSpeed = character.animator.GetCurrentAnimatorStateInfo(1).speed;

        if (timePassed >= clipLenght / clipSpeed && attack)
        {
            stateMachine.ChangeState(character.attacking);
            character.animator.SetBool("isAttacking",false);
        }

        if (timePassed >= clipLenght / clipSpeed)
        {
            stateMachine.ChangeState(character.combatting);
            character.animator.SetTrigger("move");
            character.animator.SetBool("isAttacking",false);
        }
    }

    public override void Exit()
    {
        base.Exit();
        character.animator.applyRootMotion = false;
    }
    
    
    
}
