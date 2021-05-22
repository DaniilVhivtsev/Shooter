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

        Button StartButton;
        Button CustomizationButton;

        private bool StartPaintGame;

        public Form1()
        {

            DoubleBuffered = true;
            InitializeComponent();

            startForm();

        }

        public void startForm()
        {
            PressStartButton();

            PressCustomizationButton();
        }

        public void PressStartButton()
        {
            StartButton = new Button();
            StartButton.BackColor = Color.LightGray;
            StartButton.ForeColor = Color.Black;
            StartButton.Text = "Начать_играть";
            StartButton.Size = new Size(100, 30);
            StartButton.Location = new Point(SystemInformation.PrimaryMonitorSize.Width / 2 - StartButton.Size.Width / 2, SystemInformation.PrimaryMonitorSize.Height / 2 - StartButton.Size.Height / 2);
            this.Controls.Add(StartButton);

            StartButton.Click += (sender, args) =>
            {
                this.Controls.Remove(StartButton);
                this.Controls.Remove(CustomizationButton);
                timer1.Interval = 1;
                timer1.Tick += new EventHandler(Update);

                Button removeForm = new Button()
                {
                    BackColor = Color.LightGray,
                    ForeColor = Color.Black,
                    Text = "Вернуть_начальное_состояние формы",
                    Size = new Size(200, 30),
                    Location = new Point(SystemInformation.PrimaryMonitorSize.Width / 2, SystemInformation.PrimaryMonitorSize.Height / 2)
                };
                this.Controls.Add(removeForm);


                removeForm.Click += (e, a) =>
                {
                    this.Controls.Remove(removeForm);
                    startForm();
                    this.OnTabStopChanged(a);
                    StartPaintGame = false;
                    timer1.Stop();
                    Paint -= StartPaint;
                    return;
                };

                StartPaintGame = true;

                Paint += StartPaint;
                

                KeyDown += new KeyEventHandler(OnPress);
                KeyUp += new KeyEventHandler(OnKeyUp);

                MouseDown += new MouseEventHandler(OnPressMouse);
                MouseUp += new MouseEventHandler(OnUpMouse);
                Init();

                enemies = new List<Enemy>();
                enemies = MapController.enemies;

                EnemiesDo();

                pBar1.Visible = true;
                pBar1.Value = 100;

                label1.Visible = true;
                label1.Text = "Health";

                /*Test_makeSmallerPBar();*/
            };
        }

        public void StartPaint(Object e, PaintEventArgs args)
        {
            if (StartPaintGame)
            {
                MapController.DrawMap(args.Graphics);
                player.PlayAnimation(args.Graphics);
            }
        }


        public void PressCustomizationButton()
        {
            CustomizationButton = new Button();
            CustomizationButton.BackColor = Color.LightGray;
            CustomizationButton.ForeColor = Color.Black;
            CustomizationButton.Text = "Настройка_игры";
            CustomizationButton.Size = new Size(100, 30);
            CustomizationButton.Location = new Point(StartButton.Location.X, StartButton.Location.Y + StartButton.Size.Height + 20);
            this.Controls.Add(CustomizationButton);

            CustomizationButton.Click += (sender, args) =>
            {
                this.Controls.Remove(StartButton);
                this.Controls.Remove(CustomizationButton);
                Label speedOfShootButton = new Label()
                {
                    BackColor = Color.LightGray,
                    ForeColor = Color.Black,
                    Text = "Скорость_стрельбы_у_противников",
                    Size = new Size(100, 30),
                    Location = new Point(SystemInformation.PrimaryMonitorSize.Width / 2, SystemInformation.PrimaryMonitorSize.Height / 2)
                };
                this.Controls.Add(speedOfShootButton);
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
                    player.SetAnimationConfiguration(7);
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
            makeSmallerPBar();
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
            if (!StartPaintGame)
                return;
            var timer = new Timer();
            timer.Interval = 2000;
            
            int i = 0;

            timer.Tick += (e, a) =>
            {
                if (!StartPaintGame)
                {
                    timer.Stop();
                    return;
                }
                MakeShootByEnemy(i);
                i++;

                if (i == enemies.Count)
                    i = 0;
                /*makeSmallerPBar();*/
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
                makeSmallerPBar();
                if (!StartPaintGame)
                {
                    timer.Stop();
                    return;
                }
            };

            Paint += (sender, args) =>
            {
                if (!canDoShoot || enemies[indexOfEnemy].Death || Entity.Death || !StartPaintGame)
                {
                    timer.Stop();
                    shootsEnemy.Remove(shoot);
                    return;
                }
                else
                {
                    shoot.PlayShoot(args.Graphics);
                }

            };

            timer.Start();

        }

        public void makeSmallerPBar()
        {
            pBar1.Value = Entity.Health;
        }

        /*public void Test_makeSmallerPBar()
        {
            var timer = new Timer();
            timer.Interval = 10;
            timer.Tick += (e, a) =>
            {
                makeSmallerPBar(5);
                if (pBar1.Value == 0) timer.Stop();
            };
            timer.Start();
            
        }*/

    }
}
