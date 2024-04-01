using UnityEngine;

public class playerIdleState : PlayerState
{
    private Player player;

    public playerIdleState(Player player)
    {
        this.player = player;
    }

    public override void Enter()
    {
        Debug.Log($"{player.gameObject.name} has entered idle state");
    }

    public override void Update()
    {
        // Player will remain in idle state until explicitly told otherwise
        player.Turn();
    }

    public override void Exit()
    {
        Debug.Log($"{player.gameObject.name} has exited idle state");
    }
}