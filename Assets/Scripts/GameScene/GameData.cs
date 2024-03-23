using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameData : MonoBehaviour
{
    public static GameData Instance;

    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(gameObject);
        }

        else
            Destroy(gameObject); // ��d������h��
    }

    [SerializeField]
    public int goldAddTime; //n���Ԃ��ƂɃS�[���h����
    [SerializeField]
    public int nowGold;     //���݂̏����S�[���h
    [SerializeField]
    public int timeToGold;  //���Ԍo�߂ő�����S�[���h
    [SerializeField]
    public int maxGold;     //�ő�l

    //[SerializeField]
    //GameManager gameManager;

    //���Ԍo�߂ŃS�[���h�������\�b�h
    //�R���[�`��
    //��r�@timer >= goldAddTime
    //�ő�l�ł͂Ȃ�����
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
            // �������m�F���Ă���AnowGold �̉��Z�������s��
            if (GameManager.Instance.timer >= goldAddTime && nowGold < maxGold)
            {
                nowGold = nowGold + timeToGold;
                Debug.Log("�S�[���h�ǉ�");
                GameManager.Instance.timer = 0;
            }
            // ���[�v���ꎞ��~���A���̃t���[���܂Ő����Ԃ�
            yield return null;

        }
    }


}
