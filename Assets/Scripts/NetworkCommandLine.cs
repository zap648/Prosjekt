using System.Collections;
using System.Collections.Generic;
using Unity.Netcode;
using UnityEngine;

/// SOURCE: https://docs-multiplayer.unity3d.com/netcode/current/tutorials/command-line-helper/
/// making a command line to make bugtesting easier

public class NetworkCommandLine : MonoBehaviour
{
    private NetworkManager netManager;
    [SerializeField] PlayerSpawner spawner;
    private void Start()
    {
        netManager = GetComponentInParent<NetworkManager>();
        // spawner = GetComponent<PlayerSpawner>();
        if (Application.isEditor)
        {
            return;
        }

        var args = GetCommandlineArgs();

        spawner.Log("What is args: " + args.ToString());
        
        if (args.TryGetValue("-mode", out string mode))
        {
            spawner.Log("Our mood is: " + mode);

            string[] pls = mode.Split(',');
            spawner.Log("Mood is now split into: " + pls[0]);
            
            switch (pls[0])
            {
                case "server":
                    netManager.StartServer();
                    if (!netManager.IsServer)
                        spawner.Log("Server did not server");
                    else
                        spawner.Log("server was a mess."); 
                    break;
                case "host":
                    netManager.StartHost();
                    if (!netManager.IsHost)
                        spawner.Log("Host did not host");
                    else
                        spawner.Log("Host was not nice.");
                    break;
                case "client":
                    netManager.StartClient();
                    if (!netManager.IsClient)
                        spawner.Log("Client did not visit");
                    else
                        spawner.Log("Client was not nice."); 
                    break;
                default:
                    spawner.Log("NetworkCommandLine: Start: PlayerSpawner.Log: Switch-case: deafault response.");
                    break;
            }
        }
    }

    private Dictionary<string, string> GetCommandlineArgs()
    {
        Dictionary<string, string> argDictionary = new Dictionary<string, string>();
        
        var args = System.Environment.GetCommandLineArgs();

        for (int i = 0; i < args.Length; i++)
        {
            var arg = args[i].ToLower();

            if (arg.StartsWith("-"))
            {
                var value = i < args.Length - 1 ? args[i + 1].ToLower() : null;
                value = (value?.StartsWith("-") ?? false) ? null : value;

                argDictionary.Add(arg, value);
            }
        }
        return argDictionary;
    }
}
