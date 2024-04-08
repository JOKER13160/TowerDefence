using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SupportTowerController : MonoBehaviour
{
    private void OnMouseDown()
    {
        //これがクリックされたらswitch
        switch(gameObject.tag)
        {
            case "Gold":
                //Goldがクリックされた時の処理
                Debug.Log("ゴールドタワー");
                break;
        }
    }

}
