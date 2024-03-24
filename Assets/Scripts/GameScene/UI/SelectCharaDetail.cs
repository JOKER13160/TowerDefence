using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using DG.Tweening;

public class SelectCharaDetail : MonoBehaviour
{
    [SerializeField]
    private Button btnSelectCharaDetail;

    [SerializeField]
    private Image imgChara;

    private PlacementCharaSelectPopUp placementCharaSelectPop;

    private CharaData charaData;

    private void Start()
    {
        StartCoroutine(ToggleButtonToCost(this.charaData.cost, this.btnSelectCharaDetail));
    }

    /// <summary>
    /// SelectCharaDetail �̐ݒ�
    /// </summary>
    /// <param name="placementCharaSelectPop"></param>
    /// <param name="charaData"></param>
    public void SetUpSelectCharaDetail(PlacementCharaSelectPopUp placementCharaSelectPop, CharaData charaData)
    {

        this.placementCharaSelectPop = placementCharaSelectPop;
        this.charaData = charaData;


        // �{�^���������Ȃ���Ԃɐ؂�ւ���
        //UIManager.Instance.DisableButton(btnSelectCharaDetail);

        imgChara.sprite = this.charaData.charaSprite;


        // �{�^���Ƀ��\�b�h��o�^
        btnSelectCharaDetail.onClick.AddListener(OnClickSelectCharaDetail);

        // TODO �R�X�g�ɉ����ă{�^���������邩�ǂ�����؂�ւ���
        //StartCoroutine(ToggleButtonToCost(charaData.cost, btnSelectCharaDetail));
        
        
    }

    /// <summary>
    /// SelectCharaDetail ���������̏���
    /// </summary>
    private void OnClickSelectCharaDetail()
    {

        // TODO �A�j�����o

        // �^�b�v���� SelectCharaDetail �̏����|�b�v�A�b�v�ɑ���
        
        placementCharaSelectPop.SetSelectCharaDetail(charaData);


    }

    private IEnumerator ToggleButtonToCost(int charaCost,Button button)
    {
        //�L�����̃R�X�g�������S�[���h�ȉ��Ȃ�{�^��������
        while (true)
        {
            if(charaCost <= GameData.Instance.nowGold)
            {
                UIManager.Instance.EnableButton(button);
            }
            else
            {
                UIManager.Instance.DisableButton(button);
            }
            yield return null;
        }
          
    }
}