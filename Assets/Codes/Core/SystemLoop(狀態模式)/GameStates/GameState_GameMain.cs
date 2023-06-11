using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// �t�ζ��q:�C���D���q
/// (�D�C�������q)
/// </summary>
public class GameState_GameMain : IGameState
{
    public GameState_GameMain(GameStateController gameStateController) : base(gameStateController)
    {
        LogServise.Log("-�t�ζ��q:�C���D���q-");
    }

    public override void Handle()
    {

    }

    public override void StateBegin()
    {
        HuRougeLikeGame.Instance.Initialize();


    }

    // ����
    public override void StateEnd()
    {
        HuRougeLikeGame.Instance.Release();
    }

    // ��s
    public override void StateUpdate()
    {
        HuRougeLikeGame.Instance.Update();


    }
}