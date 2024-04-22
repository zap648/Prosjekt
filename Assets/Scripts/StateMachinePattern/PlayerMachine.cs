using System;
using UnityEngine;

[Serializable]
public class PlayerMachine
{
    public PlayerState CurrentState { get; private set; }

    public playerIdleState idleState;
    public playerWalkState walkState;
    public playerUseState useState;

    public PlayerMachine(Player player)
    {
        this.idleState = new playerIdleState(player);
        this.walkState = new playerWalkState(player);
        this.useState = new playerUseState(player);
    }

    public void Initialize(PlayerState startingState)
    {
        CurrentState = startingState;
        CurrentState.Enter();
    }

    public void TransitionTo(PlayerState nextState)
    {
        CurrentState.Exit();
        CurrentState = nextState;
        CurrentState.Enter();
    }

    public void Update()
    {
        if (CurrentState != null)
        {
            CurrentState.Update();
        }
    }
}