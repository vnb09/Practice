using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SimonSays
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        int onInList = 0;
        List<int> pattern = new List<int>{};
        Random rand = new Random();
        bool playingBack = false;

        void playback()
        {
            playingBack = true;
            
            foreach (int color in pattern)
            {
                switch (color)
                {
                    case 0:
                        RED.BackColor = Color.Red;
                                            
                        Thread.Sleep(400);
                        RED.BackColor = Color.Transparent;
                        break;

                    case 1:
                       YELLOW.BackColor = Color.Yellow;
                       
                        Thread.Sleep(400);
                        YELLOW.BackColor = Color.Transparent;
                        break;

                    case 2:
                        GREEN.BackColor = Color.Green;
                        
                        Thread.Sleep(400);
                        GREEN.BackColor = Color.Transparent;
                        break;

                    case 3:
                        BLUE.BackColor = Color.Blue;
                        
                        Thread.Sleep(400);
                        BLUE.BackColor = Color.Transparent;
                        break;


                }
                Thread.Sleep(600);
            }
            playingBack = false;
        }

        void testCorrect(int color)
        {
            if (playingBack)
                return;

            if (pattern[onInList] == color)
                onInList++;

            else
            {
                MessageBox.Show($"WRONG PATTERN! FINAL SCORE: {pattern.Count.ToString()}");
                onInList = 0;
                pattern = new List<int>();
                this.Close();
                
            }

            if (onInList >= pattern.Count)
            {
                pattern.Add(rand.Next(0, 4));
                onInList = 0;
                new Thread(playback).Start();
            }

            ScoreLabel.Text = ($"Score: {pattern.Count.ToString()}");
            PatternLabel.Text = ($"Item within pattern: {onInList.ToString()}");
               
        }




        private void Form1_Load(object sender, EventArgs e)
        {
            pattern.Add(rand.Next(0,4));
            new Thread(playback).Start();
            

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void RED_Click(object sender, EventArgs e)
        {
            testCorrect(0);
        }

        private void YELLOW_Click(object sender, EventArgs e)
        {
            testCorrect(1);
        }

        private void GREEN_Click(object sender, EventArgs e)
        {
            testCorrect(2);
        }

        private void BLUE_Click(object sender, EventArgs e)
        {
            testCorrect(3);
        }

        private void PatternLabel_Click(object sender, EventArgs e)
        {

        }
    }
}
