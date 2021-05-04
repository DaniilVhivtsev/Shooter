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
        public Phisics_Of_Shoot shoot;

        public Form1()
        {
            DoubleBuffered = true;
            InitializeComponent();


            Button helloButton = new Button();
            helloButton.BackColor = Color.LightGray;
            helloButton.ForeColor = Color.DarkGray;
            helloButton.Location = new Point(10, 10);
            helloButton.Text = "Привет";
            this.Controls.Add(helloButton);

            helloButton.Click += (sender, args) =>
            {
                
                this.Controls.Remove(helloButton);
                timer1.Interval = 20;
                timer1.Tick += new EventHandler(Update);


                Paint += (sender, args) =>
                {
                    MapController.DrawMap(args.Graphics);
                    player.PlayAnimation(args.Graphics);
                };

                KeyDown += new KeyEventHandler(OnPress);
                KeyUp += new KeyEventHandler(OnKeyUp);
                Init();
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
                case Keys.Space:
                    player.dirX = 0;
                    player.dirY = 0;
                    player.isMoovng = false;
                    player.isShoot = true;
                    player.SetAnimationConfiguration(5);
                    break;

            }
        }

        public void Init()
        {
            MapController.Init();

            this.Width = MapController.GetWidth();
            this.Height = MapController.GetHeight();

            dwarfSheet = new Bitmap("C:\\Users\\Полли\\Source\\Repos\\DaniilVhivtsev\\Shooter\\Sprites\\Man.png");

            player = new Entity(310, 310, Hero.idleFrames, Hero.runFrames, Hero.atackFrames, Hero.deathFrames, dwarfSheet);
            

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
            timer2.Interval = 60;

            shoot = new Phisics_Of_Shoot(new Point(player.posX, player.posY));
            timer2.Tick += (e, a) =>
            {
                shoot.MakeShoot();
            };
            timer2.Start();

            Paint += (sender, args) =>
            {
                shoot.PlayShoot(args.Graphics);
            };
        }

    }
}
