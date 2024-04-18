using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SupportTowerGenerator : MonoBehaviour
{
    public GameObject goldTowerPrefab; // �S�[���h�^���[�̃v���n�u
    [SerializeField]
    private GameObject PopUp;
    [SerializeField]
    private CanvasGroup canvasGroup;
    [SerializeField]
    private Button btnClosePopUp;
    [SerializeField]
    private Button btnChooseTower;

    

    private void Start()
    {
        // �e�{�^���Ƀ��\�b�h��o�^
        btnChooseTower.onClick.AddListener(GenerateGoldTower);
        btnClosePopUp.onClick.AddListener(()=>UIManager.Instance.OnClickClosePopUp(canvasGroup));

        UIManager.Instance.SwitchActivateButtons(false,btnChooseTower);
        UIManager.Instance.SwitchActivateButtons(false,btnClosePopUp);
    }
    private void OnMouseDown()
    {
        //���ꂪ�N���b�N���ꂽ��switch
        switch(gameObject.tag)
        {
            case "Gold":
                //Gold���N���b�N���ꂽ���̏���
                Debug.Log("�S�[���h�^���[");
                UIManager.Instance.ShowPopUp(canvasGroup);//�|�b�v�A�b�v�A�N�e�B�u

                UIManager.Instance.SwitchActivateButtons(true, btnChooseTower);
                UIManager.Instance.SwitchActivateButtons(true, btnClosePopUp);
                //GenerateGoldTower();
                break;
        }
    }

    // �S�[���h�^���[�𐶐����郁�\�b�h
    private void GenerateGoldTower()
    {
        // �S�[���h�^���[�̃v���n�u�����݂̈ʒu�ɐ�������
        Instantiate(goldTowerPrefab, transform.position, Quaternion.identity);
        UIManager.Instance.HidePopUp(canvasGroup);
        UIManager.Instance.SwitchActivateButtons(false, btnChooseTower);
        UIManager.Instance.SwitchActivateButtons(false, btnClosePopUp);
    }
}
