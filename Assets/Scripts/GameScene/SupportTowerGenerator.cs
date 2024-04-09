using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SupportTowerGenerator : MonoBehaviour
{
    public GameObject goldTowerPrefab; // �S�[���h�^���[�̃v���n�u
    private void OnMouseDown()
    {
        //���ꂪ�N���b�N���ꂽ��switch
        switch(gameObject.tag)
        {
            case "Gold":
                //Gold���N���b�N���ꂽ���̏���
                Debug.Log("�S�[���h�^���[");
                GenerateGoldTower();
                break;
        }
    }

    // �S�[���h�^���[�𐶐����郁�\�b�h
    private void GenerateGoldTower()
    {
        // �S�[���h�^���[�̃v���n�u�����݂̈ʒu�ɐ�������
        Instantiate(goldTowerPrefab, transform.position, Quaternion.identity);
    }
}
