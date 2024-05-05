using System;
using UnityEngine;

[Serializable]
public struct Save_PersonInfo 
{
    private int GENDER;
    private int AGE;

    public void setInfo(int g, int a)
    {  
        GENDER = g; 
        AGE = a;
    }
    public int getGender() { return GENDER;}
    public int getAge() {  return AGE;}
}
