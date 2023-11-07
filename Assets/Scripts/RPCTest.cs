using System.Collections;
using System.Collections.Generic;
using Unity.Netcode;
using UnityEngine;

public class RPCTest : NetworkBehaviour
{
    public override void OnNetworkSpawn()
    {
        if (!IsServer && IsOwner)
        {
            TestServerRpc(0, NetworkObjectId);
        }
    }
    [ClientRpc]
    void TestClientRpc(int value, ulong source_network_object_id)
    {
        Debug.Log($"Client Received the RPC #{value} on NetworkObject #{source_network_object_id}");
        if (IsOwner)
        {
            TestServerRpc(value+1, source_network_object_id);
        }
    }
    [ServerRpc]
    void TestServerRpc(int value, ulong source_network_object_id)
    {
        Debug.Log($"Server Received the RPC #{value} on NetworkObject #{source_network_object_id}");
        TestClientRpc(value, source_network_object_id);
    }
}
