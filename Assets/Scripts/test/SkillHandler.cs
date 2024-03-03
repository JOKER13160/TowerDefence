using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SkillHandler : MonoBehaviour
{
    [SerializeField]
    private SkillBase skill;
    // Start is called before the first frame update
    void Start()
    {
        skill.PlaySkill();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
