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
    private int attackCount = 10;// TODO ���݂̍U���񐔂̎c��B���Ƃ� CharaData �N���X�̒l�𔽉f������

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
            yield return null;
            if(GameManager.Instance.currentGameState != GameManager.GameState.Play)
            {
                continue;
            }

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

                // �c��U���񐔂̕\���X�V
                UpdateDisplayAttackCount();

                // �U���񐔂��Ȃ��Ȃ�����
                if (attackCount <= 0)
                {

                    // �L�����j��
                    Destroy(gameObject);
                }


            }

            // �P�t���[�������𒆒f����(���̏����������Y���Ɩ������[�v�ɂȂ�AUnity �G�f�B�^�[�������Ȃ��Ȃ��čċN�����邱�ƂɂȂ�܂��B���ӁI)
            //yield return null;
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
        Debug.Log(enemy);

        if (enemy != null)
        {
            enemy.CulcDamage(attackPower);
        }

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

    /// <summary>
    /// �L�����̐ݒ�
    /// </summary>
    /// <param name="charaData"></param>
    /// <param name="gameManager"></param>
    public void SetUpChara(CharaData charaData, GameManager gameManager)
    {

        this.charaData = charaData;
        this.gameManager = gameManager;

        // �e�l�� CharaData ����擾���Đݒ�
        attackPower = this.charaData.attackPower;

        intervalAttackTime = this.charaData.intervalAttackTime;

        // DataBaseManager �ɓo�^����Ă��� AttackRangeSizeSO �X�N���v�^�u���E�I�u�W�F�N�g�̃f�[�^�Əƍ����s���ACharaData �� AttackRangeType �̏������� Size ��ݒ�
        attackRangeArea.size = DataBaseManager.instance.attackRangeSizeSO.GetAttackRangeSize(this.charaData.attackRange);

        attackCount = this.charaData.maxAttackCount;

        // �c��̍U���񐔂̕\���X�V
        UpdateDisplayAttackCount();

        // �L�����摜�̐ݒ�B�A�j���𗘗p����悤�ɂȂ�����A���̏����͂��Ȃ�
        //if (TryGetComponent(out spriteRenderer)) {//�@�@<=�@���@�A�j����o�^����̂ŁA���̈�A�̉摜�̍����ւ������̕��͍s��Ȃ��悤�ɏ������R�����g�A�E�g���܂��B

        // �摜��z�u�����L�����̉摜�ɍ����ւ���
        //spriteRenderer.sprite = this.charaData.charaSprite;
        //}�@�@�@�@�@�@

        // �L�������Ƃ� AnimationClip ��ݒ�
        SetUpAnimation();

    }

    /// <summary>
    /// Motion �ɓo�^����Ă��� AnimationClip ��ύX
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