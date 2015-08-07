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
            public int mana;


            public PlayerAddyOffsets(int _health, int _mana = 0)
            {
                health = _health;
                mana = _mana;
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
    }
}