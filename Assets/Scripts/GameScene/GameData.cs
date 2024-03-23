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
            Destroy(gameObject); // 二重生成を防ぐ
    }

    [SerializeField]
    public int goldAddTime; //n時間ごとにゴールド増加
    [SerializeField]
    public int nowGold;     //現在の所持ゴールド
    [SerializeField]
    public int timeToGold;  //時間経過で増えるゴールド
    [SerializeField]
    public int maxGold;     //最大値

    //[SerializeField]
    //GameManager gameManager;

    //時間経過でゴールド増加メソッド
    //コルーチン
    //比較　timer >= goldAddTime
    //最大値ではないこと
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
            // 条件を確認してから、nowGold の加算処理を行う
            if (GameManager.Instance.timer >= goldAddTime && nowGold < maxGold)
            {
                nowGold = nowGold + timeToGold;
                Debug.Log("ゴールド追加");
                GameManager.Instance.timer = 0;
            }
            // ループを一時停止し、次のフレームまで制御を返す
            yield return null;

        }
    }


}
