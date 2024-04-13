using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;

/// <summary>
/// スプレッドシートから取得したデータをシート単位で任意のスクリプタブル・オブジェクトに値として取り込む
/// </summary>
[RequireComponent(typeof(GSSReader))]
public class GSSReceiver : MonoBehaviour
{
    public bool IsLoading { get; set; }　　//　プロパティのままですとインスペクターから確認できないため、一時的に変数にしてもいいでしょう


    private void Awake()
    {

        // GSS のデータ取得準備
        StartCoroutine(PrepareGSSLoadStart());
    }

    /// <summary>
    /// GSS のデータ取得準備
    /// </summary>
    /// <returns></returns>
    private IEnumerator PrepareGSSLoadStart()
    {

        IsLoading = true;

        // GSS を取得して SO に取得する。その処理が終わるまでここで待機する
        yield return StartCoroutine(GetComponent<GSSReader>().GetFromWeb());

        IsLoading = false;

        Debug.Log("GSS データを SO に取得");
    }

    /// <summary>
    /// インスペクターから GSSReader の OnLoadEnd にこのメソッドを追加することで GSS の読み込み完了時にコールバックされる
    /// </summary>
    public void OnGSSLoadEnd()
    {

        GSSReader reader = GetComponent<GSSReader>();

        // スプレッドシートから取得した各シートの配列を List に変換
        List<SheetData> sheetDataslist = reader.sheetDatas.ToList();

        // 情報が取得できた場合
        if (sheetDataslist != null)
        {

            // スクリプタブル・オブジェクトに代入(例１)
            DataBaseManager.instance.skillDataSO.skillDatasList =
                new List<SkillData>(sheetDataslist.Find(x => x.SheetName == SheetName.SkillData).DatasList.Select(x => new SkillData(x)).ToList());

            // TODO 他の SO を追加する
            DataBaseManager.instance.towerDataSO.towerDatasList =
                new List<TowerData>(sheetDataslist.Find(x => x.SheetName == SheetName.TowerData).DatasList.Select(x => new TowerData(x)).ToList());

            DataBaseManager.instance.disasterDataSO.disasterDatasList =
                new List<DisasterData>(sheetDataslist.Find(x => x.SheetName == SheetName.DisasterData).DatasList.Select(x => new DisasterData(x)).ToList());

        }
    }
}