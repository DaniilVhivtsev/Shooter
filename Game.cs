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
        public static Image dwarfSheet;
        public static Entity player;

        public static List<Enemy> enemies;

        public static List<Phisics_Of_Shoot> shoots;
        public static List<Phisics_Of_Shoot> shootsEnemy;

        public static int speedOfShootButtonHeroNumericNumber
        {
            get; set;
        }
        public static int speedOfShootButtonEnemyNumericNumber
        {
            get; set;
        }
        public static int numberOfEnemiesNumericNumber = 2;

        public static int speedOfEnemyNumericNumber
        {
            get; set;
        }
        public static int enemyDamageNumericNumber = 10;
        public static int heroDamageNumericNumber = 25;

        public static int Score = 0;

        public static void StartPaint(Object e, PaintEventArgs args)
        {
            MapController.DrawMap(args.Graphics);
            MapController.PlayAnimation(args.Graphics, player);
        }
        public static void Init()
        {
            /*speedOfShootButtonHeroNumericNumber = 0;
            speedOfShootButtonEnemyNumericNumber = 0;
            numberOfEnemiesNumericNumber = 0;
            speedOfEnemyNumericNumber = 0;*/

            enemies = new List<Enemy>();
            enemies = MapController.Enemies;

            MapController.Init();

            dwarfSheet = new Bitmap(Path.Combine(new DirectoryInfo(Directory.GetCurrentDirectory()).Parent.Parent.Parent.FullName.ToString(), "Sprites\\Man.png"));

            player = new Entity(310, 310, Hero.idleFrames, Hero.runFrames, Hero.atackFrames, Hero.deathFrames, dwarfSheet);

            shoots = new List<Phisics_Of_Shoot>();
            shootsEnemy = new List<Phisics_Of_Shoot>();

            enemies = new List<Enemy>();
            enemies = MapController.Enemies;
        }
        public static void OnKeyUp(object sender, KeyEventArgs e)
        {
            switch (e.KeyCode)
            {
                case Keys.W:
                    player.dirY = 0;
                    break;
                case Keys.S:
                    player.dirY = 0;
                    break;
                case Keys.A:
                    player.dirX = 0;
                    break;
                case Keys.D:
                    player.dirX = 0;
                    break;
            }

            if (player.dirX == 0 && player.dirY == 0)
            {
                player.isMoovng = false;
                player.isShoot = false;
                player.SetAnimationConfiguration(2);
            }
        }
        public static void OnPress(object sender, KeyEventArgs e)
        {
            switch (e.KeyCode)
            {
                case Keys.W:
                    player.dirY = -2;
                    player.isMoovng = true;
                    player.SetAnimationConfiguration(0);
                    break;
                case Keys.S:
                    player.dirY = 2;
                    player.isMoovng = true;
                    player.SetAnimationConfiguration(0);
                    break;
                case Keys.A:
                    player.dirX = -2;
                    player.isMoovng = true;
                    player.flip = -1;
                    player.SetAnimationConfiguration(7);
                    break;
                case Keys.D:
                    player.dirX = 2;
                    player.isMoovng = true;
                    player.flip = 1;
                    player.SetAnimationConfiguration(0);
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
                        player.dirX = 0;
                        player.dirY = 0;
                        player.isMoovng = false;
                        player.isShoot = true;
                        player.SetAnimationConfiguration(5);
                        break;
                }
            }
        }
        public static void OnMouseUp(object sender, MouseEventArgs e)
        {
            player.SetAnimationConfiguration(2);
        }

        
    }
}
