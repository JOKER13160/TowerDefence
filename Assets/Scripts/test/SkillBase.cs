using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SkillBase : MonoBehaviour
{
    [SerializeField]
    protected int capacity;
    [SerializeField]
    protected string skillName;

    public virtual void PlaySkill()//子クラスがメソッドの中身を変えられる(virtual)
    {
        Debug.Log(skillName);
    }
}
