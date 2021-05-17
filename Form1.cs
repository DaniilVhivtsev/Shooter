using Shooter.Controllers;
using Shooter.Entites;
using Shooter.Model;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Shooter
{
    public partial class Form1 : Form
    {
        public Image dwarfSheet;
        public Entity player;

        private List<Enemy> enemies;

        public List<Phisics_Of_Shoot> shoots;
        public List<Phisics_Of_Shoot> shootsEnemy;

        public Form1()
        {
            
            DoubleBuffered = true;
            InitializeComponent();

            

            Button helloButton = new Button();
            helloButton.BackColor = Color.LightGray;
            helloButton.ForeColor = Color.DarkGray;
            helloButton.Location = new Point(SystemInformation.PrimaryMonitorSize.Width / 2, SystemInformation.PrimaryMonitorSize.Height / 2);
            helloButton.Text = "Привет";
            this.Controls.Add(helloButton);

            helloButton.Click += (sender, args) =>
            {
                
                this.Controls.Remove(helloButton);
                timer1.Interval = 1;
                timer1.Tick += new EventHandler(Update);


                Paint += (sender, args) =>
                {
                    MapController.DrawMap(args.Graphics);
                    player.PlayAnimation(args.Graphics);
                };

                KeyDown += new KeyEventHandler(OnPress);
                KeyUp += new KeyEventHandler(OnKeyUp);

                MouseDown += new MouseEventHandler(OnPressMouse);
                MouseUp += new MouseEventHandler(OnUpMouse);
                Init();

                enemies = new List<Enemy>();
                enemies = MapController.enemies;

                EnemiesDo();
            };
        }


        public void OnKeyUp (object sender, KeyEventArgs e)
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

        public void OnPress(object sender, KeyEventArgs e)
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
                    player.SetAnimationConfiguration(0);
                    break;
                case Keys.D:
                    player.dirX = 2;
                    player.isMoovng = true;
                    player.flip = 1;
                    player.SetAnimationConfiguration(0);
                    break;
                /*case Keys.Space:
                    player.dirX = 0;
                    player.dirY = 0;
                    player.isMoovng = false;
                    player.isShoot = true;
                    player.SetAnimationConfiguration(5);
                    break;*/
            }
        }

        public void OnPressMouse(object sender, MouseEventArgs e)
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

        public void OnUpMouse (object ender, MouseEventArgs e)
        {
            player.SetAnimationConfiguration(2);
        }

        public void Init()
        {
            MapController.Init();

            this.Width = MapController.GetWidth();
            this.Height = MapController.GetHeight();

            dwarfSheet = new Bitmap(Path.Combine(new DirectoryInfo(Directory.GetCurrentDirectory()).Parent.Parent.Parent.FullName.ToString(), "Sprites\\Man.png"));

            player = new Entity(310, 310, Hero.idleFrames, Hero.runFrames, Hero.atackFrames, Hero.deathFrames, dwarfSheet);

            shoots = new List<Phisics_Of_Shoot>();
            shootsEnemy = new List<Phisics_Of_Shoot>();

            timer1.Start();
        }

        public void Update(object sender, EventArgs e)
        {
            if (!PhysicsController.isCollide(player, new Point(player.dirX, player.dirY)))
            {
                if (player.isMoovng)
                    player.Move();
                if (player.isShoot)
                {
                    Shooting(sender, e);
                }
            }
            Invalidate();
        }

        public void Shooting (object sender, EventArgs args)
        {
            var timer2 = new Timer();
            timer2.Interval = 1;

            var shoot = new Phisics_Of_Shoot(new Point(Entity.posX, Entity.posY));
            shoots.Add(shoot);

            var canDoShoot = true;
            timer2.Tick += (e, a) =>
            {
                canDoShoot = shoot.MakeShoot();
            };

            timer2.Start();
            
            Paint += (sender, args) =>
            {
                if (!canDoShoot)
                {
                    timer2.Stop();
                    shoots.Remove(shoot);
                }
                else
                {
                    shoot.PlayShoot(args.Graphics);
                }

            };

            player.isShoot = false;
        }


        public void EnemiesDo()
        {
            var timer = new Timer();
            timer.Interval = 1000;
            
            int i = 0;

            timer.Tick += (e, a) =>
            {
                MakeShootByEnemy(i);
                i++;

                if (i == enemies.Count)
                    i = 0;
            };
            timer.Start();
        }

        public void MakeShootByEnemy(int indexOfEnemy)
        {
            var timer = new Timer();
            timer.Interval = 100;

            var shoot = new Phisics_Of_Shoot(new Point(enemies[indexOfEnemy].Position.X, enemies[indexOfEnemy].Position.Y), new Point(Entity.posX, Entity.posY));
            shootsEnemy.Add(shoot);

            var canDoShoot = true;
            timer.Tick += (e, a) =>
            {
                canDoShoot = shoot.MakeShootEnemy();
            };

            Paint += (sender, args) =>
            {
                if (!canDoShoot)
                {
                    timer.Stop();
                    shootsEnemy.Remove(shoot);
                }
                else
                {
                    shoot.PlayShoot(args.Graphics);
                }

            };

            timer.Start();

        }

    }
}
