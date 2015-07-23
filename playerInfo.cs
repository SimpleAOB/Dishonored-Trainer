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
        public class playerDataHealth
        {
            public int Health;


            public playerDataHealth(int _health)
            {
                Health = _health;
            }
        }
        public struct PlayerDataHP
        {
            public int baseAddress;
            public int[] multilevel;
            public playerDataHealth offsets;
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
        public struct PlayerDataM
        {
            public int baseAddress;
            public int[] multilevel;
            public playerDataMana offsets;
        }
        #endregion
    }
}
