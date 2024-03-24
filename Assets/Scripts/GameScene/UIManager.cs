using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class UIManager : MonoBehaviour
{
    public static UIManager Instance;

    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(gameObject);
        }

        else
            Destroy(gameObject); // “ñd¶¬‚ğ–h‚®
    }

    //UI‚ğæ“¾‚µ‚Ä”CˆÓ‚Ì’l‚ğ‘ã“ü
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

    public void DisableButton(Button button)
    {
        button.interactable = false;
    }

    public void EnableButton(Button button)
    {
        button.interactable = true;
    }
}
