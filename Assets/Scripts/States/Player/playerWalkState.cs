using UnityEngine;

public class playerWalkState : PlayerState
{
    private Player player;

    public playerWalkState(Player player)
    {
        this.player = player;
    }

    public override void Enter()
    {
        Debug.Log($"{player.gameObject.name} has entered walk state");
    }

    public override void Update()
    {
        // Player will remain in walk state until explicitly told otherwise
        player.Turn();
        player.Move();
    }

    public override void Exit()
    {
        Debug.Log($"{player.gameObject.name} has exited walk state");
    }
}