/*
架構上問題:
1.把狀態更新跟狀態開始混在一起了

*/

/// <summary>
/// 控制遊戲的系統階段(狀態模式)
/// </summary>
public class GameStateController
{
    // 紀錄目前狀態
    IGameState m_gameState = null;
    // 目前狀態是否開始了
    protected bool isNotBegin = false;

    /// <summary>
    /// 設定新狀態
    /// </summary>
    /// <param name="theState"></param>
    public void SetGameState(IGameState theState)
    {
        isNotBegin = false;

        // 若狀態存在
        if (m_gameState != null)
            m_gameState.StateEnd();// 令該狀態執行結束階段

        // 設定新狀態
        m_gameState = theState;
    }

    /// <summary>
    /// 控制器叫狀態自行處理行為
    /// </summary>
    public void StateRequest()
    {
        LogServise.Log("GameStateController發出切換State請求");
        m_gameState.Handle();
    }

    /// <summary>
    /// 狀態更新
    /// </summary>
    public void StateUpdate()
    {
        // 若為該狀態的首次更新
        if (!isNotBegin && m_gameState != null)
        {
            m_gameState.StateBegin();// 執行開始階段處理
            isNotBegin = true;
        }

        // State更新
        if (m_gameState != null)
            m_gameState.StateUpdate();
    }
}
