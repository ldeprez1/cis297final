using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static final_project.Form1;

namespace final_project
{
    public class Enemy : DamagableEntity
    {
        public static int GlobalScore { get; set; } = 0;
        public static Label? ScoreLabel { get; set; }

        int score;

        bool dead = false; //please delete enemy objects when they are hit, but just in case

        public override void Hit() //call when you hit an enemy with a bullet
        {
            GlobalScore = GlobalScore + score;
            if(ScoreLabel != null)
                ScoreLabel.Text = "SCORE\r\n" + GlobalScore;

            //just in case it doesnt get deleted
            dead = true;
            SpriteObject.Visible = false; 
        }

        public Enemy(double x, double y, PictureBox sprite, double width, double height, int score) : base(x, y, sprite, width, height)
        {
            this.score = score;
        }

        public Enemy(PictureBox sprite, double width, double height, int score) : base(sprite, width, height)
        {
            this.score = score;
        }
    }
}
