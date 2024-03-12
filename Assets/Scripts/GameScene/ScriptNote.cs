using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScriptNote : MonoBehaviour
{
    //これはメモ書きです

    //スクリプトの書き方
    //1.最終的な処理からの逆算:

    //例:PlacementCharaSelectPopUp
    //・最終的にポップアップを非表示にする必要がある。
    //・各キャラのボタンを制御する必要がある。
    //上記を具体的にメソッドに落とし込む

    //2.それぞれの処理をメソッド化する:

    //HidePopUp() メソッド: ポップアップを非表示にする。
    //SwithcActivateButtons() メソッド: 各キャラのボタンを活性、非活性化する。

    //3.メソッドの呼び出し:

    //ポップアップを閉じるボタンが押されたとき(OnClickClosePopUp() メソッド内) に HidePopUp() を呼び出す。
    //キャラクターを選択して配置するボタンが押されたとき(OnClickSubmitChooseChara() メソッド内) にも HidePopUp() を呼び出す。
    //SetUpPlacementCharaSelectPopUp() メソッド内で SwithcActivateButtons() を呼び出す。

    //4.
}
