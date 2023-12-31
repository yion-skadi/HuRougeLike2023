using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// 特效
public enum ENUM_Effect
{
    attack
}

public class IEffect
{
    IAssetFactory assetFactory = HuRougeLike2022Factory.GetAssetFactory();
    GameObject effectObject;

    // 建構者
    public IEffect(ENUM_Effect _effect)
    {
        ENUM_EffectModel enum_effectModel = new ENUM_EffectModel();
        switch (_effect)
        {
            case ENUM_Effect.attack:
                {
                    enum_effectModel = ENUM_EffectModel.ModelAttack;
                    break;
                }
            default:
                break;
        }

        // 設定模型
        GameObject CreatureModel = assetFactory.LoadEffectModel(enum_effectModel);

        // 載入模型
        SetGameObject(UnityEngine.Object.Instantiate(CreatureModel) as GameObject);

    }


    // 設定Unity模型
    public void SetGameObject(GameObject theGameObject)
    {
        effectObject = theGameObject;

        GameObject.Destroy(effectObject, 0.1f);
    }

    public GameObject GetGameObject()
    {
        return effectObject;
    }

}
