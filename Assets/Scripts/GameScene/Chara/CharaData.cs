using UnityEngine;

/// <summary>
/// �L�����̏ڍ׃f�[�^
/// </summary>
[System.Serializable]
public class CharaData
{
    public int charaNo;
    public int cost;
    public Sprite charaSprite;
    public AnimationClip charaAnim;
    public string charaName;

    public int attackPower;
    public AttackRangeType attackRange;
    public float intervalAttackTime;
    public int maxAttackCount;

    [Multiline]
    public string discription;

    // TODO ���ɂ�����Βǉ�

}