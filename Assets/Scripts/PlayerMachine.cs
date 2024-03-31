using System;
using UnityEngine;

public interface PlayerState
{
    public void Enter()
    {

    }

    public void Update()
    {

    }

    public void Exit()
    {

    }
}

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

public class playerIdleState : PlayerState
{
    private Player player;

    public playerIdleState(Player player)
    {
        this.player = player;
    }

    public void Enter()
    {
        Debug.Log($"{player.gameObject.name} has entered idle state");
    }

    public void Update()
    {
        // Player will remain idle until explicitly told otherwise
    }

    public void Exit()
    {
        Debug.Log($"{player.gameObject.name} has exited idle state");
    }
}

public class playerWalkState : PlayerState
{
    private Player player;

    public playerWalkState(Player player)
    {
        this.player = player;
    }

    public void Enter()
    {
        Debug.Log($"{player.gameObject.name} has entered walk state");
    }

    public void Update()
    {
        // Player will remain idle until explicitly told otherwise
    }

    public void Exit()
    {
        Debug.Log($"{player.gameObject.name} has exited walk state");
    }
}

public class playerUseState : PlayerState
{
    private Player player;

    public playerUseState(Player player)
    {
        this.player = player;
    }

    public void Enter()
    {
        Debug.Log($"{player.gameObject.name} has entered walk state");
    }

    public void Update()
    {
        // Player will remain idle until explicitly told otherwise
    }

    public void Exit()
    {
        Debug.Log($"{player.gameObject.name} has exited walk state");
    }
}