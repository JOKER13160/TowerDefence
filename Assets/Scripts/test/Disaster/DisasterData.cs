using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class DisasterData
{
    public string DisasterName;
    public int DisasterID;
    public string DisasterType;
    public string Description;

    public DisasterData(string[] datas)
    {
        DisasterName = datas[0];
        DisasterID = int.Parse(datas[1]);
        DisasterType = datas[2];
        Description = datas[3];
    }
}
