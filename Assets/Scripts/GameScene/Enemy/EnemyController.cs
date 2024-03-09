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

    [SerializeField, Header("�ő�HP")]
    private float maxHp;

    [SerializeField]
    private float hp;

    [SerializeField,Header("�G�̍U����")]
    public float attackPower;


    private Tween tween;

    private Vector3[] paths;

    private Animator anim;�@�@�@�@�@�@ // Animator �R���|�[�l���g�̎擾�p

    //private Vector3 currentPos;    // �G�L�����̌��݂̈ʒu���
    /// <summary>
    /// �G�̐ݒ�
    /// </summary>

    public void SetUpEnemyController(Vector3[] pathsData)
    {
        hp = maxHp;

        // Animator �R���|�[�l���g���擾���� anim �ϐ��ɑ��
        //out a b => a�͎擾�������R���|�[�l���g�Ab�͎擾���������i�[����ϐ�
        //����͂��炩���� Animator anim �Ɛ錾���Ă��邽�߁A�R���|�[�l���g�̎w����ȗ��ł���
        TryGetComponent(out anim);

        // �ړ�����n�_���擾
        //pathData��pathTranArray�̊e�v�f����position�̒l�����o��
        //ToArray�Ŏ��o�����l��z��(paths[]�̏��)
        paths = pathsData;

        // �e�n�_�Ɍ����Ĉړ��B���ケ�̏����𐧌䂷�邽�߁ATween �^�̕ϐ��� DOPath ���\�b�h�̏����������Ă���
        //DOPath(x,y) => ��1����x��ړI�n�A��Q����y�͈ړ��ɂ����鎞��
        tween = transform.DOPath(paths, 1000 / moveSpeed).SetEase(Ease.Linear).OnWaypointChange(ChangeAnimeDirection);//  <=  DOPath �̏����� tween �ϐ��ɑ�����܂�

        // �ړ����ꎞ��~
        PauseMove();
    }

    /// <summary>
    /// �G�̐i�s�������擾���āA�ړ��A�j���Ɠ���
    /// </summary>
    private void ChangeAnimeDirection(int index)
    {
        Debug.Log("index : "+index);

        //���̈ړ���̒n�_���Ȃ��ꍇ�ɂ́A�����ŏ������I������
        if(index >= paths.Length)
        {
            return;
        }

        //�ڕW�̈ʒu�ƌ��݂̈ʒu�Ƃ̋����ƕ������擾���A���K���������s���A
        //�P�ʃx�N�g���Ƃ���(�����̏��͎����A�����ɂ�鑬�x�����Ȃ����Ĉ��l�ɂ���)
        Vector3 direction = (transform.position - paths[index]).normalized;
        Debug.Log("direction : "+direction);
        

        //�A�j���[�V������ Palameter �̒l���X�V���A
        //�ړ��A�j���� BlendTree �𐧌䂵�Ĉړ��̕����ƈړ��A�j���𓯊�
        anim.SetFloat("X",direction.x);
        anim.SetFloat("Y",direction.y);
    }

    /// <summary>
    /// �_���[�W�v�Z
    /// </summary>
    /// <param name="amount"></param>
    public void CulcDamage(float amount)
    {

        // Hp �̒l�����Z�������ʒl���A�Œ�l�ƍő�l�͈͓̔��Ɏ��܂�悤�ɂ��čX�V
        //Mathf.Clamp(x, y, z) => x�͐��䂵�����w��l�Ay�͎w�肷��͈͂̍ŏ��l�Az�͍ő�l
        hp = Mathf.Clamp(hp -= amount, 0, maxHp);
        //

        Debug.Log("�c��HP : " + hp);

        // Hp �� 0 �ȉ��ɂȂ����ꍇ
        if (hp <= 0)
        {

            // �j�󏈗������s���郁�\�b�h���Ăяo��
            DestroyEnemy();
        }

        // TODO ���o�p�̃G�t�F�N�g����


        // �q�b�g�X�g�b�v���o
        StartCoroutine(WaitMove());

    }

    /// <summary>
    /// �G�j�󏈗�
    /// </summary>
    public void DestroyEnemy()
    {

        // Kill ���\�b�h�����s���Atween �ϐ��ɑ������Ă��鏈��(DOPath �̏���)���I������
        tween.Kill();

        // TODO SE�̏���


        // TODO �j�󎞂̃G�t�F�N�g�̐�����֘A���鏈��


        // �G�L�����̔j��
        Destroy(gameObject);
    }

    /// <summary>
    /// �ړ����ꎞ��~
    /// </summary>
    public void PauseMove()
    {
        tween.Pause();
    }

    /// <summary>
    /// �ړ����J�n
    /// </summary>
    public void ResumeMove()
    {
        tween.Play();
    }

    /// <summary>
    /// �q�b�g�X�g�b�v���o
    /// </summary>
    /// <returns></returns>
    private IEnumerator WaitMove()
    {
        tween.timeScale = 0.05f;
        yield return new WaitForSeconds(0.5f);
        tween.timeScale = 1.0f;
    }
}