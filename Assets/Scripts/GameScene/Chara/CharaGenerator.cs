using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;

public class CharaGenerator : MonoBehaviour
{
    //[SerializeField]
    //private GameObject charaPrefab;

    [SerializeField]
    private CharaController charaControllerPrefab;

    [SerializeField]
    private CharaData charaData;

    [SerializeField]
    private Grid grid;         // Base 側の Grid を指定する 

    [SerializeField]
    private Tilemap tilemaps;   // Walk 側の Tilemap を指定する

    [SerializeField]
    private PlacementCharaSelectPopUp placementCharaSelectPopUpPrefab;　　　//　PlacementCharaSelectPopUp プレファブゲームオブジェクトをアサイン用

    [SerializeField]
    private Transform canvasTran;                                           //　PlacementCharaSelectPopUp ゲームオブジェクトの生成位置の登録用

    [SerializeField, Header("キャラのデータリスト")]
    public List<CharaData> charaDatasList = new List<CharaData>();

    private PlacementCharaSelectPopUp placementCharaSelectPopUp;　　　　　　//　生成された PlacementCharaSelectPopUp ゲームオブジェクトを代入するための変数

    private GameManager gameManager;

    private Vector3Int gridPos;


    void Update()
    {
        // TODO 配置できる最大キャラ数に達している場合には配置できない

        // 画面をタップ(マウスクリック)し、かつ、配置キャラポップアップが非表示状態、かつ、
        // ゲームの現在の進行状態が Play なら
        if (Input.GetMouseButtonDown(0) && !placementCharaSelectPopUp.gameObject.activeSelf && gameManager.currentGameState == GameManager.GameState.Play)
        {

            // タップ(マウスクリック)の位置を取得してワールド座標に変換し、それをさらにタイルのセル座標に変換
            gridPos = grid.WorldToCell(Camera.main.ScreenToWorldPoint(Input.mousePosition));


            ////*  新しい処理を追加  *////


            // タップした位置のタイルのコライダーの情報を確認し、それが None であるなら
            if (tilemaps.GetColliderType(gridPos) == Tile.ColliderType.None)
            {

                // キャラ生成処理をメソッド化
                //CreateChara(gridPos);
                

                // 配置キャラ選択用ポップアップの表示
                ActivatePlacementCharaSelectPopUp();

            }

        }
    }

    /// <summary>
    /// キャラ生成
    /// </summary>
    /// <param name="gridPos"></param>
    //private void CreateChara(Vector3Int gridPos)
    //{

    //    // タップした位置にキャラを生成して配置
    //    GameObject chara = Instantiate(charaPrefab, gridPos, Quaternion.identity);

    //    // キャラの位置がタイルの左下を 0,0 として生成しているので、タイルの中央にくるように位置を調整
    //    chara.transform.position = new Vector2(chara.transform.position.x + 0.5f, chara.transform.position.y + 0.5f);
    //}

    

    

    /// <summary>
    /// 設定
    /// </summary>
    /// <param name="gameManager"></param>
    /// <returns></returns>
    public IEnumerator SetUpCharaGenerator(GameManager gameManager)//外部から持ってきたgamemanagerを
    {

        this.gameManager = gameManager;//このメソッドで宣言したgamemanagerに代入

        // TODO ステージのデータを取得


        // キャラのデータをリスト化
        CreateHaveCharaDatasList();

        // TODO リスト取得


        // キャラ配置用のポップアップの生成
        yield return StartCoroutine(CreatePlacementCharaSelectPopUp());
    }


    /// <summary>
    /// 配置キャラ選択用ポップアップ生成
    /// </summary>
    /// <returns></returns>
    private IEnumerator CreatePlacementCharaSelectPopUp()
    { 
        

        // ポップアップを生成
        placementCharaSelectPopUp = Instantiate(placementCharaSelectPopUpPrefab, canvasTran, false);

        // ポップアップの設定
        placementCharaSelectPopUp.SetUpPlacementCharaSelectPopUp(this, charaDatasList);

        // ポップアップを非表示にする
        placementCharaSelectPopUp.gameObject.SetActive(false);

        //GameStateをPlayにする
        gameManager.currentGameState = GameManager.GameState.Play;

        yield return null;
    }


    /// <summary>
    /// 配置キャラ選択用のポップアップの表示
    /// </summary>
    public void ActivatePlacementCharaSelectPopUp()
    {
        //GameStateをPauseにする
        gameManager.SetGameState(GameManager.GameState.Pause);

        // TODO すべての敵の移動を一時停止
        gameManager.PauseEnemies();

        // 配置キャラ選択用のポップアップの表示
        placementCharaSelectPopUp.gameObject.SetActive(true);
        placementCharaSelectPopUp.ShowPopUp();

        

    }

    /// <summary>
    /// 配置キャラ選択用のポップアップの非表示
    /// </summary>
    public void InactivatePlacementCharaSelectPopUp()
    {

        // 配置キャラ選択用のポップアップの非表示
        placementCharaSelectPopUp.gameObject.SetActive(false);


        // ゲームオーバーやゲームクリアではない場合
        if (gameManager.currentGameState != GameManager.GameState.GameUp)
        {
            // ゲームの進行状態をプレイ中に変更して、ゲーム再開
            gameManager.SetGameState (GameManager.GameState.Play);

            //Debug.Log("再開");
            // すべての敵の移動を再開
            gameManager.ResumeEnemies();

            

        }
    }

    /// <summary>
    /// キャラのデータをリスト化
    /// </summary>
    private void CreateHaveCharaDatasList()
    {

        // CharaDataSO スクリプタブル・オブジェクト内の CharaData を１つずつリストに追加
        // TODO スクリプタブル・オブジェクトではなく、実際にプレイヤーが所持しているキャラの番号を元にキャラのデータのリストを作成
        for (int i = 0; i < DataBaseManager.instance.charaDataSO.charaDatasList.Count; i++)
        {
            charaDatasList.Add(DataBaseManager.instance.charaDataSO.charaDatasList[i]);
        }
    }

    /// <summary>
    /// 選択したキャラを生成して配置
    /// </summary>
    /// <param name="charaData"></param>
    public void CreateChooseChara(CharaData charaData)
    {
        if (GameData.Instance.nowGold >= charaData.cost)
        {
            // コスト支払い
            PayCharaCost(charaData);

            // キャラをタップした位置に生成
            CharaController chara = Instantiate(charaControllerPrefab, gridPos, Quaternion.identity);

            // 位置が左下を 0,0 としているので、中央にくるように調整
            chara.transform.position = new Vector2(chara.transform.position.x + 0.5f, chara.transform.position.y + 0.5f);

            // TODO キャラの設定
            chara.SetUpChara(charaData, gameManager);    //  <=  ☆　CharaController 側に SetUpChara メソッドがまだないので、次の手順になってからコメントアウトを解除します。

            Debug.Log(charaData.charaName);   // 選択しているキャラのデータがとどいているかを確認するためのログ表示
        }
            


        // TODO キャラを List に追加

    }

    public void PayCharaCost(CharaData charaData)
    {
            GameData.Instance.nowGold = GameData.Instance.nowGold - charaData.cost; 
    }
}