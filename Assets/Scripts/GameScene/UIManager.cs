using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class UIManager : MonoBehaviour
{
    //UI���擾���ĔC�ӂ̒l����
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
