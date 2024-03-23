using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class UIManager : MonoBehaviour
{
    //UIを取得して任意の値を代入
    [SerializeField]
    private TextMeshProUGUI textGold;
    
    void Start()
    {
        StartCoroutine(UITextChanger(textGold.text));
    }

    //text nowgold
    private IEnumerator UITextChanger(string text)
    {
        while (true)
        {
            textGold.text = GameData.Instance.nowGold.ToString();
            yield return text;
        }
        
    }
}
