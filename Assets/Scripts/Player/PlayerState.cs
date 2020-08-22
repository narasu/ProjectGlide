using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum PlayerStateType { Normal }

public abstract class PlayerState
{
    protected PlayerFSM owner;
    protected Player player;

    public void Initialize(PlayerFSM owner)
    {
        this.owner = owner;
        player = owner.owner;
    }

    public abstract void Enter();
    public abstract void Update();
    public abstract void Exit();
}

public class NormalState : PlayerState
{
    public override void Enter()
    {

    }

    public override void Update()
    {
        player.Move();
        player.HandleRotation();
    }

    public override void Exit()
    {

    }
}
