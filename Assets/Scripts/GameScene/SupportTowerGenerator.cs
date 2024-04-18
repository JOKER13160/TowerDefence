using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SupportTowerGenerator : MonoBehaviour
{
    public GameObject goldTowerPrefab; // ゴールドタワーのプレハブ
    [SerializeField]
    private GameObject PopUp;
    [SerializeField]
    private CanvasGroup canvasGroup;
    [SerializeField]
    private Button btnClosePopUp;
    [SerializeField]
    private Button btnChooseTower;

    

    private void Start()
    {
        // 各ボタンにメソッドを登録
        btnChooseTower.onClick.AddListener(GenerateGoldTower);
        btnClosePopUp.onClick.AddListener(()=>UIManager.Instance.OnClickClosePopUp(canvasGroup));

        UIManager.Instance.SwitchActivateButtons(false,btnChooseTower);
        UIManager.Instance.SwitchActivateButtons(false,btnClosePopUp);
    }
    private void OnMouseDown()
    {
        //これがクリックされたらswitch
        switch(gameObject.tag)
        {
            case "Gold":
                //Goldがクリックされた時の処理
                Debug.Log("ゴールドタワー");
                UIManager.Instance.ShowPopUp(canvasGroup);//ポップアップアクティブ

                UIManager.Instance.SwitchActivateButtons(true, btnChooseTower);
                UIManager.Instance.SwitchActivateButtons(true, btnClosePopUp);
                //GenerateGoldTower();
                break;
        }
    }

    // ゴールドタワーを生成するメソッド
    private void GenerateGoldTower()
    {
        // ゴールドタワーのプレハブを現在の位置に生成する
        Instantiate(goldTowerPrefab, transform.position, Quaternion.identity);
        UIManager.Instance.HidePopUp(canvasGroup);
        UIManager.Instance.SwitchActivateButtons(false, btnChooseTower);
        UIManager.Instance.SwitchActivateButtons(false, btnClosePopUp);
    }
}
