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
        id = int.Parse(datas[0]);
        skillNo = int.Parse(datas[1]);
        skillType = (SkillType)Enum.Parse(typeof(SkillType), datas[2]);
        rarity = int.Parse(datas[3]);
        cost = int.Parse(datas[4]);
        skillName = datas[5];
        description = datas[6];
    }
}