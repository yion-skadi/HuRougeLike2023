using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// �Գ��޲z�t��
/// </summary>
public class MapSystem : GameSystem
{
    private MapGenerator dungeonGenerator = new MapGenerator();     // �a�ϲ��;�
    public MapManager m_mapManager { get; set; } = new MapManager();

    // �غc��
    public MapSystem(HuRougeLikeGame mediator) : base(mediator)
    {
        Initialize();
        m_mapManager.arcMap = new ArcMap();// ���a�a�ϥ���
    }

    // ����-���a�a��
    public ArcMap CreateMap()
    {
        // �ͦ��a��
        LogServise.Log("�ͦ��a�Ϥ�");

        // ��l��
        dungeonGenerator.InitializeDungeon();

        // ���ͳ��a�a��
        dungeonGenerator.GenerateDungeon();

        // ���o�w���ͪ����a�a��, �æs�J����(m_mapManager)
        m_mapManager.arcMap = dungeonGenerator.GetMapManager();

        return m_mapManager.arcMap;
    }

    // �гy�ç�s-���aid�a��
    public void Create_and_Refleshfmap()
    {
        var length = m_mapManager.arcMap.mapHeight;
        var height = m_mapManager.arcMap.mapWidth;

        Field[,] fMap = new Field[length, height];

        // ����P�a�OID
        for (int i = 0; i < length; i++)
        {
            for (int j = 0; j < height; j++)
            {
                fMap[i, j] = new Field();

                var tempBlockId = m_mapManager.arcMap.blockMap[i, j].id;
                var tempFloorId = m_mapManager.arcMap.floorsMap[i, j].id;
                fMap[i, j].wall_ID = 1;
            }
        }

        m_mapManager.arcMap.fieldMap = fMap;
    }

    #region ���o�a�ϸ��

    // ���o�a��
    public ArcMap GetMap()
    {
        return m_mapManager.arcMap;
    }

    // ���o���aid�a��
    public Field[,] GetFieldMap()
    {
        return m_mapManager.arcMap.fieldMap;
    }

    // ���o��a��
    public Block[,] GetWall_01Map()
    {
        return m_mapManager.arcMap.blockMap;
    }

    #endregion

    #region �]�w�a�ϸ��

    // �]�w ����
    public void SetWallMap(Block[,] blocks)
    {
        for (int i = 0; i < m_mapManager.arcMap.fieldMap.GetLength(0); i++)
        {
            for (int j = 0; j < m_mapManager.arcMap.fieldMap.GetLength(1); j++)
            {
                m_mapManager.arcMap.fieldMap[i, j].floor_ID = blocks[i, j].id;
            }
        }
    }

    // �]�w �a�O���
    public void SetFloorMap()
    {

    }

    #endregion

    // �~�Ӧ�IGameSystem
    public override void Initialize()
    {
        base.Initialize();
    }
    public override void Release() { Create_and_Refleshfmap(); }
    public override void Update() { }
}
