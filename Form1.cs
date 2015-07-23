using ProcessMemoryReaderLib;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
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
        playerInfo.PlayerData playerHP = new playerInfo.PlayerData();
        playerInfo.PlayerDataM playerM = new playerInfo.PlayerDataM();

        bool GameFound = false;
        int gameProcId;
        int playerBaseHealth;

        bool healthBoxReady;

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
                //Offsets
                playerHP.offsets = new playerInfo.PlayerAddyOffsets(0x0);
                //Bases
                playerHP.baseAddress = 0x01052DE8;   // <- THIS NEEDS TO BE REPLACED WITH REAL BASE ADDRESS
                //Multilevel
                playerHP.multilevel = new int[] { 0x344, 0x0 };
            }
            catch (Exception ex)
            {
                MessageBox.Show("Could not connect (the game is probably not running): \n\n" + ex.Message + ex.StackTrace);
            }
        }

        private void healthTimer_Tick(object sender, EventArgs e)
        {
            if (healthCheck.Checked == true)
            {

            }
            else
            {
                playerBaseHealth = Mem.ReadMultiLevelPointer(playerHP.baseAddress, 4, playerHP.multilevel);
                healthTextBox.Text = Convert.ToString(Mem.ReadInt(playerBaseHealth + playerHP.offsets.health));
                textBox1.Text = (playerBaseHealth + playerHP.offsets.health).ToString("X");

                this.Enabled = false;
                healthTimer.Enabled = false;
            }
        }

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
            setHealth();
        }
        public void setHealth()
        {
            if (healthBoxReady)
            {
                healthTimer.Enabled = true;
            }
        }
    }
}