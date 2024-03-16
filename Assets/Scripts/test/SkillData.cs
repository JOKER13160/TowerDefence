using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

/// <summary>
/// スキルの種類
/// </summary>
public enum SkillType
{
    Attack,
    Defence,
    Support
    // 他にもあれば追加

}

[Serializable]
public class SkillData
{
    public int id;
    public int skillNo;
    public SkillType skillType;
    public int rarity;
    public int cost;
    public string skillName;
    public string description;


    /// <summary>
    /// コンストラクタ
    /// </summary>
    /// <param name="datas"></param>
    public SkillData(string[] datas)
    {

        // 取得した情報の確認
        for (int i = 0; i < datas.Length; i++)
        {
            Debug.Log(datas[i]);
        }

        // 取得した情報をキャストして代入
        id = int.Parse(datas[0]);
        skillNo = int.Parse(datas[1]);
        skillType = (SkillType)Enum.Parse(typeof(SkillType), datas[2]);
        rarity = int.Parse(datas[3]);
        cost = int.Parse(datas[4]);
        skillName = datas[5];
        description = datas[6];
    }
}