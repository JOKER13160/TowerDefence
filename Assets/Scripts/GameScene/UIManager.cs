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
            Destroy(gameObject); // ��d������h��
    }

    //UI���擾���ĔC�ӂ̒l����
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

    // �|�b�v�A�b�v�̕\����Ԃ�؂�ւ��郁�\�b�h
    public void ToggleActivePopup(GameObject popup)
    {
        // �|�b�v�A�b�v���A�N�e�B�u�Ȃ��\���ɂ��A��A�N�e�B�u�Ȃ�\������
        if (popup.activeSelf)
        {
            NonActivePopUp(popup);
        }
        else
        {
            ActivePopUp(popup);
        }
    }

    // �|�b�v�A�b�v���A�N�e�B�u�ɂ��郁�\�b�h
    public void ActivePopUp(GameObject popup)
    {
        popup.SetActive(true);
    }

    
    public void NonActivePopUp(GameObject popup)
    {
        popup.SetActive(false);
    }

    // �|�b�v�A�b�v��\�����郁�\�b�h
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
        // �|�b�v�A�b�v�̔�\��
        HidePopUp(canvasGroup);
        
    }

    public void SwitchActivateButtons(bool isSwitch,Button button)
    {
        button.interactable = isSwitch;
    }


}
