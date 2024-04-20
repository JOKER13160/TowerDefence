using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ElementHelper : MonoBehaviour
{
    public static ElementHelper instance;
    public ElementType ElementTypeA;
    public ElementType ElementTypeB;
    // Start is called before the first frame update
    void Awake()
    {
        if (instance == null)
        {
            instance = this;
            DontDestroyOnLoad(gameObject);
        }

        else
        {
            Destroy(gameObject);
        }
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.O)) {
            ElementType resultType = CulcElementType(ElementTypeA, ElementTypeB);
            Debug.Log(resultType.ToString());
        }
    }

    public ElementType CulcElementType(ElementType typeA, ElementType typeB)
    {
        //switch (typeA)
        //{
        //    case ElementType.火炎:
        //        switch (typeB)
        //        {
        //            case ElementType.冷気:
        //                return ElementType.a;//火炎と冷気の複合
        //        }
        //        break;
        //    case ElementType.冷気:
        //        switch (typeB)
        //        {
        //            case ElementType.火炎:
        //                return ElementType.a;//火炎と冷気の複合
        //        }
        //        break;
        //}
        return (typeA, typeB) switch
        {
            (ElementType.火炎,ElementType.冷気) => ElementType.a,
            (ElementType.冷気, ElementType.火炎) => ElementType.a,

            (ElementType.火炎, ElementType.電気) => ElementType.b,
            (ElementType.電気, ElementType.火炎) => ElementType.b,

            (ElementType.火炎, ElementType.毒) => ElementType.c,
            (ElementType.毒, ElementType.火炎) => ElementType.c,

            (ElementType.冷気, ElementType.電気) => ElementType.d,
            (ElementType.電気, ElementType.冷気) => ElementType.d,

            (ElementType.冷気, ElementType.毒) => ElementType.e,
            (ElementType.毒, ElementType.冷気) => ElementType.e,

            (ElementType.電気, ElementType.毒) => ElementType.f,
            (ElementType.毒, ElementType.電気) => ElementType.f,

            _ => ElementType.a,
        };

    } 
}
