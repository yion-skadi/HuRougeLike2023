using System.Collections;
using System.Collections.Generic;
using UnityEngine;


/// <summary>
/// ���O��J�t��
/// </summary>
public class InputSystem : GameSystem
{
    private KeyCode[] usedKeys = { KeyCode.W, KeyCode.S, KeyCode.A, KeyCode.D };

    private bool[] keys;

    public InputSystem(HuRougeLikeGame mediator) : base(mediator)
    {
        Initialize();
    }


    // ���a��J
    public bool InputProcess(ICharacter _character)
    {
        //LogServise.Log("���ݪ��a��J...");

        var player = _character;

        // �ոե�(����)
        if (Input.GetKeyDown(KeyCode.W)) { player.GetAI().March(Direction.Up); return true; }

        // �ոե�(����)
        if (Input.GetKeyDown(KeyCode.S)) { player.GetAI().March(Direction.Down); return true; }

        // �ոե�(����)
        if (Input.GetKeyDown(KeyCode.A)) { player.GetAI().March(Direction.Left); return true; }

        // �ոե�(����)
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

