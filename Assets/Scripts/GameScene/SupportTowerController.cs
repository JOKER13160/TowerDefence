using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SupportTowerController : MonoBehaviour
{
    private void OnMouseDown()
    {
        //���ꂪ�N���b�N���ꂽ��switch
        switch(gameObject.tag)
        {
            case "Gold":
                //Gold���N���b�N���ꂽ���̏���
                Debug.Log("�S�[���h�^���[");
                break;
        }
    }

}
