using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    [SerializeField]
    private EnemyGenerator enemyGenerator;

    [SerializeField]
    private CharaGenerator charaGenerator;

    public bool isEnemyGenerate;

    public int generateIntervalTime;

    public int generateEnemyCount;

    public int maxEnemyCount;

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
        StartCoroutine(enemyGenerator.PreparateEnemyGenerate(this));

        // TODO カレンシーの自動獲得処理の開始
    }


    /// <summary>
    /// 敵の情報を List に追加
    /// </summary>
    public void AddEnemyList()
    {    //　TODO　敵の情報を List に追加する際に、引数を追加

        //　TODO　敵の情報を List に追加

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
}
