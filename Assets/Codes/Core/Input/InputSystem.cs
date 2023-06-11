using System.Collections;
using System.Collections.Generic;
using UnityEngine;


/// <summary>
/// 指令輸入系統
/// </summary>
public class InputSystem : GameSystem
{
    private KeyCode[] usedKeys = { KeyCode.W, KeyCode.S, KeyCode.A, KeyCode.D };

    private bool[] keys;

    public InputSystem(HuRougeLikeGame mediator) : base(mediator)
    {
        Initialize();
    }


    // 玩家輸入
    public bool InputProcess(ICharacter _character)
    {
        //LogServise.Log("等待玩家輸入...");

        var player = _character;

        // 調試用(移動)
        if (Input.GetKeyDown(KeyCode.W)) { player.GetAI().March(Direction.Up); return true; }

        // 調試用(移動)
        if (Input.GetKeyDown(KeyCode.S)) { player.GetAI().March(Direction.Down); return true; }

        // 調試用(移動)
        if (Input.GetKeyDown(KeyCode.A)) { player.GetAI().March(Direction.Left); return true; }

        // 調試用(移動)
        if (Input.GetKeyDown(KeyCode.D)) { player.GetAI().March(Direction.Right); return true; }

        return false;
    }


    public override void Initialize()
    {
        base.Initialize();
        keys = new bool[usedKeys.Length];
    }

    public KeyCode playInput()
    {
        return KeyCode.A;
    }

    public override void Update()
    {
        for (int i = 0, n = usedKeys.Length; i < n; i++)
            keys[i] = Input.GetKey(usedKeys[i]);
    }
}

