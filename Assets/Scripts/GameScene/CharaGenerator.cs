using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;

public class CharaGenerator : MonoBehaviour
{
    [SerializeField]
    private GameObject charaPrefab;

    [SerializeField]
    private Grid grid;         // Base ���� Grid ���w�肷�� 


    ////*  �V�����ϐ��̐錾���P�ǉ�  *////


    [SerializeField]
    private Tilemap tilemaps;   // Walk ���� Tilemap ���w�肷��


    ////*  �����܂�  *////

    private Vector3Int gridPos;


    void Update()
    {
        // TODO �z�u�ł���ő�L�������ɒB���Ă���ꍇ�ɂ͔z�u�ł��Ȃ�

        // ��ʂ��^�b�v(�}�E�X�N���b�N)������
        if (Input.GetMouseButtonDown(0))
        {

            // �^�b�v(�}�E�X�N���b�N)�̈ʒu���擾���ă��[���h���W�ɕϊ����A���������Ƀ^�C���̃Z�����W�ɕϊ�
            gridPos = grid.WorldToCell(Camera.main.ScreenToWorldPoint(Input.mousePosition));


            ////*  �V����������ǉ�  *////


            // �^�b�v�����ʒu�̃^�C���̃R���C�_�[�̏����m�F���A���ꂪ None �ł���Ȃ�
            if (tilemaps.GetColliderType(gridPos) == Tile.ColliderType.None)
            {

                // �L�����������������\�b�h��
                CreateChara(gridPos);

                // TODO �z�u�L�����I��p�|�b�v�A�b�v�̕\��

            }


            ////*  �����܂�  *////


        }
    }


    ////*  ���\�b�h���P�ǉ�  *////


    /// <summary>
    /// �L��������
    /// </summary>
    /// <param name="gridPos"></param>
    private void CreateChara(Vector3Int gridPos)
    {

        // �^�b�v�����ʒu�ɃL�����𐶐����Ĕz�u
        GameObject chara = Instantiate(charaPrefab, gridPos, Quaternion.identity);

        // �L�����̈ʒu���^�C���̍����� 0,0 �Ƃ��Đ������Ă���̂ŁA�^�C���̒����ɂ���悤�Ɉʒu�𒲐�
        chara.transform.position = new Vector2(chara.transform.position.x + 0.5f, chara.transform.position.y + 0.5f);
    }


    ////*  �����܂�  *////


}