using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class FortressController : MonoBehaviour
{
    [SerializeField]
    private float fortMaxHp;
    [SerializeField]
    private float fortHp;
    [SerializeField]
    private EnemyController enemy;
    [SerializeField]
    private Slider slider;

    void Start()
    {
        fortHp = fortMaxHp;
        slider.value = fortHp;
    }

    //ìGÇ™ê⁄êGÇµÇΩÇÁHPÇå∏ÇÁÇ∑
    private void OnTriggerEnter2D(Collider2D collision)
    {
        Debug.Log("ê⁄ìG");
        if (collision.gameObject.TryGetComponent(out enemy))
        {
            FortressDamage(enemy.attackPower);
            enemy.DestroyEnemy();
        }
        
        
    }

    private void FortressDamage(float amount)
    {
        fortHp = Mathf.Clamp(fortHp -= amount, 0, fortMaxHp);
        Debug.Log("écÇËHP : " + fortHp);
        slider.value = fortHp;
    }

    
}
