using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// 主遊戲的系統終端(即時)
/// </summary>
public class HuRougeLikeGame
{
    #region Singleton模版

    // Singleton模版
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

    // 遊戲系統
    private StageSystem m_stageSystem = null;
    private CreatureSystem m_creatureSystem = null;
    private MapSystem m_mapSystem = null;
    private EffectSystem m_effectSystem = null;
    private UISystem m_uiSystem = null;
    private InputSystem m_inputSystem = null;

    // 初始化
    public void Initialize()
    {
        LogServise.Log("-系統注入-");

        // 遊戲系統
        m_stageSystem = new StageSystem(this);      // 關卡系統
        m_creatureSystem = new CreatureSystem(this);// 生物系統
        m_mapSystem = new MapSystem(this);        // 戰場系統
        m_effectSystem = new EffectSystem(this);
        m_uiSystem = new UISystem(this);            // UI系統
        m_inputSystem = new InputSystem(this);
        ///////////////////////////////////////////////////////////

        // 建立地圖
        m_mapSystem.m_mapManager.arcMap = m_mapSystem.CreateMap(); // 產生戰場地圖
        m_mapSystem.m_mapManager.creMap = m_creatureSystem.CreateFieldMap();     // 產生生物地圖

        // 建立角色工廠
        ICreatureFactory factory = HuRougeLike2022Factory.GetCreatureFactory();

        // 建立生物
        #region 測試
        ICharacter creature = factory.CreateCreature(ENUM_Creature.Elf,
                                                     ENUM_Body.Humanoid,
                                                     ENUM_Status.HumanChildStatus,
                                                     ENUM_CreatureAI.HumanAI,
                                                     ENUM_Model.ModelElf);
        creature.SetID(1);
        creature.SetName("精靈A");
        m_creatureSystem.AddCreature(creature); // 加入生物紀錄中


        creature = factory.CreateCreature(ENUM_Creature.Elf,
                                                     ENUM_Body.Humanoid,
                                                     ENUM_Status.HumanChildStatus,
                                                     ENUM_CreatureAI.WandererAI,
                                                     ENUM_Model.ModelElf);
        creature.SetID(2);
        creature.SetName("精靈B");
        m_creatureSystem.AddCreature(creature); // 加入生物紀錄中

        ///////////////////怪物

        creature = factory.CreateCreature(ENUM_Creature.Ogre,
                                                     ENUM_Body.Humanoid,
                                                     ENUM_Status.HumanChildStatus,
                                                     ENUM_CreatureAI.HunterAI,
                                                     ENUM_Model.ModelOgre);
        creature.SetID(3);
        creature.SetName("食人魔A");
        m_creatureSystem.AddCreature(creature); // 加入生物紀錄中


        creature = factory.CreateCreature(ENUM_Creature.Ogre,
                                                     ENUM_Body.Humanoid,
                                                     ENUM_Status.HumanChildStatus,
                                                     ENUM_CreatureAI.HunterAI,
                                                     ENUM_Model.ModelOgre);
        creature.SetID(4);
        creature.SetName("食人魔B");
        m_creatureSystem.AddCreature(creature); // 加入生物紀錄中
        #endregion


        m_mapSystem.Create_and_Refleshfmap(); // 更新戰場地圖

        m_creatureSystem.Refleshfmap();       // 更新生物地圖
    }

    public virtual void Release()
    {

    }

    // 遊戲系統更新
    public void Update()
    {
        var player = m_creatureSystem.GetCharacter(0);

        // 同步更新
        if (m_inputSystem.InputProcess(player))// 玩家輸入
        {
            m_stageSystem.Update();     // 關卡系統更新
            m_mapSystem.Update();
            m_creatureSystem.Update();  // 生物系統更新

            LogServise.Log("===============回合線=================");
            //m_mapSystem.Create_and_Refleshfmap(); // 更新戰場地圖
            m_creatureSystem.Refleshfmap(); // 更新生物地圖
        }

        // 非同步更新
        //m_inputSystem.Update();
        m_effectSystem.Update(); // 特效系統更新
        m_uiSystem.Update(); // UI系統更新
    }

    // 地圖

    // 取得牆地圖
    public Block[,] GetWallMap()
    {
        return m_mapSystem.GetWall_01Map();
    }


    // 取得指定格 生物ID
    public int GetThatCreatureID(Position2D position)
    {
        return m_creatureSystem.GetCieldMap()[position.x, position.y].creature_ID;
    }

    // 取得指定生物by ID
    public ICharacter GetCharacterByID(int id)
    {
        return m_creatureSystem.GetCharacterByID(id);
    }

    // 判斷指定格 生物
    public bool isThatCreature(int _x, int _y)
    {
        if (m_creatureSystem.GetCieldMap() == null)
        {
            LogServise.Log("creatureSystem.cieldMap is mull");
            return false;
        }

        LogServise.Log("格子_生物確認: x:" + _x + "y:" + _y + ">>>>" + m_creatureSystem.GetCieldMap()[_x, _y].isCreature());
        return m_creatureSystem.GetCieldMap()[_x, _y].isCreature();
    }

    // 取得指定格 生物
    public ICharacter GetThatCreature(Position2D position)
    {
        int id = GetThatCreatureID(position);

        return GetCharacterByID(id);
    }

}
