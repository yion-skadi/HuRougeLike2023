/*
�[�c�W���D:
1.�⪬�A��s�򪬺A�}�l�V�b�@�_�F

*/

/// <summary>
/// ����C�����t�ζ��q(���A�Ҧ�)
/// </summary>
public class GameStateController
{
    // �����ثe���A
    IGameState m_gameState = null;
    // �ثe���A�O�_�}�l�F
    protected bool isNotBegin = false;

    /// <summary>
    /// �]�w�s���A
    /// </summary>
    /// <param name="theState"></param>
    public void SetGameState(IGameState theState)
    {
        isNotBegin = false;

        // �Y���A�s�b
        if (m_gameState != null)
            m_gameState.StateEnd();// �O�Ӫ��A���浲�����q

        // �]�w�s���A
        m_gameState = theState;
    }

    /// <summary>
    /// ����s���A�ۦ�B�z�欰
    /// </summary>
    public void StateRequest()
    {
        LogServise.Log("GameStateController�o�X����State�ШD");
        m_gameState.Handle();
    }

    /// <summary>
    /// ���A��s
    /// </summary>
    public void StateUpdate()
    {
        // �Y���Ӫ��A��������s
        if (!isNotBegin && m_gameState != null)
        {
            m_gameState.StateBegin();// ����}�l���q�B�z
            isNotBegin = true;
        }

        // State��s
        if (m_gameState != null)
            m_gameState.StateUpdate();
    }
}
