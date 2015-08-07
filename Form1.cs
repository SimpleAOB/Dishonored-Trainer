using ProcessMemoryReaderLib;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Dishonored_Trainer
{
    public partial class mainForm : Form
    {
        Process[] MyProcess;
        ProcessModule mainModule;
        ProcessMemoryReader Mem = new ProcessMemoryReader();
        playerInfo.PlayerDataHealthInfo playerHP = new playerInfo.PlayerDataHealthInfo();
        playerInfo.PlayerDataManaInfo playerMana = new playerInfo.PlayerDataManaInfo();
        //playerInfo.PlayerData playerM = new playerInfo.PlayerData();

        [DllImport("user32.dll")]
        static extern bool SetWindowText(IntPtr hWnd, string text);

        bool GameFound = false;
        int gameProcId;
        int playerBaseHealth;
        int playerBaseMana;

        bool healthBoxReady;
        bool manaBoxReady;

        Process DishonoredTextProc;

        public mainForm()
        {
            InitializeComponent();
        }

        private void mainForm_Load(object sender, EventArgs e)
        {
            //Set height to not being able to view hacks
            this.Height = 85;
        }

        private void hookGameButton_Click(object sender, EventArgs e)
        {
            MyProcess = Process.GetProcesses();
            for (int i = 0; i < MyProcess.Length; i++)
            {
                if (MyProcess[i].ProcessName == "Dishonored")
                {
                    gameProcId = MyProcess[i].Id;
                    break;
                }
            }
            try
            {
                MyProcess[0] = Process.GetProcessById(gameProcId);
                mainModule = MyProcess[0].MainModule;
                Mem.ReadProcess = MyProcess[0];
                Mem.OpenProcess();
                GameFound = true;
                //GameFound is true, set all game specific variables and stuff here
                this.Height = 270;
                hookGameButton.Text = "Game Hooked (Status: Connected to PID:" + gameProcId + " )";
                this.mainTooltip.SetToolTip(this.hookGameButton, "PID in hex: 0x" + gameProcId.ToString("X") + "\n\nWe do not check if the game is still active after the initial hook");
                //Timers
                healthTimer.Enabled = true;
                manaTimer.Enabled = true;
                //Offsets
                playerHP.offsets = new playerInfo.PlayerAddyOffsets(0x0);
                playerMana.offsets = new playerInfo.playerDataMana(0x0);
                //Bases
                playerHP.baseAddress = 0x01452DE8;
                playerMana.baseAddress = 0x01452DE8;
                //Multilevel
                playerHP.multilevel = new int[] { 0x344 };
                playerMana.multilevel = new int[] { 0xA60 };

                DishonoredTextProc = Process.GetProcessById(gameProcId);
                SetWindowText(DishonoredTextProc.MainWindowHandle, "Dishonored -- Hacks Active");
            }
            catch (Exception ex)
            {
                MessageBox.Show("Could not connect (the game is probably not running): \n\n" + ex.Message + ex.StackTrace);
            }
        }
        #region Timer Ticks
        private void healthTimer_Tick(object sender, EventArgs e)
        {
            if (healthCheck.Checked == true)
            {
                playerBaseHealth = Mem.ReadMultiLevelPointer(playerHP.baseAddress, 4, playerHP.multilevel);
                Mem.WriteInt(playerBaseHealth, Convert.ToInt32(healthTextBox.Text));
            }
            else
            {
                playerBaseHealth = Mem.ReadMultiLevelPointer(playerHP.baseAddress, 4, playerHP.multilevel);
                healthTextBox.Text = Convert.ToString(Mem.ReadInt(playerBaseHealth));
            }
        }
        private void manaTimer_Tick(object sender, EventArgs e)
        {
            if (manaCheck.Checked == true)
            {
                playerBaseMana = Mem.ReadMultiLevelPointer(playerMana.baseAddress, 4, playerMana.multilevel);
                Mem.WriteInt(playerBaseMana, Convert.ToInt32(manaTextBox.Text));
            }
            else
            {
                playerBaseMana = Mem.ReadMultiLevelPointer(playerMana.baseAddress, 4, playerMana.multilevel);
                manaTextBox.Text = Convert.ToString(Mem.ReadInt(playerBaseMana));
            }
        }
        #endregion

        private void textBox1_Leave(object sender, EventArgs e)
        {
            if (healthTextBox.Text != "")
            {
                bool isInt = Regex.IsMatch(healthTextBox.Text, @"^\d+$");
                if (!isInt)
                {
                    MessageBox.Show("Please enter a number in the box");
                }
                else
                {
                    healthBoxReady = true;
                }
            }
            else
            {
                MessageBox.Show("Please fill in a value in the health textbox");
            }
        }

        private void textBox1_Enter(object sender, EventArgs e)
        {
            healthTimer.Enabled = false;
        }

        private void setHacksButton_Click(object sender, EventArgs e)
        {
            setHealth(Convert.ToInt32(healthTextBox.Text));
            setMana(Convert.ToInt32(manaTextBox.Text));
        }
        public void setHealth(int hp)
        {
            if (healthBoxReady)
            {
                playerBaseHealth = Mem.ReadMultiLevelPointer(playerHP.baseAddress, 4, playerHP.multilevel);
                Mem.WriteInt(playerBaseHealth, hp);
                healthTimer.Enabled = true;
            }
        }
        public void setMana(int mana)
        {
            if (manaBoxReady)
            {
                playerBaseHealth = Mem.ReadMultiLevelPointer(playerMana.baseAddress, 4, playerMana.multilevel);
                Mem.WriteInt(playerBaseMana, mana);
                manaTimer.Enabled = true;
            }
        }
        private void mainForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            SetWindowText(DishonoredTextProc.MainWindowHandle, "Dishonored -- Hacks Closed [Inactive]");
        }

        private void manaTextBox_Enter(object sender, EventArgs e)
        {
            manaTimer.Enabled = false;
        }

        private void manaTextBox_Leave(object sender, EventArgs e)
        {
            if (manaTextBox.Text != "")
            {
                bool isInt = Regex.IsMatch(manaTextBox.Text, @"^\d+$");
                if (!isInt)
                {
                    MessageBox.Show("Please enter a number in the box");
                }
                else
                {
                    manaBoxReady = true;
                }
            }
            else
            {
                MessageBox.Show("Please fill in a value in the mana textbox");
            }
        }
    }
}