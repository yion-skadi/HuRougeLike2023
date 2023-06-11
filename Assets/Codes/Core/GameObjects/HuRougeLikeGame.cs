using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// �D�C�����t�β׺�(�Y��)
/// </summary>
public class HuRougeLikeGame
{
    #region Singleton�Ҫ�

    // Singleton�Ҫ�
    private static HuRougeLikeGame _instance = null;
    public static HuRougeLikeGame Instance
    {
        get
        {
            if (_instance == null)
                _instance = new HuRougeLikeGame();
            return _instance;
        }
    }

    #endregion

    // �C���t��
    private StageSystem m_stageSystem = null;
    private CreatureSystem m_creatureSystem = null;
    private MapSystem m_mapSystem = null;
    private EffectSystem m_effectSystem = null;
    private UISystem m_uiSystem = null;
    private InputSystem m_inputSystem = null;

    // ��l��
    public void Initialize()
    {
        LogServise.Log("-�t�Ϊ`�J-");

        // �C���t��
        m_stageSystem = new StageSystem(this);      // ���d�t��
        m_creatureSystem = new CreatureSystem(this);// �ͪ��t��
        m_mapSystem = new MapSystem(this);        // �Գ��t��
        m_effectSystem = new EffectSystem(this);
        m_uiSystem = new UISystem(this);            // UI�t��
        m_inputSystem = new InputSystem(this);
        ///////////////////////////////////////////////////////////

        // �إߦa��
        m_mapSystem.m_mapManager.arcMap = m_mapSystem.CreateMap(); // ���;Գ��a��
        m_mapSystem.m_mapManager.creMap = m_creatureSystem.CreateFieldMap();     // ���ͥͪ��a��

        // �إߨ���u�t
        ICreatureFactory factory = HuRougeLike2022Factory.GetCreatureFactory();

        // �إߥͪ�
        #region ����
        ICharacter creature = factory.CreateCreature(ENUM_Creature.Elf,
                                                     ENUM_Body.Humanoid,
                                                     ENUM_Status.HumanChildStatus,
                                                     ENUM_CreatureAI.HumanAI,
                                                     ENUM_Model.ModelElf);
        creature.SetID(1);
        creature.SetName("���FA");
        m_creatureSystem.AddCreature(creature); // �[�J�ͪ�������


        creature = factory.CreateCreature(ENUM_Creature.Elf,
                                                     ENUM_Body.Humanoid,
                                                     ENUM_Status.HumanChildStatus,
                                                     ENUM_CreatureAI.WandererAI,
                                                     ENUM_Model.ModelElf);
        creature.SetID(2);
        creature.SetName("���FB");
        m_creatureSystem.AddCreature(creature); // �[�J�ͪ�������

        ///////////////////�Ǫ�

        creature = factory.CreateCreature(ENUM_Creature.Ogre,
                                                     ENUM_Body.Humanoid,
                                                     ENUM_Status.HumanChildStatus,
                                                     ENUM_CreatureAI.HunterAI,
                                                     ENUM_Model.ModelOgre);
        creature.SetID(3);
        creature.SetName("���H�]A");
        m_creatureSystem.AddCreature(creature); // �[�J�ͪ�������


        creature = factory.CreateCreature(ENUM_Creature.Ogre,
                                                     ENUM_Body.Humanoid,
                                                     ENUM_Status.HumanChildStatus,
                                                     ENUM_CreatureAI.HunterAI,
                                                     ENUM_Model.ModelOgre);
        creature.SetID(4);
        creature.SetName("���H�]B");
        m_creatureSystem.AddCreature(creature); // �[�J�ͪ�������
        #endregion


        m_mapSystem.Create_and_Refleshfmap(); // ��s�Գ��a��

        m_creatureSystem.Refleshfmap();       // ��s�ͪ��a��
    }

    public virtual void Release()
    {

    }

    // �C���t�Χ�s
    public void Update()
    {
        var player = m_creatureSystem.GetCharacter(0);

        // �P�B��s
        if (m_inputSystem.InputProcess(player))// ���a��J
        {
            m_stageSystem.Update();     // ���d�t�Χ�s
            m_mapSystem.Update();
            m_creatureSystem.Update();  // �ͪ��t�Χ�s

            LogServise.Log("===============�^�X�u=================");
            //m_mapSystem.Create_and_Refleshfmap(); // ��s�Գ��a��
            m_creatureSystem.Refleshfmap(); // ��s�ͪ��a��
        }

        // �D�P�B��s
        //m_inputSystem.Update();
        m_effectSystem.Update(); // �S�Ĩt�Χ�s
        m_uiSystem.Update(); // UI�t�Χ�s
    }

    // �a��

    // ���o��a��
    public Block[,] GetWallMap()
    {
        return m_mapSystem.GetWall_01Map();
    }


    // ���o���w�� �ͪ�ID
    public int GetThatCreatureID(Position2D position)
    {
        return m_creatureSystem.GetCieldMap()[position.x, position.y].creature_ID;
    }

    // ���o���w�ͪ�by ID
    public ICharacter GetCharacterByID(int id)
    {
        return m_creatureSystem.GetCharacterByID(id);
    }

    // �P�_���w�� �ͪ�
    public bool isThatCreature(int _x, int _y)
    {
        if (m_creatureSystem.GetCieldMap() == null)
        {
            LogServise.Log("creatureSystem.cieldMap is mull");
            return false;
        }

        LogServise.Log("��l_�ͪ��T�{: x:" + _x + "y:" + _y + ">>>>" + m_creatureSystem.GetCieldMap()[_x, _y].isCreature());
        return m_creatureSystem.GetCieldMap()[_x, _y].isCreature();
    }

    // ���o���w�� �ͪ�
    public ICharacter GetThatCreature(Position2D position)
    {
        int id = GetThatCreatureID(position);

        return GetCharacterByID(id);
    }

}
