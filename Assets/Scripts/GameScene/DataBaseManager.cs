using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;

public class DataBaseManager : MonoBehaviour
{
    public static DataBaseManager instance;

    public CharaDataSO charaDataSO;
    public AttackRangeSizeSO attackRangeSizeSO;
    public SkillDataSO skillDataSO;

    void Awake()
    {
        if (instance == null)
        {
            instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
    }

    /// <summary>
    /// AttackRangeType ‚©‚ç BoxCollier —p‚Ì Size ‚ðŽæ“¾
    /// </summary>
    /// <param name="attackRangeType"></param>
    /// <returns></returns>
    public Vector2 GetAttackRangeSize(AttackRangeType attackRangeType)
    {
        return attackRangeSizeSO.attackRangeSizesList.Find(x => x.attackRangeType == attackRangeType).size;
    }
}