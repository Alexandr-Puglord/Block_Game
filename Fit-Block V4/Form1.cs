using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.IO;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Runtime.CompilerServices;
using System.Diagnostics;

namespace Tetris
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();

        }

        private void UTLaunchButton_Click(object sender, EventArgs e)
        {
            UnityTetris UT = new UnityTetris();

            UT.RunGame();
        }
    }

    public abstract class Game
    {
        //Variables
        public string CurrentDir = Directory.GetCurrentDirectory();
        
        public string Name { get; set; }

        //Constructor
        public Game(string N)
        {
            this.Name = N;
        }

        public abstract void RunGame();
    }

    public class UnityTetris : Game
    {
        public UnityTetris(string name = "UnityTetris") : base(name) { }

        public override void RunGame()
        {
            Process.Start(CurrentDir + "\\Fit-Blocks Game\\Fit-Blocks-Version-2.exe");
        }
    }
}
