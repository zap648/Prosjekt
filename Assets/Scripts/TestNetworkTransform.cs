using System.Collections;
using System.Collections.Generic;
using Unity.Netcode;
using UnityEngine;

public class TestNetworkTransform : NetworkBehaviour
{
    void Update()
    {
        if (IsServer)
        {
            float theta = Time.frameCount / 10.0f;
            transform.position = new Vector3((float) System.Math.Cos(theta), 0.0f, (float) System.Math.Sin(theta));
        }
        
    }
}
