using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
//[CreateAssetMenu(fileName = "F", menuName = "M")]
//それを押すとこの`AttackRangeSizeSO`が`F(AttackRangeSizeSO)`という名前でアセット化されてassetsフォルダに入る
[CreateAssetMenu(fileName = "AttackRangeSizeSO", menuName = "Create AttackRangeSizeSO")]
public class AttackRangeSizeSO : ScriptableObject
{
    public List<AttackRangeSize> attackRangeSizesList = new List<AttackRangeSize>();

    public Vector2 GetAttackRangeSize(AttackRangeType attackRangeType)
    {
        AttackRangeSize size = attackRangeSizesList.FirstOrDefault(x => x.attackRangeType == attackRangeType);
        if (size != null)
            return size.size;
        else
            return Vector2.zero; // Or some default value
    }
}