using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SkillBase : MonoBehaviour
{
    [SerializeField]
    protected int capacity;
    [SerializeField]
    protected string skillName;

    public virtual void PlaySkill()//�q�N���X�����\�b�h�̒��g��ς�����(virtual)
    {
        Debug.Log(skillName);
    }
}
