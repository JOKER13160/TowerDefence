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

public enum Rarity
{
    common,
    rare,
    legendary
}

[Serializable]
public class SkillData
{
    public int id;
    public SkillType skillType;
    public Rarity rarity;
    public int cost;
    public int maxLv;
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
        Debug.Log(datas[0]);
        if (datas != null)
        {
            id = int.Parse(datas[0]);
            skillType = (SkillType)Enum.Parse(typeof(SkillType), datas[1]);
            rarity = (Rarity)Enum.Parse(typeof(Rarity), datas[2]);
            cost = int.Parse(datas[3]);
            maxLv = int.Parse(datas[4]);
            skillName = datas[5];
            description = datas[6];
        }
    }
}