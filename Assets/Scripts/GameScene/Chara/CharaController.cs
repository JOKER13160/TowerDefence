using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class CharaController : MonoBehaviour
{
    [SerializeField, Header("�U����")]
    private float attackPower = 1;

    [SerializeField, Header("�U������܂ł̑ҋ@����")]
    private float intervalAttackTime = 60.0f;

    [SerializeField]
    private bool isAttack;

    [SerializeField]
    private EnemyController enemy;

    [SerializeField]
    private int attackCount = 10;

    [SerializeField]
    private TextMeshProUGUI attackCountText;

    private void OnTriggerStay2D(Collider2D collision)
    {
        // �U�����ł͂Ȃ��ꍇ�ŁA���A�G�̏��𖢎擾�ł���ꍇ
        //!enemy=> enemy == null �̏��
        if (!isAttack && !enemy)
        {�@�@�@�@�@�@�@�@�@�@�@�@�@�@�@�@�@�@�@�@�@�@�@�@
            Debug.Log("�G����");

            // �G�̏��(EnemyController)���擾����BEnemyController ���A�^�b�`����Ă���Q�[���I�u�W�F�N�g�𔻕ʂ��Ă���̂ŁA�����ŁA���܂ł� Tag �ɂ�锻��Ɠ�������Ŕ��肪�s���܂��B
            // ���̂��߁A���@�̏������� Tag �̏������폜���Ă��܂�
            if (collision.gameObject.TryGetComponent(out enemy))
            {
                Debug.Log("enemy�擾");
                // �����擾�ł�����A�U����Ԃɂ���
                isAttack = true;

                // �U���̏����ɓ���
                StartCoroutine(PrepareteAttack());
            }
        }
    }

    /// <summary>
    /// �U������
    /// </summary>
    /// <returns></returns>
    public IEnumerator PrepareteAttack()
    {

        Debug.Log("�U�������J�n");

        int timer = 0;

        // �U�����̊Ԃ������[�v�������J��Ԃ�
        while (isAttack)
        {

            // TODO �Q�[���v���C���̂ݍU������

            timer++;

            // �U���̂��߂̑ҋ@���Ԃ��o�߂�����    
            if (timer > intervalAttackTime)
            {

                // ���̍U���ɔ����āA�ҋ@���Ԃ̃^�C�}�[�����Z�b�g
                timer = 0;

                // �U��
                Attack();

                // �U���񐔊֘A�̏����������ɋL�q����            
                attackCount--;
                UpdateDisplayAttackCount();

                // TODO �c��U���񐔂̕\���X�V


                // �U���񐔂��Ȃ��Ȃ�����
                if (attackCount <= 0)
                {

                    // �L�����j��
                    Destroy(gameObject);
                }


            }

            // �P�t���[�������𒆒f����(���̏����������Y���Ɩ������[�v�ɂȂ�AUnity �G�f�B�^�[�������Ȃ��Ȃ��čċN�����邱�ƂɂȂ�܂��B���ӁI)
            yield return null;
           //yield return new WaitForSeconds(intervalAttackTime);
        }
    }

    /// <summary>
    /// �U��
    /// </summary>
    private void Attack()
    {

        Debug.Log("�U��");

        // TODO �L�����̏�ɍU���G�t�F�N�g�𐶐�

        // TODO �G�L�������ɗp�ӂ����_���[�W�v�Z�p�̃��\�b�h���Ăяo���āA�G�Ƀ_���[�W��^����
        enemy.CulcDamage(attackPower);
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        //�ڐG���Ă���Q�[���I�u�W�F�N�g��EnemyController�R���|�[�l���g�̏�񂪁A
        //enemy�ϐ��Ɋi�[����Ă���ꍇ�A����
        if (collision.gameObject.TryGetComponent(out enemy))
        {
            Debug.Log("�G�Ȃ�");

            isAttack = false;
            enemy = null;
        }
    }

    /// <summary>
    /// �c��U���񐔂̕\���X�V
    /// </summary>
    private void UpdateDisplayAttackCount()
    {
        attackCountText.text = attackCount.ToString();
    }
}