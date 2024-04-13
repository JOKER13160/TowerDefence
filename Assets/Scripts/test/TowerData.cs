using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class TowerData
{
    public string TowerName;
    public int TowerID;
    public int Cost;
    public int Interval;
    public int GetGold;

    public TowerData(string[] datas) { 
        TowerName = datas[0];
        TowerID = int.Parse(datas[1]);
        Cost = int.Parse(datas[2]);
        Interval = int.Parse(datas[3]);
        GetGold = int.Parse(datas[4]);
    }
}
