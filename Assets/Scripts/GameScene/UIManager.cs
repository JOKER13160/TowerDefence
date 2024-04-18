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
            Destroy(gameObject); // 二重生成を防ぐ
    }

    //UIを取得して任意の値を代入
    [SerializeField]
    private TextMeshProUGUI textGold;
    
    void Start()
    {
        StartCoroutine(UITextChanger(textGold));
    }

    //text nowgold
    private IEnumerator UITextChanger(TextMeshProUGUI text)
    {
        while (true)
        {
            text.text = GameData.Instance.nowGold.ToString();
            yield return null;
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

    // ポップアップの表示状態を切り替えるメソッド
    public void ToggleActivePopup(GameObject popup)
    {
        // ポップアップがアクティブなら非表示にし、非アクティブなら表示する
        if (popup.activeSelf)
        {
            NonActivePopUp(popup);
        }
        else
        {
            ActivePopUp(popup);
        }
    }

    // ポップアップをアクティブにするメソッド
    public void ActivePopUp(GameObject popup)
    {
        popup.SetActive(true);
    }

    
    public void NonActivePopUp(GameObject popup)
    {
        popup.SetActive(false);
    }

    // ポップアップを表示するメソッド
    public void ShowPopUp(CanvasGroup canvasGroup)
    {
        canvasGroup.alpha = 1;
    }
    
    public void HidePopUp(CanvasGroup canvasGroup)
    {
        canvasGroup.alpha = 0;
    }

    public void OnClickClosePopUp(CanvasGroup canvasGroup)
    {
        // ポップアップの非表示
        HidePopUp(canvasGroup);
        
    }

    public void SwitchActivateButtons(bool isSwitch,Button button)
    {
        button.interactable = isSwitch;
    }


}
