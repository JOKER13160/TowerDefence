using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance;

    private void Awake()
    {
        if (Instance == null)
            Instance = this;
        else
            Destroy(gameObject); // ��d������h��
    }

    [SerializeField]
    private EnemyGenerator enemyGenerator;

    [SerializeField]
    private CharaGenerator charaGenerator;

    public bool isEnemyGenerate;

    public int generateIntervalTime;

    public int generateEnemyCount;

    public int maxEnemyCount;

    [SerializeField]
    private int enemyDestroyCount = 0;

    //�@�G�̏����ꌳ�����ĊǗ�����
    [SerializeField]
    private List<EnemyController> enemiesList = new List<EnemyController>();

    //�^�C�}�[�V�X�e��
    public int timer;

    

    public enum GameState
    {
        Preparate,  //�Q�[���̏�����(���[�h)
        Select,     //�X�^�[�g���
        Arsenal,    //�Ґ����
        Play,       //�Q�[���v���C���
        Pause,      //�|�[�Y��
        GameUp      //�N���A�A�Q�[���I�[�o�[�ǂ��炩
    }

    public GameState currentGameState;

    [SerializeField]
    private List <EnemyGenerator> enemyGeneratorList = new List<EnemyGenerator>();


    void Start()
    {
        // �Q�[���̐i�s��Ԃ��������ɐݒ�
        SetGameState(GameState.Preparate);


        // TODO �Q�[���f�[�^��������


        // TODO �X�e�[�W�̐ݒ� + �X�e�[�W���Ƃ� PathData ��ݒ�

        // �L�����z�u�p�|�b�v�A�b�v�̐����Ɛݒ�
        StartCoroutine(charaGenerator.SetUpCharaGenerator(this));

        // TODO ���_�̐ݒ�


        // TODO �I�[�v�j���O���o�Đ�

        // �����̋�������
        isEnemyGenerate = true;

        // �Q�[���̐i�s��Ԃ��v���C���ɕύX
        SetGameState(GameState.Play);

        // �G�̐�������
        foreach (EnemyGenerator enemyGenerator in enemyGeneratorList)
        {
            StartCoroutine(enemyGenerator.PreparateEnemyGenerate(this));
        }
        

        // �J�����V�[�̎����l�������̊J�n
        StartCoroutine(TimerCount());
        StartCoroutine(GameData.Instance.TimeToGold());
    }


    /// <summary>
    /// �G�̏��� List �ɒǉ�
    /// </summary>
    /// <param name="enemy"></param>
    public void AddEnemyList(EnemyController enemy)
    {    //�@TODO�@�G�̏��� List �ɒǉ�����ۂɁA������ǉ�


        //�@TODO�@�G�̏��� List �ɒǉ�
        enemiesList.Add(enemy);
        // �G�̐��������J�E���g�A�b�v
        generateEnemyCount++;
    }

    /// <summary>
    /// �G�̐������~���邩����
    /// </summary>
    public void JudgeGenerateEnemysEnd()
    {
        if (generateEnemyCount >= maxEnemyCount)
        {
            isEnemyGenerate = false;
        }
    }

    /// <summary>
    /// GameState �̕ύX
    /// </summary>
    /// <param name="nextGameState"></param>
    public void SetGameState(GameState nextGameState)
    {
        currentGameState = nextGameState;//�Q�[���̏�Ԃ�ݒ�
    }

    /// <summary>
    /// ���ׂĂ̓G�̈ړ����ꎞ��~
    /// </summary>
    public void PauseEnemies()
    {
        for (int i = 0; i < enemiesList.Count; i++)
        {
            enemiesList[i]?.PauseMove();
        }
    }

    /// <summary>
    /// ���ׂĂ̓G�̈ړ����ĊJ
    /// </summary>
    public void ResumeEnemies()
    {
        for (int i = 0; i < enemiesList.Count; i++)
        {
            enemiesList[i].ResumeMove();
        }
    }

    /// <summary>
    /// �G�̏��� List ����폜
    /// </summary>
    /// <param name="removeEnemy"></param>
    public void RemoveEnemyList(EnemyController removeEnemy)
    {
        enemiesList.Remove(removeEnemy);
    }

    public void EnemyDestroyCount()
    {
        enemyDestroyCount++;
        Debug.Log("EnemyDestroyCount:" + enemyDestroyCount);
    }

    // �Q�[���N���A����
    public void GameClearJudge()
    {
        //�@TODO �G�L�����j��񐔂̃J�E���g
        EnemyDestroyCount();

        //�@maxEnemyCount(GameManager)�Ɣj�󐔂��r
        if (enemyDestroyCount == maxEnemyCount)
        {
            //  �N���A���胁�\�b�h�Ăяo��
            Debug.Log("�Q�[���N���A");
        }
        
    }

    // �^�C�}�[�v�����\�b�h
    public IEnumerator TimerCount()
    {
        while(true)
        {
            if(currentGameState == GameState.Play)
            {
                timer++;
            }
          
            yield return new WaitForSeconds(1f);
        }
        
    }

    public void RemoveEnemyGenerator(EnemyGenerator enemyGenerator)
    {
        enemyGeneratorList.Remove(enemyGenerator);
        JudgeGenerateList();
    }

    private void JudgeGenerateList()
    {
        if (enemyGeneratorList.Count == 0)
        {
            Debug.Log("�Q�[���N���A");
        }
    }

    
}
