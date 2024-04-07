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
            Destroy(gameObject); // 二重生成を防ぐ
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

    //　敵の情報を一元化して管理する
    [SerializeField]
    private List<EnemyController> enemiesList = new List<EnemyController>();

    //タイマーシステム
    public int timer;

    

    public enum GameState
    {
        Preparate,  //ゲームの準備中(ロード)
        Select,     //スタート画面
        Arsenal,    //編成画面
        Play,       //ゲームプレイ画面
        Pause,      //ポーズ中
        GameUp      //クリア、ゲームオーバーどちらか
    }

    public GameState currentGameState;

    [SerializeField]
    private List <EnemyGenerator> enemyGeneratorList = new List<EnemyGenerator>();


    void Start()
    {
        // ゲームの進行状態を準備中に設定
        SetGameState(GameState.Preparate);


        // TODO ゲームデータを初期化


        // TODO ステージの設定 + ステージごとの PathData を設定

        // キャラ配置用ポップアップの生成と設定
        StartCoroutine(charaGenerator.SetUpCharaGenerator(this));

        // TODO 拠点の設定


        // TODO オープニング演出再生

        // 生成の許可をする
        isEnemyGenerate = true;

        // ゲームの進行状態をプレイ中に変更
        SetGameState(GameState.Play);

        // 敵の生成準備
        foreach (EnemyGenerator enemyGenerator in enemyGeneratorList)
        {
            StartCoroutine(enemyGenerator.PreparateEnemyGenerate(this));
        }
        

        // カレンシーの自動獲得処理の開始
        StartCoroutine(TimerCount());
        StartCoroutine(GameData.Instance.TimeToGold());
    }


    /// <summary>
    /// 敵の情報を List に追加
    /// </summary>
    /// <param name="enemy"></param>
    public void AddEnemyList(EnemyController enemy)
    {    //　TODO　敵の情報を List に追加する際に、引数を追加


        //　TODO　敵の情報を List に追加
        enemiesList.Add(enemy);
        // 敵の生成数をカウントアップ
        generateEnemyCount++;
    }

    /// <summary>
    /// 敵の生成を停止するか判定
    /// </summary>
    public void JudgeGenerateEnemysEnd()
    {
        if (generateEnemyCount >= maxEnemyCount)
        {
            isEnemyGenerate = false;
        }
    }

    /// <summary>
    /// GameState の変更
    /// </summary>
    /// <param name="nextGameState"></param>
    public void SetGameState(GameState nextGameState)
    {
        currentGameState = nextGameState;//ゲームの状態を設定
    }

    /// <summary>
    /// すべての敵の移動を一時停止
    /// </summary>
    public void PauseEnemies()
    {
        for (int i = 0; i < enemiesList.Count; i++)
        {
            enemiesList[i]?.PauseMove();
        }
    }

    /// <summary>
    /// すべての敵の移動を再開
    /// </summary>
    public void ResumeEnemies()
    {
        for (int i = 0; i < enemiesList.Count; i++)
        {
            enemiesList[i].ResumeMove();
        }
    }

    /// <summary>
    /// 敵の情報を List から削除
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

    // ゲームクリア判定
    public void GameClearJudge()
    {
        //　TODO 敵キャラ破壊回数のカウント
        EnemyDestroyCount();

        //　maxEnemyCount(GameManager)と破壊数を比較
        if (enemyDestroyCount == maxEnemyCount)
        {
            //  クリア判定メソッド呼び出し
            Debug.Log("ゲームクリア");
        }
        
    }

    // タイマー計測メソッド
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
            Debug.Log("ゲームクリア");
        }
    }

    
}
