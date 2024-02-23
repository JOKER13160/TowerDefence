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
        //�{�^���������܂ŏ�����ҋ@������
        yield return new WaitUntil(() => Input.GetKeyDown(KeyCode.A));
        //
        Debug.Log("�{�^��������");
    }

    private IEnumerator CountUpCoroutine()
    {
        //�{�^����������������萔�ɂȂ�܂őҋ@
        yield return new WaitUntil(() => counter >= maxCount);

        Debug.Log("��萔�ɂȂ�܂���");
    }
    private void Update()
    {
        if(Input.GetKeyDown(KeyCode.Z)) {
            counter++;
        }
    }
}
