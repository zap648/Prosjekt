using System;
using UnityEngine;

[System.Serializable]
public struct Save_PersonInfo
{
    [SerializeField] private int sl_GENDER;
    [SerializeField] private int sl_AGE;

    public void setInfo(int g, int a)
    {
        sl_GENDER = g;
        sl_AGE = a;
    }
    
    public int Gender {  get { return sl_GENDER; } }
    public int getGender() { return sl_GENDER; }
    public int getAge() {  return sl_AGE; }
}
