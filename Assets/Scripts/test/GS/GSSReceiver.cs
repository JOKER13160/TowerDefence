using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;

/// <summary>
/// �X�v���b�h�V�[�g����擾�����f�[�^���V�[�g�P�ʂŔC�ӂ̃X�N���v�^�u���E�I�u�W�F�N�g�ɒl�Ƃ��Ď�荞��
/// </summary>
[RequireComponent(typeof(GSSReader))]
public class GSSReceiver : MonoBehaviour
{
    public bool IsLoading { get; set; }�@�@//�@�v���p�e�B�̂܂܂ł��ƃC���X�y�N�^�[����m�F�ł��Ȃ����߁A�ꎞ�I�ɕϐ��ɂ��Ă������ł��傤


    private void Awake()
    {

        // GSS �̃f�[�^�擾����
        StartCoroutine(PrepareGSSLoadStart());
    }

    /// <summary>
    /// GSS �̃f�[�^�擾����
    /// </summary>
    /// <returns></returns>
    private IEnumerator PrepareGSSLoadStart()
    {

        IsLoading = true;

        // GSS ���擾���� SO �Ɏ擾����B���̏������I���܂ł����őҋ@����
        yield return StartCoroutine(GetComponent<GSSReader>().GetFromWeb());

        IsLoading = false;

        Debug.Log("GSS �f�[�^�� SO �Ɏ擾");
    }

    /// <summary>
    /// �C���X�y�N�^�[���� GSSReader �� OnLoadEnd �ɂ��̃��\�b�h��ǉ����邱�Ƃ� GSS �̓ǂݍ��݊������ɃR�[���o�b�N�����
    /// </summary>
    public void OnGSSLoadEnd()
    {

        GSSReader reader = GetComponent<GSSReader>();

        // �X�v���b�h�V�[�g����擾�����e�V�[�g�̔z��� List �ɕϊ�
        List<SheetData> sheetDataslist = reader.sheetDatas.ToList();

        // ��񂪎擾�ł����ꍇ
        if (sheetDataslist != null)
        {

            // �X�N���v�^�u���E�I�u�W�F�N�g�ɑ��(��P)
            DataBaseManager.instance.skillDataSO.skillDatasList =
                new List<SkillData>(sheetDataslist.Find(x => x.SheetName == SheetName.SkillData).DatasList.Select(x => new SkillData(x)).ToList());

            // TODO ���� SO ��ǉ�����
            DataBaseManager.instance.towerDataSO.towerDatasList =
                new List<TowerData>(sheetDataslist.Find(x => x.SheetName == SheetName.TowerData).DatasList.Select(x => new TowerData(x)).ToList());

            DataBaseManager.instance.disasterDataSO.disasterDatasList =
                new List<DisasterData>(sheetDataslist.Find(x => x.SheetName == SheetName.DisasterData).DatasList.Select(x => new DisasterData(x)).ToList());

        }
    }
}