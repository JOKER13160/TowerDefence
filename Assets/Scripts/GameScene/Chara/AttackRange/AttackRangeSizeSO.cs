using System.Collections;
using System.Collections.Generic;
using UnityEngine;
//[CreateAssetMenu(fileName = "F", menuName = "M")]
//����������Ƃ���`AttackRangeSizeSO`��`F(AttackRangeSizeSO)`�Ƃ������O�ŃA�Z�b�g�������assets�t�H���_�ɓ���
[CreateAssetMenu(fileName = "AttackRangeSizeSO", menuName = "Create AttackRangeSizeSO")]
public class AttackRangeSizeSO : ScriptableObject
{
    public List<AttackRangeSize> attackRangeSizesList = new List<AttackRangeSize>();
}