using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;

public class CharaGenerator : MonoBehaviour
{
    //[SerializeField]
    //private GameObject charaPrefab;

    [SerializeField]
    private CharaController charaControllerPrefab;

    [SerializeField]
    private CharaData charaData;

    [SerializeField]
    private Grid grid;         // Base ���� Grid ���w�肷�� 

    [SerializeField]
    private Tilemap tilemaps;   // Walk ���� Tilemap ���w�肷��

    [SerializeField]
    private PlacementCharaSelectPopUp placementCharaSelectPopUpPrefab;�@�@�@//�@PlacementCharaSelectPopUp �v���t�@�u�Q�[���I�u�W�F�N�g���A�T�C���p

    [SerializeField]
    private Transform canvasTran;                                           //�@PlacementCharaSelectPopUp �Q�[���I�u�W�F�N�g�̐����ʒu�̓o�^�p

    [SerializeField, Header("�L�����̃f�[�^���X�g")]
    public List<CharaData> charaDatasList = new List<CharaData>();

    private PlacementCharaSelectPopUp placementCharaSelectPopUp;�@�@�@�@�@�@//�@�������ꂽ PlacementCharaSelectPopUp �Q�[���I�u�W�F�N�g�������邽�߂̕ϐ�

    private GameManager gameManager;

    private Vector3Int gridPos;


    void Update()
    {
        // TODO �z�u�ł���ő�L�������ɒB���Ă���ꍇ�ɂ͔z�u�ł��Ȃ�

        // ��ʂ��^�b�v(�}�E�X�N���b�N)���A���A�z�u�L�����|�b�v�A�b�v����\����ԁA���A
        // �Q�[���̌��݂̐i�s��Ԃ� Play �Ȃ�
        if (Input.GetMouseButtonDown(0) && !placementCharaSelectPopUp.gameObject.activeSelf && gameManager.currentGameState == GameManager.GameState.Play)
        {

            // �^�b�v(�}�E�X�N���b�N)�̈ʒu���擾���ă��[���h���W�ɕϊ����A���������Ƀ^�C���̃Z�����W�ɕϊ�
            gridPos = grid.WorldToCell(Camera.main.ScreenToWorldPoint(Input.mousePosition));


            ////*  �V����������ǉ�  *////


            // �^�b�v�����ʒu�̃^�C���̃R���C�_�[�̏����m�F���A���ꂪ None �ł���Ȃ�
            if (tilemaps.GetColliderType(gridPos) == Tile.ColliderType.None)
            {

                // �L�����������������\�b�h��
                //CreateChara(gridPos);
                

                // �z�u�L�����I��p�|�b�v�A�b�v�̕\��
                ActivatePlacementCharaSelectPopUp();

            }

        }
    }

    /// <summary>
    /// �L��������
    /// </summary>
    /// <param name="gridPos"></param>
    //private void CreateChara(Vector3Int gridPos)
    //{

    //    // �^�b�v�����ʒu�ɃL�����𐶐����Ĕz�u
    //    GameObject chara = Instantiate(charaPrefab, gridPos, Quaternion.identity);

    //    // �L�����̈ʒu���^�C���̍����� 0,0 �Ƃ��Đ������Ă���̂ŁA�^�C���̒����ɂ���悤�Ɉʒu�𒲐�
    //    chara.transform.position = new Vector2(chara.transform.position.x + 0.5f, chara.transform.position.y + 0.5f);
    //}

    

    

    /// <summary>
    /// �ݒ�
    /// </summary>
    /// <param name="gameManager"></param>
    /// <returns></returns>
    public IEnumerator SetUpCharaGenerator(GameManager gameManager)//�O�����玝���Ă���gamemanager��
    {

        this.gameManager = gameManager;//���̃��\�b�h�Ő錾����gamemanager�ɑ��

        // TODO �X�e�[�W�̃f�[�^���擾


        // �L�����̃f�[�^�����X�g��
        CreateHaveCharaDatasList();

        // TODO ���X�g�擾


        // �L�����z�u�p�̃|�b�v�A�b�v�̐���
        yield return StartCoroutine(CreatePlacementCharaSelectPopUp());
    }


    /// <summary>
    /// �z�u�L�����I��p�|�b�v�A�b�v����
    /// </summary>
    /// <returns></returns>
    private IEnumerator CreatePlacementCharaSelectPopUp()
    { 
        

        // �|�b�v�A�b�v�𐶐�
        placementCharaSelectPopUp = Instantiate(placementCharaSelectPopUpPrefab, canvasTran, false);

        // �|�b�v�A�b�v�̐ݒ�
        placementCharaSelectPopUp.SetUpPlacementCharaSelectPopUp(this, charaDatasList);

        // �|�b�v�A�b�v���\���ɂ���
        placementCharaSelectPopUp.gameObject.SetActive(false);

        //GameState��Play�ɂ���
        gameManager.currentGameState = GameManager.GameState.Play;

        yield return null;
    }


    /// <summary>
    /// �z�u�L�����I��p�̃|�b�v�A�b�v�̕\��
    /// </summary>
    public void ActivatePlacementCharaSelectPopUp()
    {
        //GameState��Pause�ɂ���
        gameManager.SetGameState(GameManager.GameState.Pause);

        // TODO ���ׂĂ̓G�̈ړ����ꎞ��~
        gameManager.PauseEnemies();

        // �z�u�L�����I��p�̃|�b�v�A�b�v�̕\��
        placementCharaSelectPopUp.gameObject.SetActive(true);
        placementCharaSelectPopUp.ShowPopUp();

        

    }

    /// <summary>
    /// �z�u�L�����I��p�̃|�b�v�A�b�v�̔�\��
    /// </summary>
    public void InactivatePlacementCharaSelectPopUp()
    {

        // �z�u�L�����I��p�̃|�b�v�A�b�v�̔�\��
        placementCharaSelectPopUp.gameObject.SetActive(false);


        // �Q�[���I�[�o�[��Q�[���N���A�ł͂Ȃ��ꍇ
        if (gameManager.currentGameState != GameManager.GameState.GameUp)
        {
            // �Q�[���̐i�s��Ԃ��v���C���ɕύX���āA�Q�[���ĊJ
            gameManager.SetGameState (GameManager.GameState.Play);

            //Debug.Log("�ĊJ");
            // ���ׂĂ̓G�̈ړ����ĊJ
            gameManager.ResumeEnemies();

            

        }
    }

    /// <summary>
    /// �L�����̃f�[�^�����X�g��
    /// </summary>
    private void CreateHaveCharaDatasList()
    {

        // CharaDataSO �X�N���v�^�u���E�I�u�W�F�N�g���� CharaData ���P�����X�g�ɒǉ�
        // TODO �X�N���v�^�u���E�I�u�W�F�N�g�ł͂Ȃ��A���ۂɃv���C���[���������Ă���L�����̔ԍ������ɃL�����̃f�[�^�̃��X�g���쐬
        for (int i = 0; i < DataBaseManager.instance.charaDataSO.charaDatasList.Count; i++)
        {
            charaDatasList.Add(DataBaseManager.instance.charaDataSO.charaDatasList[i]);
        }
    }

    /// <summary>
    /// �I�������L�����𐶐����Ĕz�u
    /// </summary>
    /// <param name="charaData"></param>
    public void CreateChooseChara(CharaData charaData)
    {
        if (GameData.Instance.nowGold >= charaData.cost)
        {
            // �R�X�g�x����
            PayCharaCost(charaData);

            // �L�������^�b�v�����ʒu�ɐ���
            CharaController chara = Instantiate(charaControllerPrefab, gridPos, Quaternion.identity);

            // �ʒu�������� 0,0 �Ƃ��Ă���̂ŁA�����ɂ���悤�ɒ���
            chara.transform.position = new Vector2(chara.transform.position.x + 0.5f, chara.transform.position.y + 0.5f);

            // TODO �L�����̐ݒ�
            chara.SetUpChara(charaData, gameManager);    //  <=  ���@CharaController ���� SetUpChara ���\�b�h���܂��Ȃ��̂ŁA���̎菇�ɂȂ��Ă���R�����g�A�E�g���������܂��B

            Debug.Log(charaData.charaName);   // �I�����Ă���L�����̃f�[�^���Ƃǂ��Ă��邩���m�F���邽�߂̃��O�\��
        }
            


        // TODO �L������ List �ɒǉ�

    }

    public void PayCharaCost(CharaData charaData)
    {
            GameData.Instance.nowGold = GameData.Instance.nowGold - charaData.cost; 
    }
}