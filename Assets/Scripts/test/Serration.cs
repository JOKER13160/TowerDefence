using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Serration : SkillBase
{
    [SerializeField]
    protected float damageUp=3;
    // Start is called before the first frame update
    //void Start()
    //{
    //    PlaySkill();
    //}

    public override void PlaySkill()
    {
        Debug.Log($"damageUp : {damageUp}");
    }
}
