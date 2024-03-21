using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameData : MonoBehaviour
{
    [SerializeField]
    public int goldAddTime; //n時間ごとにゴールド増加
    [SerializeField]
    public int nowGold;     //現在の所持ゴールド
    [SerializeField]
    public int timeToGold;  //時間経過で増えるゴールド
    [SerializeField]
    public int maxGold;     //最大値

    //時間経過でゴールド増加メソッド
    //コルーチン
    //比較　timer >= goldAddTime
    //

    
}
