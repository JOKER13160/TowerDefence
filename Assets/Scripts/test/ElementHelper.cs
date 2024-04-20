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
        //    case ElementType.�Ή�:
        //        switch (typeB)
        //        {
        //            case ElementType.��C:
        //                return ElementType.a;//�Ή��Ɨ�C�̕���
        //        }
        //        break;
        //    case ElementType.��C:
        //        switch (typeB)
        //        {
        //            case ElementType.�Ή�:
        //                return ElementType.a;//�Ή��Ɨ�C�̕���
        //        }
        //        break;
        //}
        return (typeA, typeB) switch
        {
            (ElementType.�Ή�,ElementType.��C) => ElementType.a,
            (ElementType.��C, ElementType.�Ή�) => ElementType.a,

            (ElementType.�Ή�, ElementType.�d�C) => ElementType.b,
            (ElementType.�d�C, ElementType.�Ή�) => ElementType.b,

            (ElementType.�Ή�, ElementType.��) => ElementType.c,
            (ElementType.��, ElementType.�Ή�) => ElementType.c,

            (ElementType.��C, ElementType.�d�C) => ElementType.d,
            (ElementType.�d�C, ElementType.��C) => ElementType.d,

            (ElementType.��C, ElementType.��) => ElementType.e,
            (ElementType.��, ElementType.��C) => ElementType.e,

            (ElementType.�d�C, ElementType.��) => ElementType.f,
            (ElementType.��, ElementType.�d�C) => ElementType.f,

            _ => ElementType.a,
        };

    } 
}
