using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "TowerDataSO",menuName = "Create TowerDataSO")]
public class TowerDataSO : ScriptableObject
{
    public List<TowerData> towerDatasList = new List<TowerData>();

}
