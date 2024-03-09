using System.Collections;
using System.Collections.Generic;
using UnityEngine;
//[CreateAssetMenu(fileName = "F", menuName = "M")]
//それを押すとこの`AttackRangeSizeSO`が`F(AttackRangeSizeSO)`という名前でアセット化されてassetsフォルダに入る
[CreateAssetMenu(fileName = "AttackRangeSizeSO", menuName = "Create AttackRangeSizeSO")]
public class AttackRangeSizeSO : ScriptableObject
{
    public List<AttackRangeSize> attackRangeSizesList = new List<AttackRangeSize>();
}