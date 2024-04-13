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
    public void TogglePopup(GameObject popup)
    {
        // �|�b�v�A�b�v���A�N�e�B�u�Ȃ��\���ɂ��A��A�N�e�B�u�Ȃ�\������
        if (popup.activeSelf)
        {
            HidePopup(popup);
        }
        else
        {
            ShowPopup(popup);
        }
    }

    // �|�b�v�A�b�v��\�����郁�\�b�h
    void ShowPopup(GameObject popup)
    {
        popup.SetActive(true);
    }

    // �|�b�v�A�b�v���\���ɂ��郁�\�b�h
    void HidePopup(GameObject popup)
    {
        popup.SetActive(false);
    }
}
