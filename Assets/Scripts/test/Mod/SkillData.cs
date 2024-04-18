using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

/// <summary>
/// �X�L���̎��
/// </summary>
public enum SkillType
{
    Attack,
    Defence,
    Support
    // ���ɂ�����Βǉ�

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
    /// �R���X�g���N�^
    /// </summary>
    /// <param name="datas"></param>
    public SkillData(string[] datas)
    {

        // �擾�������̊m�F
        for (int i = 0; i < datas.Length; i++)
        {
            Debug.Log(datas[i]);
        }

        // �擾���������L���X�g���đ��
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