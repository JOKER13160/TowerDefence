using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "DisasterDataSO",menuName = "Create DisasterDataSO")]
public class DisasterDataSO : ScriptableObject
{
    public List<DisasterData> disasterDatasList = new List<DisasterData>();
}
