using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "Create SkillDataSO", fileName = "SkillDataSO")]
public class SkillDataSO : ScriptableObject
{
    public List<SkillData> skillDatasList = new();
}