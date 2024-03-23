using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class CharaController : MonoBehaviour
{
    [SerializeField, Header("攻撃力")]
    private float attackPower = 1;

    [SerializeField, Header("攻撃するまでの待機時間")]
    private float intervalAttackTime = 60.0f;

    [SerializeField]
    private bool isAttack;

    [SerializeField]
    private EnemyController enemy;

    [SerializeField]
    private int attackCount = 10;// TODO 現在の攻撃回数の残り。あとで CharaData クラスの値を反映させる

    [SerializeField]
    private BoxCollider2D attackRangeArea;

    [SerializeField]
    private CharaData charaData;

    private GameManager gameManager;

    private string overrideClipName = "Chara_0";

    private AnimatorOverrideController overrideController;

    [SerializeField]
    private TextMeshProUGUI attackCountText;

    //private SpriteRenderer spriteRenderer;

    private Animator anim;



    private void OnTriggerStay2D(Collider2D collision)
    {
        // 攻撃中ではない場合で、かつ、敵の情報を未取得である場合
        //!enemy=> enemy == null の状態
        if (!isAttack && !enemy)
        {　　　　　　　　　　　　　　　　　　　　　　　　
            Debug.Log("敵発見");

            // 敵の情報(EnemyController)を取得する。EnemyController がアタッチされているゲームオブジェクトを判別しているので、ここで、今までの Tag による判定と同じ動作で判定が行えます。
            // そのため、☆①の処理から Tag の処理を削除しています
            if (collision.gameObject.TryGetComponent(out enemy))
            {
                Debug.Log("enemy取得");
                // 情報を取得できたら、攻撃状態にする
                isAttack = true;

                // 攻撃の準備に入る
                StartCoroutine(PrepareteAttack());
            }
        }
    }

    /// <summary>
    /// 攻撃準備
    /// </summary>
    /// <returns></returns>
    public IEnumerator PrepareteAttack()
    {

        Debug.Log("攻撃準備開始");

        int timer = 0;

        // 攻撃中の間だけループ処理を繰り返す
        while (isAttack)
        {
            yield return null;
            if(GameManager.Instance.currentGameState != GameManager.GameState.Play)
            {
                continue;
            }

            // TODO ゲームプレイ中のみ攻撃する

            timer++;

            // 攻撃のための待機時間が経過したら    
            if (timer > intervalAttackTime)
            {

                // 次の攻撃に備えて、待機時間のタイマーをリセット
                timer = 0;

                // 攻撃
                Attack();

                // 攻撃回数関連の処理をここに記述する            
                attackCount--;

                // 残り攻撃回数の表示更新
                UpdateDisplayAttackCount();

                // 攻撃回数がなくなったら
                if (attackCount <= 0)
                {

                    // キャラ破壊
                    Destroy(gameObject);
                }


            }

            // １フレーム処理を中断する(この処理を書き忘れると無限ループになり、Unity エディターが動かなくなって再起動することになります。注意！)
            //yield return null;
           //yield return new WaitForSeconds(intervalAttackTime);
        }
    }

    /// <summary>
    /// 攻撃
    /// </summary>
    private void Attack()
    {

        Debug.Log("攻撃");

        // TODO キャラの上に攻撃エフェクトを生成

        // TODO 敵キャラ側に用意したダメージ計算用のメソッドを呼び出して、敵にダメージを与える
        Debug.Log(enemy);

        if (enemy != null)
        {
            enemy.CulcDamage(attackPower);
        }

    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        //接触しているゲームオブジェクトのEnemyControllerコンポーネントの情報が、
        //enemy変数に格納されている場合、動作
        if (collision.gameObject.TryGetComponent(out enemy))
        {
            Debug.Log("敵なし");

            isAttack = false;
            enemy = null;
        }
    }

    /// <summary>
    /// 残り攻撃回数の表示更新
    /// </summary>
    private void UpdateDisplayAttackCount()
    {
        attackCountText.text = attackCount.ToString();
    }

    /// <summary>
    /// キャラの設定
    /// </summary>
    /// <param name="charaData"></param>
    /// <param name="gameManager"></param>
    public void SetUpChara(CharaData charaData, GameManager gameManager)
    {

        this.charaData = charaData;
        this.gameManager = gameManager;

        // 各値を CharaData から取得して設定
        attackPower = this.charaData.attackPower;

        intervalAttackTime = this.charaData.intervalAttackTime;

        // DataBaseManager に登録されている AttackRangeSizeSO スクリプタブル・オブジェクトのデータと照合を行い、CharaData の AttackRangeType の情報を元に Size を設定
        attackRangeArea.size = DataBaseManager.instance.attackRangeSizeSO.GetAttackRangeSize(this.charaData.attackRange);

        attackCount = this.charaData.maxAttackCount;

        // 残りの攻撃回数の表示更新
        UpdateDisplayAttackCount();

        // キャラ画像の設定。アニメを利用するようになったら、この処理はやらない
        //if (TryGetComponent(out spriteRenderer)) {//　　<=　☆　アニメを登録するので、この一連の画像の差し替え処理の方は行わないように処理をコメントアウトします。

        // 画像を配置したキャラの画像に差し替える
        //spriteRenderer.sprite = this.charaData.charaSprite;
        //}　　　　　　

        // キャラごとの AnimationClip を設定
        SetUpAnimation();

    }

    /// <summary>
    /// Motion に登録されている AnimationClip を変更
    /// </summary>
    private void SetUpAnimation()
    {
        if (TryGetComponent(out anim))
        {

            overrideController = new AnimatorOverrideController();

            overrideController.runtimeAnimatorController = anim.runtimeAnimatorController;
            anim.runtimeAnimatorController = overrideController;

            AnimatorStateInfo[] layerInfo = new AnimatorStateInfo[anim.layerCount];

            for (int i = 0; i < anim.layerCount; i++)
            {
                layerInfo[i] = anim.GetCurrentAnimatorStateInfo(i);
            }

            overrideController[overrideClipName] = this.charaData.charaAnim;

            anim.runtimeAnimatorController = overrideController;

            anim.Update(0.0f);

            for (int i = 0; i < anim.layerCount; i++)
            {
                anim.Play(layerInfo[i].fullPathHash, i, layerInfo[i].normalizedTime);
            }
        }
    }
}