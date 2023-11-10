using System;
using System.Collections;
using System.Collections.Generic;
using Unity.Netcode;
using System.IO;
using UnityEngine;
using Unity.VisualScripting.Antlr3.Runtime.Misc;

public class PlayerSpawner : MonoBehaviour
{

    private string logFilePath = Application.dataPath + "/debug_log.txt";
    private int i;

    private void Start()
    {
        i++;
        Log("Boop-ity-boop-bop!");
    }

    public void Log(string message)
    {
        if (!File.Exists(logFilePath))
        {
            File.Create(logFilePath);
        }
        writeToFiles(message, logFilePath);
    }
    private void writeToFiles(string message, string logFilePath)
    {
        using (StreamWriter sw = new StreamWriter(logFilePath, true))
        {
            sw.WriteLine($"{DateTime.Now}: {message}, {i}");
            sw.Close();
        }
    }
}
