using Assets.Codes.Core.GameObjectsEntity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assets.Codes.Content.Combat
{
    public interface ICombatSystem
    {
        bool Attack(EntityUid attacker, EntityUid targeter);
    }

    public class CombatSystem : ICombatSystem
    {
        public bool Attack(EntityUid attacker, EntityUid targeter)
        {

            return DoAttack(attacker, targeter);
        }

        private bool DoAttack(EntityUid attacker, EntityUid targeter)
        {
            // 特效
            //EffectSystem.Effect(new IEffect(ENUM_Effect.attack), m_character.Pos, position);

            //// 傷害計算
            //var atk = attacker.GetState().ATK;

            //// 取得該格 生物ID
            //var creId = HuRougeLikeGame.Instance.GetThatCreatureID(position);
            //var cre = HuRougeLikeGame.Instance.GetCharacterByID(creId);

            //var temphp = cre.GetState().HP;

            //cre.GetState().GetDamage(atk);

            //LogServise.Log("[" + m_character.GetName() + "]" + " 攻擊 [" + cre.GetName() + "]  (dmg:" + atk + ")  HP " + temphp + "->" + cre.GetState().HP);
            return true;
        }
    }
}
