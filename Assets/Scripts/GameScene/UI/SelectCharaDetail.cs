using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using DG.Tweening;

public class SelectCharaDetail : MonoBehaviour
{
    [SerializeField]
    private Button btnSelectCharaDetail;

    [SerializeField]
    private Image imgChara;

    private PlacementCharaSelectPopUp placementCharaSelectPop;

    private CharaData charaData;

    private void Start()
    {
        StartCoroutine(ToggleButtonToCost(this.charaData.cost, this.btnSelectCharaDetail));
    }

    /// <summary>
    /// SelectCharaDetail の設定
    /// </summary>
    /// <param name="placementCharaSelectPop"></param>
    /// <param name="charaData"></param>
    public void SetUpSelectCharaDetail(PlacementCharaSelectPopUp placementCharaSelectPop, CharaData charaData)
    {

        this.placementCharaSelectPop = placementCharaSelectPop;
        this.charaData = charaData;


        // ボタンを押せない状態に切り替える
        //UIManager.Instance.DisableButton(btnSelectCharaDetail);

        imgChara.sprite = this.charaData.charaSprite;


        // ボタンにメソッドを登録
        btnSelectCharaDetail.onClick.AddListener(OnClickSelectCharaDetail);

        // TODO コストに応じてボタンを押せるかどうかを切り替える
        //StartCoroutine(ToggleButtonToCost(charaData.cost, btnSelectCharaDetail));
        
        
    }

    /// <summary>
    /// SelectCharaDetail を押したの処理
    /// </summary>
    private void OnClickSelectCharaDetail()
    {

        // TODO アニメ演出

        // タップした SelectCharaDetail の情報をポップアップに送る
        
        placementCharaSelectPop.SetSelectCharaDetail(charaData);


    }

    private IEnumerator ToggleButtonToCost(int charaCost,Button button)
    {
        //キャラのコストが所持ゴールド以下ならボタン押せる
        while (true)
        {
            if(charaCost <= GameData.Instance.nowGold)
            {
                UIManager.Instance.EnableButton(button);
            }
            else
            {
                UIManager.Instance.DisableButton(button);
            }
            yield return null;
        }
          
    }
}