using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CoroutineTest : MonoBehaviour
{
    private int counter;
    [SerializeField]
    private int maxCount;
    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(ButtonCoroutine());
        StartCoroutine(CountUpCoroutine());
    }

   private IEnumerator ButtonCoroutine()
    {
        //ボタンを押すまで処理を待機させる
        yield return new WaitUntil(() => Input.GetKeyDown(KeyCode.A));
        //
        Debug.Log("ボタン押した");
    }

    private IEnumerator CountUpCoroutine()
    {
        //ボタンを押した数が一定数になるまで待機
        yield return new WaitUntil(() => counter >= maxCount);

        Debug.Log("一定数になりました");
    }
    private void Update()
    {
        if(Input.GetKeyDown(KeyCode.Z)) {
            counter++;
        }
    }
}
