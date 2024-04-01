using UnityEngine;

public class playerUseState : PlayerState
{
    private Player player;

    public playerUseState(Player player)
    {
        this.player = player;
    }

    public override void Enter()
    {
        Debug.Log($"{player.gameObject.name} has entered walk state");
    }

    public override void Update()
    {
        // Player will remain in use state until explicitly told otherwise
    }

    public override void Exit()
    {
        Debug.Log($"{player.gameObject.name} has exited walk state");
    }
}