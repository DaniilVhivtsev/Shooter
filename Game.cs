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
    }
}
