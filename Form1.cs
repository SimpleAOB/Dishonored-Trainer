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
        playerInfo.PlayerDataBreathInfo playerBreath = new playerInfo.PlayerDataBreathInfo();

        [DllImport("user32.dll")]
        static extern bool SetWindowText(IntPtr hWnd, string text);

        bool GameFound = false;
        int gameProcId;
        int playerBaseHealth;
        int playerBaseMana;
        int playerBaseBreath;

        int origSize;

        Process DishonoredTextProc;

        public mainForm()
        {
            InitializeComponent();
        }

        private void mainForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            SetWindowText(DishonoredTextProc.MainWindowHandle, "Dishonored -- Hacks Closed [Inactive]");
        }

        private void mainForm_Load(object sender, EventArgs e)
        {
            origSize = this.Height;
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
                this.Height = origSize;
                hookGameButton.Text = "Game Hooked (Status: Connected to PID:" + gameProcId + " )";
                this.mainTooltip.SetToolTip(this.hookGameButton, "PID in hex: 0x" + gameProcId.ToString("X") + "\n\nWe do not check if the game is still active after the initial hook");
                //Timers
                healthTimer.Enabled = true;
                manaTimer.Enabled = true;
                breathTimer.Enabled = true;
                //Offsets
                playerHP.offsets = new playerInfo.PlayerAddyOffsets(0x0);
                playerMana.offsets = new playerInfo.playerDataMana(0x0);
                playerBreath.offsets = new playerInfo.playerDataBreath(0x0);
                //Bases -- These are the same but separated for consistancy sake
                playerHP.baseAddress = 0x01452DE8;
                playerMana.baseAddress = 0x01452DE8;
                playerBreath.baseAddress = 0x01452DE8;
                //Multilevel
                playerHP.multilevel = new int[] { 0x344 };
                playerMana.multilevel = new int[] { 0xA60 };
                playerBreath.multilevel = new int[] { 0xAB8 };

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
                setHealth(70);
            }
        }
        private void manaTimer_Tick(object sender, EventArgs e)
        {
            if (manaCheck.Checked == true)
            {
                playerBaseMana = Mem.ReadMultiLevelPointer(playerMana.baseAddress, 4, playerMana.multilevel);
                setMana(100);
            }
        }
        private void breathTimer_Tick(object sender, EventArgs e)
        {
            if (breathCheck.Checked == true)
            {
                playerBaseBreath = Mem.ReadMultiLevelPointer(playerBreath.baseAddress, 4, playerBreath.multilevel);
                setBreath(30);
            }
        }
        #endregion
        #region Set Values in memory
        public void setHealth(int hp)
        {
            playerBaseHealth = Mem.ReadMultiLevelPointer(playerHP.baseAddress, 4, playerHP.multilevel);
            Mem.WriteInt(playerBaseHealth, hp);
            bool mouseDown = (MouseButtons == MouseButtons.Left);
        }
        public void setMana(int mana)
        {
            playerBaseMana = Mem.ReadMultiLevelPointer(playerMana.baseAddress, 4, playerMana.multilevel);
            Mem.WriteInt(playerBaseMana, mana);
        }
        public void setBreath(float breath) 
        {
            playerBaseBreath = Mem.ReadMultiLevelPointer(playerBreath.baseAddress, 4, playerBreath.multilevel);
            Mem.WriteFloat(playerBaseBreath, breath);
        }
        #endregion
    }
}