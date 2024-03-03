using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HeavyCalliber : SkillBase
{
    // Start is called before the first frame update
    public override void PlaySkill()
    {
        Debug.Log($"capacity : {capacity}");
        base.PlaySkill();
    }

    //protected void Start()
    //{
    //    PlaySkill();
    //}
}
