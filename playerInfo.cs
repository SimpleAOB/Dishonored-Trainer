using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dishonored_Trainer
{
    class playerInfo
    {
        #region Health Address / Offsets
        public class PlayerAddyOffsets
        {
            public int health;
            public PlayerAddyOffsets(int _health)
            {
                health = _health;
            }
        }
        public struct PlayerDataHealthInfo
        {
            public int baseAddress;
            public int[] multilevel;
            public PlayerAddyOffsets offsets;
        }
        #endregion
        //----------------------------
        #region Mana Address / Offsets
        public class playerDataMana
        {
            public int Mana;
            public playerDataMana(int _mana)
            {
                Mana = _mana;
            }
        }
        public struct PlayerDataManaInfo
        {
            public int baseAddress;
            public int[] multilevel;
            public playerDataMana offsets;
        }
        #endregion
        //----------------------------
        #region Breath Address / Offsets
        public class playerDataBreath
        {
            public int Breath;
            public playerDataBreath(int _breath)
            {
                Breath = _breath;
            }
        }
        public struct PlayerDataBreathInfo
        {
            public int baseAddress;
            public int[] multilevel;
            public playerDataBreath offsets;
        }
        #endregion
        //----------------------------
    }
}