using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    [SerializeField]
    private EnemyGenerator enemyGenerator;

    public bool isEnemyGenerate;

    public int generateIntervalTime;

    public int generateEnemyCount;

    public int maxEnemyCount;


    void Start()
    {

        // ¶¬‚Ì‹–‰Â‚ğ‚·‚é
        isEnemyGenerate = true;

        // “G‚Ì¶¬€”õ
        StartCoroutine(enemyGenerator.PreparateEnemyGenerate(this));
    }


    /// <summary>
    /// “G‚Ìî•ñ‚ğ List ‚É’Ç‰Á
    /// </summary>
    public void AddEnemyList()
    {    //@TODO@“G‚Ìî•ñ‚ğ List ‚É’Ç‰Á‚·‚éÛ‚ÉAˆø”‚ğ’Ç‰Á

        //@TODO@“G‚Ìî•ñ‚ğ List ‚É’Ç‰Á

        // “G‚Ì¶¬”‚ğƒJƒEƒ“ƒgƒAƒbƒv
        generateEnemyCount++;
    }

    /// <summary>
    /// “G‚Ì¶¬‚ğ’â~‚·‚é‚©”»’è
    /// </summary>
    public void JudgeGenerateEnemysEnd()
    {
        if (generateEnemyCount >= maxEnemyCount)
        {
            isEnemyGenerate = false;
        }
    }
}
