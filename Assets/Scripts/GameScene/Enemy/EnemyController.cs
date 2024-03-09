using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;
using System.Linq;


public class EnemyController : MonoBehaviour
{
    [SerializeField, Header("移動経路の情報")]
    private PathData pathData;

    [SerializeField, Header("移動速度")]
    private float moveSpeed;

    [SerializeField, Header("最大HP")]
    private float maxHp;

    [SerializeField]
    private float hp;

    [SerializeField,Header("敵の攻撃力")]
    public float attackPower;


    private Tween tween;

    private Vector3[] paths;

    private Animator anim;　　　　　　 // Animator コンポーネントの取得用

    //private Vector3 currentPos;    // 敵キャラの現在の位置情報
    /// <summary>
    /// 敵の設定
    /// </summary>

    public void SetUpEnemyController(Vector3[] pathsData)
    {
        hp = maxHp;

        // Animator コンポーネントを取得して anim 変数に代入
        //out a b => aは取得したいコンポーネント、bは取得した情報を格納する変数
        //今回はあらかじめ Animator anim と宣言しているため、コンポーネントの指定を省略できる
        TryGetComponent(out anim);

        // 移動する地点を取得
        //pathDataのpathTranArrayの各要素からpositionの値を取り出す
        //ToArrayで取り出した値を配列化(paths[]の状態)
        paths = pathsData;

        // 各地点に向けて移動。今後この処理を制御するため、Tween 型の変数に DOPath メソッドの処理を代入しておく
        //DOPath(x,y) => 第1引数xを目的地、第２引数yは移動にかかる時間
        tween = transform.DOPath(paths, 1000 / moveSpeed).SetEase(Ease.Linear).OnWaypointChange(ChangeAnimeDirection);//  <=  DOPath の処理を tween 変数に代入します

        // 移動を一時停止
        PauseMove();
    }

    /// <summary>
    /// 敵の進行方向を取得して、移動アニメと同期
    /// </summary>
    private void ChangeAnimeDirection(int index)
    {
        Debug.Log("index : "+index);

        //次の移動先の地点がない場合には、ここで処理を終了する
        if(index >= paths.Length)
        {
            return;
        }

        //目標の位置と現在の位置との距離と方向を取得し、正規化処理を行い、
        //単位ベクトルとする(方向の情報は持ちつつ、距離による速度差をなくして一定値にする)
        Vector3 direction = (transform.position - paths[index]).normalized;
        Debug.Log("direction : "+direction);
        

        //アニメーションの Palameter の値を更新し、
        //移動アニメの BlendTree を制御して移動の方向と移動アニメを同期
        anim.SetFloat("X",direction.x);
        anim.SetFloat("Y",direction.y);
    }

    /// <summary>
    /// ダメージ計算
    /// </summary>
    /// <param name="amount"></param>
    public void CulcDamage(float amount)
    {

        // Hp の値を減算した結果値を、最低値と最大値の範囲内に収まるようにして更新
        //Mathf.Clamp(x, y, z) => xは制御したい指定値、yは指定する範囲の最小値、zは最大値
        hp = Mathf.Clamp(hp -= amount, 0, maxHp);
        //

        Debug.Log("残りHP : " + hp);

        // Hp が 0 以下になった場合
        if (hp <= 0)
        {

            // 破壊処理を実行するメソッドを呼び出す
            DestroyEnemy();
        }

        // TODO 演出用のエフェクト生成


        // ヒットストップ演出
        StartCoroutine(WaitMove());

    }

    /// <summary>
    /// 敵破壊処理
    /// </summary>
    public void DestroyEnemy()
    {

        // Kill メソッドを実行し、tween 変数に代入されている処理(DOPath の処理)を終了する
        tween.Kill();

        // TODO SEの処理


        // TODO 破壊時のエフェクトの生成や関連する処理


        // 敵キャラの破壊
        Destroy(gameObject);
    }

    /// <summary>
    /// 移動を一時停止
    /// </summary>
    public void PauseMove()
    {
        tween.Pause();
    }

    /// <summary>
    /// 移動を開始
    /// </summary>
    public void ResumeMove()
    {
        tween.Play();
    }

    /// <summary>
    /// ヒットストップ演出
    /// </summary>
    /// <returns></returns>
    private IEnumerator WaitMove()
    {
        tween.timeScale = 0.05f;
        yield return new WaitForSeconds(0.5f);
        tween.timeScale = 1.0f;
    }
}