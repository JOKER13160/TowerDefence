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
        // ループが最初から開始されるようにする
        while (true)
        {
            if (GameManager.Instance.currentGameState != GameManager.GameState.Play)
            {
                yield return null;
                continue;
            }
            yield return new WaitForSeconds(towerData.Interval);
            // 条件を確認してから、nowGold の加算処理を行う

            GameData.Instance.nowGold += towerData.GetGold;
            Debug.Log("タワーによるゴールド追加");


            // ループを一時停止し、次のフレームまで制御を返す
            yield return null;

        }
    }
}
