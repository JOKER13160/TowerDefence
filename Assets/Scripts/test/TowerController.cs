using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TowerController : MonoBehaviour
{
    public TowerData towerData;

    private void Start()
    {
        StartCoroutine(TimeToGold());
    }

    public IEnumerator TimeToGold()
    {
        // ���[�v���ŏ�����J�n�����悤�ɂ���
        while (true)
        {
            if (GameManager.Instance.currentGameState != GameManager.GameState.Play)
            {
                yield return null;
                continue;
            }
            yield return new WaitForSeconds(towerData.Interval);
            // �������m�F���Ă���AnowGold �̉��Z�������s��

            GameData.Instance.nowGold += towerData.GetGold;
            Debug.Log("�^���[�ɂ��S�[���h�ǉ�");


            // ���[�v���ꎞ��~���A���̃t���[���܂Ő����Ԃ�
            yield return null;

        }
    }
}
