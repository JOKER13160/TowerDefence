using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SupportTowerGenerator : MonoBehaviour
{
    public GameObject goldTowerPrefab; // ゴールドタワーのプレハブ
    [SerializeField]
    private GameObject PopUp;
    private void OnMouseDown()
    {
        //これがクリックされたらswitch
        switch(gameObject.tag)
        {
            case "Gold":
                //Goldがクリックされた時の処理
                Debug.Log("ゴールドタワー");
                UIManager.Instance.TogglePopup(PopUp);
                GenerateGoldTower();
                break;
        }
    }

    // ゴールドタワーを生成するメソッド
    private void GenerateGoldTower()
    {
        // ゴールドタワーのプレハブを現在の位置に生成する
        Instantiate(goldTowerPrefab, transform.position, Quaternion.identity);
    }
}
