using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.UI;


public class EnemyGeneratePointController : MonoBehaviour
{
    [SerializeField]
    public float enemyGeneratePointHP;
    [SerializeField]
    public float enemyGeneratePointMaxHP;
    [SerializeField]
    private Slider slider;
    [SerializeField]
    public Transform destroyedPosition;
    [SerializeField]
    EnemyGenerator enemyGenerator;

    public bool canGenerate = true;

    private void Start()
    {
        enemyGeneratePointHP = enemyGeneratePointMaxHP;
        slider.value = enemyGeneratePointHP;
    }
    public void HPDamage(ref float hp, float maxHp, float damage)
    {
        Debug.Log(damage);
        hp = Mathf.Clamp(hp -= damage, 0, maxHp);
        Debug.Log("Žc‚èHP : " + hp);
        slider.value = hp;
        if (hp <= 0)
        {
            enemyGenerator.enemyGeneratePositions = destroyedPosition;
            Destroy(gameObject);
            Debug.Log("¶¬’n“_”j‰ó");
            DestroyedPosition();
        }
    }

    private void DestroyedPosition()
    {
        Debug.Log(destroyedPosition.position);
    }

    private void OnDestroy()
    {
        canGenerate = false;
    }
}
