using System;
using UnityEngine;

[Serializable]
public struct TestForSaveingStruct
{
    public string charName;

    public void naming(string n)
    {
        this.charName = n;
    }
}