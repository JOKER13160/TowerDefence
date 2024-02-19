using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;
using System.Linq;


public class EnemyController : MonoBehaviour
{
    [SerializeField, Header("�ړ��o�H�̏��")]
    private PathData pathData;

    [SerializeField, Header("�ړ����x")]
    private float moveSpeed;

    private Vector3[] paths;

    private Animator anim;�@�@�@�@�@�@ // Animator �R���|�[�l���g�̎擾�p

    //private Vector3 currentPos;    // �G�L�����̌��݂̈ʒu���

    void Start()
    {
        // Animator �R���|�[�l���g���擾���� anim �ϐ��ɑ��
        //out a b => a�͎擾�������R���|�[�l���g�Ab�͎擾���������i�[����ϐ�
        //����͂��炩���� Animator anim �Ɛ錾���Ă��邽�߁A�R���|�[�l���g�̎w����ȗ��ł���
        TryGetComponent(out anim);

        // �ړ�����n�_���擾
        //pathData��pathTranArray�̊e�v�f����position�̒l�����o��
        //ToArray�Ŏ��o�����l��z��(paths[]�̏��)
        paths = pathData.pathTranArray.Select(x => x.position).ToArray();

        // �e�n�_�Ɍ����Ĉړ�
        //DOPath(x,y) => ��1����x��ړI�n�A��Q����y�͈ړ��ɂ����鎞��
        transform.DOPath(paths, 1000 / moveSpeed).SetEase(Ease.Linear).OnWaypointChange(ChangeAnimeDirection);
    }

    //void Update()
    //{
        // �G�̐i�s�������擾
        //ChangeAnimeDirection();
    //}


    /// <summary>
    /// �G�̐i�s�������擾���āA�ړ��A�j���Ɠ���
    /// </summary>
    private void ChangeAnimeDirection(int index)
    {
        Debug.Log(index);

        //���̈ړ���̒n�_���Ȃ��ꍇ�ɂ́A�����ŏ������I������
        if(index >= paths.Length)
        {
            return;
        }

        //�ڕW�̈ʒu�ƌ��݂̈ʒu�Ƃ̋����ƕ������擾���A���K���������s���A
        //�P�ʃx�N�g���Ƃ���(�����̏��͎����A�����ɂ�鑬�x�����Ȃ����Ĉ��l�ɂ���)
        Vector3 direction = (transform.position - paths[index]).normalized;
        Debug.Log(direction);

        //�A�j���[�V������ Palameter �̒l���X�V���A
        //�ړ��A�j���� BlendTree �𐧌䂵�Ĉړ��̕����ƈړ��A�j���𓯊�
        anim.SetFloat("X",direction.x);
        anim.SetFloat("Y",direction.y);
    }
}