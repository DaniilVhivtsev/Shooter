using Shooter.Controllers;
using Shooter.Entites;
using Shooter.Model;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Text;
using System.Windows.Forms;

namespace Shooter
{
    public static class Game
    {
        public static Image DwarfSheet;
        public static Entity Player;

        public static List<Enemy> Enemies;

        public static List<Phisics_Of_Shoot> Shoots;
        public static List<Phisics_Of_Shoot> ShootsEnemy;

        public static int SpeedOfShootButtonHeroNumericNumber
        {
            get; set;
        }
        public static int SpeedOfShootButtonEnemyNumericNumber
        {
            get; set;
        }
        public static int NumberOfEnemiesNumericNumber = 2;

        public static int SpeedOfEnemyNumericNumber
        {
            get; set;
        }
        public static int EnemyDamageNumericNumber = 10;
        public static int HeroDamageNumericNumber = 25;

        public static int Score = 0;

        public static void StartPaint(Object e, PaintEventArgs args)
        {
            MapController.DrawMap(args.Graphics);
            MapController.PlayAnimation(args.Graphics, Player);
        }
        public static void Init()
        {
            /*speedOfShootButtonHeroNumericNumber = 0;
            speedOfShootButtonEnemyNumericNumber = 0;
            numberOfEnemiesNumericNumber = 0;
            speedOfEnemyNumericNumber = 0;*/

            Enemies = new List<Enemy>();
            Enemies = MapController.Enemies;

            MapController.Init();

            DwarfSheet = new Bitmap(Path.Combine(new DirectoryInfo(Directory.GetCurrentDirectory()).Parent.Parent.Parent.FullName.ToString(), "Sprites\\Man.png"));

            Player = new Entity(310, 310, Hero.IdleFrames, Hero.RunFrames, Hero.AtackFrames, Hero.DeathFrames, DwarfSheet);

            Shoots = new List<Phisics_Of_Shoot>();
            ShootsEnemy = new List<Phisics_Of_Shoot>();

            Enemies = new List<Enemy>();
            Enemies = MapController.Enemies;
        }
        public static void OnKeyUp(object sender, KeyEventArgs e)
        {
            switch (e.KeyCode)
            {
                case Keys.W:
                    Player.DirY = 0;
                    break;
                case Keys.S:
                    Player.DirY = 0;
                    break;
                case Keys.A:
                    Player.DirX = 0;
                    break;
                case Keys.D:
                    Player.DirX = 0;
                    break;
            }

            if (Player.DirX == 0 && Player.DirY == 0)
            {
                Player.IsMoovng = false;
                Player.IsShoot = false;
                Player.SetAnimationConfiguration(2);
            }
        }
        public static void OnPress(object sender, KeyEventArgs e)
        {
            switch (e.KeyCode)
            {
                case Keys.W:
                    Player.DirY = -2;
                    Player.IsMoovng = true;
                    Player.SetAnimationConfiguration(0);
                    break;
                case Keys.S:
                    Player.DirY = 2;
                    Player.IsMoovng = true;
                    Player.SetAnimationConfiguration(0);
                    break;
                case Keys.A:
                    Player.DirX = -2;
                    Player.IsMoovng = true;
                    Player.Flip = -1;
                    Player.SetAnimationConfiguration(7);
                    break;
                case Keys.D:
                    Player.DirX = 2;
                    Player.IsMoovng = true;
                    Player.Flip = 1;
                    Player.SetAnimationConfiguration(0);
                    break;
            }
        }
        public static void OnMousePress(object sender, MouseEventArgs e)
        {
            if (!Entity.Death)
            {
                switch (e.Button)
                {
                    case MouseButtons.Left:
                        Player.DirX = 0;
                        Player.DirY = 0;
                        Player.IsMoovng = false;
                        Player.IsShoot = true;
                        Player.SetAnimationConfiguration(5);
                        break;
                }
            }
        }
        public static void OnMouseUp(object sender, MouseEventArgs e)
        {
            Player.SetAnimationConfiguration(2);
        }

        
    }
}
