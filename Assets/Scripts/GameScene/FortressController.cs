using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FortressController : MonoBehaviour
{
    [SerializeField]
    private float fortMaxHp;
    [SerializeField]
    private float fortHp;
    [SerializeField]
    private EnemyController enemy;

    void Start()
    {
        fortHp = fortMaxHp;
    }

    //“G‚ªÚG‚µ‚½‚çHP‚ğŒ¸‚ç‚·
    private void OnTriggerEnter2D(Collider2D collision)
    {
        Debug.Log("Ú“G");
        if(collision.gameObject.TryGetComponent(out enemy))
        {
            FortressDamage(enemy.attackPower);
        }
        enemy.DestroyEnemy();
    }

    private void FortressDamage(float amount)
    {
        fortHp = Mathf.Clamp(fortHp - amount, 0, fortMaxHp);
        Debug.Log("c‚èHP : " + fortHp);
    }
}
