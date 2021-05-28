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
        Button StartButton;
        Button CustomizationButton;
        Button ResultsButton;

        public Timer timer1;


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

            PressResultsButton();
        }

        public void PressStartButton()
        {
            StartButtoninstructions();

            StartButton.Click += (sender, args) =>
            {
                this.Controls.Remove(StartButton);
                this.Controls.Remove(CustomizationButton);
                timer1 = new Timer();
                timer1.Interval = 1;
                timer1.Tick += new EventHandler(Update);

                RemoveButtonFromGame();

                Paint += Game.StartPaint;

                ButtonForGameInstructions();

                Game.Init();
                timer1.Start();
                EnemiesDo();

                pBarInstructions();
                labelsScoreInstructions();
                PlayerNameLabelTextBox();
                buttonNameConfirmation.Visible = true;
            };
        }
        private void pBarInstructions()
        {
            pBar1.Visible = true;
            pBar1.Value = 100;

            label1.Visible = true;
            label1.Text = "Health";
        }
        private void labelsScoreInstructions()
        {
            labelScore.Text = "Score:";
            labelScoreNumber.Text = Game.Score.ToString();

            labelScore.Visible = true;
            labelScoreNumber.Visible = true;

            timer1.Tick += UpdateScore;
        }
        private void PlayerNameLabelTextBox()
        {
            labelPlayerName.Visible = true;
            textBoxPlayerName.Visible = true;
            labelPlayerName.Text = "Ваш ник: ";
        }
        private void ButtonForGameInstructions()
        {
            KeyDown += new KeyEventHandler(Game.OnPress);
            KeyUp += new KeyEventHandler(Game.OnKeyUp);
            MouseDown += new MouseEventHandler(Game.OnMousePress);
            MouseUp += new MouseEventHandler(Game.OnMouseUp);
        }

        private void RemoveButtonFromGame()
        {
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
                JsonDataActivities.MakeJsonFile(new Person { Name = textBoxPlayerName.Text, Score = Game.Score});
                this.Controls.Remove(removeForm);
                startForm();
                this.OnTabStopChanged(a);
                timer1.Stop();
                Paint -= Game.StartPaint;
                pBar1.Visible = false;
                label1.Visible = false;
                labelScore.Visible = false;
                labelScoreNumber.Visible = false;
                labelPlayerName.Visible = false;
                textBoxPlayerName.Visible = false;
                buttonNameConfirmation.Visible = false;
                Game.Score = 0;
                return;
            };
        }

        private void StartButtoninstructions()
        {
            StartButton = new Button();
            StartButton.BackColor = Color.LightGray;
            StartButton.ForeColor = Color.Black;
            StartButton.Text = "Начать_играть";
            StartButton.Size = new Size(100, 30);
            StartButton.Location = new Point(SystemInformation.PrimaryMonitorSize.Width / 2 - StartButton.Size.Width / 2, SystemInformation.PrimaryMonitorSize.Height / 2 - StartButton.Size.Height / 2);
            this.Controls.Add(StartButton);
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
                Label speedOfShootButtonHero = new Label()
                {
                    BackColor = Color.LightGray,
                    ForeColor = Color.Black,
                    Text = "Скорость стрельбы у героя",
                    Size = new Size(100, 30),
                    Location = new Point(SystemInformation.PrimaryMonitorSize.Width / 2, SystemInformation.PrimaryMonitorSize.Height / 2)
                };
                this.Controls.Add(speedOfShootButtonHero);

                NumericUpDown speedOfShootButtonHeroNumeric = new NumericUpDown()
                {
                    BackColor = Color.LightGray,
                    ForeColor = Color.Black,
                    Size = new Size(100, 30),
                    Location = new Point(speedOfShootButtonHero.Location.X + speedOfShootButtonHero.Width + 10, speedOfShootButtonHero.Location.Y),
                    Value = Game.speedOfShootButtonHeroNumericNumber,
                    Maximum = 10,
                    Minimum = 0
                };
                this.Controls.Add(speedOfShootButtonHeroNumeric);
                speedOfShootButtonHeroNumeric.ValueChanged += (e, a) =>
                {
                    Game.speedOfShootButtonHeroNumericNumber = int.Parse(speedOfShootButtonHeroNumeric.Value.ToString());
                };

                Label speedOfShootButtonEnemy = new Label()
                {
                    BackColor = Color.LightGray,
                    ForeColor = Color.Black,
                    Text = "Скорость стрельбы у противников",
                    Size = new Size(100, 30),
                    Location = new Point(speedOfShootButtonHero.Location.X, speedOfShootButtonHero.Location.Y + speedOfShootButtonHero.Height + 20)
                };
                this.Controls.Add(speedOfShootButtonEnemy);

                NumericUpDown speedOfShootButtonEnemyNumeric = new NumericUpDown()
                {
                    BackColor = Color.LightGray,
                    ForeColor = Color.Black,
                    Size = new Size(100, 30),
                    Location = new Point(speedOfShootButtonEnemy.Location.X + speedOfShootButtonEnemy.Width + 10, speedOfShootButtonEnemy.Location.Y),
                    Value = Game.speedOfShootButtonEnemyNumericNumber,
                    Maximum = 10,
                    Minimum = 0
                };
                this.Controls.Add(speedOfShootButtonEnemyNumeric);
                speedOfShootButtonEnemyNumeric.ValueChanged += (e, a) =>
                {
                    Game.speedOfShootButtonEnemyNumericNumber = int.Parse(speedOfShootButtonEnemyNumeric.Value.ToString());
                };


                Label numberOfEnemies = new Label()
                {
                    BackColor = Color.LightGray,
                    ForeColor = Color.Black,
                    Text = "Количество" + " " +"противников",
                    Size = new Size(100, 30),
                    Location = new Point(speedOfShootButtonHero.Location.X, speedOfShootButtonEnemy.Location.Y + speedOfShootButtonEnemy.Height + 20)
                };
                this.Controls.Add(numberOfEnemies);

                NumericUpDown numberOfEnemiesNumeric = new NumericUpDown()
                {
                    BackColor = Color.LightGray,
                    ForeColor = Color.Black,
                    Size = new Size(100, 30),
                    Location = new Point(numberOfEnemies.Location.X + numberOfEnemies.Width + 10, numberOfEnemies.Location.Y),
                    Value = Game.numberOfEnemiesNumericNumber,
                    Maximum = 5,
                    Minimum = 0
                };
                this.Controls.Add(numberOfEnemiesNumeric);
                numberOfEnemiesNumeric.ValueChanged += (e, a) =>
                {
                    Game.numberOfEnemiesNumericNumber = int.Parse(numberOfEnemiesNumeric.Value.ToString());
                };

                Label speedOfEnemy = new Label()
                {
                    BackColor = Color.LightGray,
                    ForeColor = Color.Black,
                    Text = "Скорость передвижения противников",
                    Size = new Size(100, 30),
                    Location = new Point(speedOfShootButtonHero.Location.X, numberOfEnemies.Location.Y + numberOfEnemies.Height + 20)
                };
                this.Controls.Add(speedOfEnemy);

                NumericUpDown speedOfEnemyNumeric = new NumericUpDown()
                {
                    BackColor = Color.LightGray,
                    ForeColor = Color.Black,
                    Size = new Size(100, 30),
                    Location = new Point(speedOfEnemy.Location.X + speedOfEnemy.Width + 10, speedOfEnemy.Location.Y),
                    Value = Game.speedOfEnemyNumericNumber,
                    Maximum = 10,
                    Minimum = 0
                };
                this.Controls.Add(speedOfEnemyNumeric);
                speedOfEnemyNumeric.ValueChanged += (e, a) =>
                {
                    Game.speedOfEnemyNumericNumber = int.Parse(speedOfEnemyNumeric.Value.ToString());
                };


                Label enemyDamage = new Label()
                {
                    BackColor = Color.LightGray,
                    ForeColor = Color.Black,
                    Text = "Урон от противника",
                    Size = new Size(100, 30),
                    Location = new Point(speedOfShootButtonHero.Location.X, speedOfEnemy.Location.Y + speedOfEnemy.Height + 20)
                };
                this.Controls.Add(enemyDamage);

                NumericUpDown enemyDamageNumeric = new NumericUpDown()
                {
                    BackColor = Color.LightGray,
                    ForeColor = Color.Black,
                    Size = new Size(100, 30),
                    Location = new Point(enemyDamage.Location.X + enemyDamage.Width + 10, enemyDamage.Location.Y),
                    Value = Game.enemyDamageNumericNumber,
                    Maximum = 50,
                    Minimum = 0
                };
                this.Controls.Add(enemyDamageNumeric);
                enemyDamageNumeric.ValueChanged += (e, a) =>
                {
                    Game.enemyDamageNumericNumber = int.Parse(enemyDamageNumeric.Value.ToString());
                };

                Label heroDamage = new Label()
                {
                    BackColor = Color.LightGray,
                    ForeColor = Color.Black,
                    Text = "Урон от героя",
                    Size = new Size(100, 30),
                    Location = new Point(enemyDamage.Location.X, enemyDamage.Location.Y + enemyDamage.Height + 20)
                };
                this.Controls.Add(heroDamage);

                NumericUpDown heroDamageNumeric = new NumericUpDown()
                {
                    BackColor = Color.LightGray,
                    ForeColor = Color.Black,
                    Size = new Size(100, 30),
                    Location = new Point(heroDamage.Location.X + heroDamage.Width + 10, heroDamage.Location.Y),
                    Value = Game.heroDamageNumericNumber,
                    Maximum = 100,
                    Minimum = 0
                };
                this.Controls.Add(heroDamageNumeric);
                heroDamageNumeric.ValueChanged += (e, a) =>
                {
                    Game.heroDamageNumericNumber = int.Parse(heroDamageNumeric.Value.ToString());
                };

                Button removeForm = new Button()
                {
                    BackColor = Color.LightGray,
                    ForeColor = Color.Black,
                    Text = "Вернуть_начальное_состояние формы",
                    Size = new Size(200, 30),
                    Location = new Point(heroDamage.Location.X, heroDamage.Location.Y + heroDamage.Height + 20)
                };
                this.Controls.Add(removeForm);

                removeForm.Click += (e, a) =>
                {
                    this.Controls.Remove(removeForm);
                    this.Controls.Remove(speedOfShootButtonHero);
                    this.Controls.Remove(speedOfShootButtonEnemy);
                    this.Controls.Remove(numberOfEnemies);
                    this.Controls.Remove(speedOfEnemy);
                    this.Controls.Remove(enemyDamage);
                    this.Controls.Remove(heroDamage);

                    this.Controls.Remove(speedOfShootButtonHeroNumeric);
                    this.Controls.Remove(speedOfShootButtonEnemyNumeric);
                    this.Controls.Remove(numberOfEnemiesNumeric);
                    this.Controls.Remove(speedOfEnemyNumeric);
                    this.Controls.Remove(enemyDamageNumeric);
                    this.Controls.Remove(heroDamageNumeric);

                    startForm();
                    this.OnTabStopChanged(a);
                    return;
                };

            };
        }      
        public void PressResultsButton()
        {
            ResultsButton = new Button();
            ResultsButton.BackColor = Color.LightGray;
            ResultsButton.ForeColor = Color.Black;
            ResultsButton.Text = "Результаты";
            ResultsButton.Size = new Size(100, 30);
            ResultsButton.Location = new Point(StartButton.Location.X, CustomizationButton.Location.Y + CustomizationButton.Size.Height + 20);
            this.Controls.Add(ResultsButton);

            ResultsButton.Click += (e, a) =>
            {
                this.Controls.Remove(StartButton);
                this.Controls.Remove(CustomizationButton);
                this.Controls.Remove(ResultsButton);
                JsonDataActivities.ReadJsonFile();

                var list = new List<InstrumentsForResults>();
                var firstElement = true;
                foreach(var person in JsonDataActivities.listScoreData)
                {
                    var name = new Label();
                    if (firstElement)
                    {
                        name = new Label()
                        {
                            BackColor = Color.LightGray,
                            ForeColor = Color.Black,
                            Text = person.Name,
                            Size = new Size(100, 30),
                            Location = new Point(SystemInformation.PrimaryMonitorSize.Width / 2 - 100, SystemInformation.PrimaryMonitorSize.Height / 2 - 30)
                        };
                        this.Controls.Add(name);
                        firstElement = false;
                    } else
                    {
                        name = new Label()
                        {
                            BackColor = Color.LightGray,
                            ForeColor = Color.Black,
                            Text = person.Name,
                            Size = new Size(100, 30),
                            Location = new Point(list[list.Count - 1].Name.Location.X, list[list.Count - 1].Name.Location.Y + 50)
                        };
                        this.Controls.Add(name);
                    }
                    var score = new Label()
                    {
                        BackColor = Color.LightGray,
                        ForeColor = Color.Black,
                        Text = person.Score.ToString(),
                        Size = new Size(100, 30),
                        Location = new Point(name.Location.X + name.Width + 10, name.Location.Y)
                    };
                    this.Controls.Add(score);

                    var removeButton = new Button()
                    {
                        BackColor = Color.LightGray,
                        ForeColor = Color.Black,
                        Text = "Remove score",
                        Size = new Size(100, 30),
                        Location = new Point(score.Location.X + name.Width + 10, name.Location.Y)
                    };

                    removeButton.Click += (e, a) =>
                    {
                        JsonDataActivities.listScoreData.Remove(person);
                        JsonDataActivities.FirstStepToMakeJsonFile();
                    };
                    this.Controls.Add(removeButton);

                    list.Add(new InstrumentsForResults { Name = name, Score = score, Remove = removeButton });

                }
            };
        }

        public void Update(object sender, EventArgs e)
        {

            if (!PhysicsController.isCollide(Game.player, new Point(Game.player.dirX, Game.player.dirY)))
            {
                if (Game.player.isMoovng)
                    Game.player.Move();
                if (Game.player.isShoot && Game.player.CanMakeOtherShoot)
                {
                    Game.player.CanMakeOtherShoot = false;
                    Shooting(sender, e);
                }
            }
            makeSmallerPBar();
            Invalidate();
        }
        public void Shooting (object sender, EventArgs args)
        {

            var shoot = new Phisics_Of_Shoot(new Point(Entity.posX, Entity.posY));
            Game.shoots.Add(shoot);

            var x = 0;
            timer1.Tick += tickShootOfEnemy;

            Paint += makePaintEnemyShoot;

            Game.player.isShoot = false;


            void tickShootOfEnemy (Object e, EventArgs args)
            {
                shoot.MakeShoot();
                if (x == 10)
                    Game.player.CanMakeOtherShoot = true;
                x++;
            }

            void makePaintEnemyShoot (Object e, PaintEventArgs args)
            {
                if (!shoot.CanMakeShootHero)
                {
                    timer1.Tick -= tickShootOfEnemy;
                    Game.shoots.Remove(shoot);
                    Paint -= makePaintEnemyShoot;
                }
                else
                {
                    shoot.PlayShoot(args.Graphics);
                }
            }
        }

        public void EnemiesDo()
        { 
            int i = 0;
            var x = 0;

            timer1.Tick += (e, a) =>
            {
                if (x == 30 && Game.numberOfEnemiesNumericNumber != 0)
                {
                    MakeShootByEnemy(i);
                    MoveEnemy(i);
                    i++;
                    if (i == Game.numberOfEnemiesNumericNumber)
                        i = 0;
                    x = 0;
                }
                x++;
            };
        }

        public void MakeShootByEnemy(int indexOfEnemy)
        {
            var shoot = new Phisics_Of_Shoot(new Point(Game.enemies[indexOfEnemy].Position.X, Game.enemies[indexOfEnemy].Position.Y), new Point(Entity.posX, Entity.posY));
            Game.shootsEnemy.Add(shoot);


            timer1.Tick += TickOfShootByEnemy;

            Paint += (sender, args) =>
            {
                if (!shoot.CanMakeShootEnemy || Game.enemies[indexOfEnemy].Death || Entity.Death )
                {
                    timer1.Tick -= TickOfShootByEnemy;
                    Game.shootsEnemy.Remove(shoot);
                    return;
                }
                else
                {
                    
                    shoot.PlayShoot(args.Graphics);
                }
            };

            void TickOfShootByEnemy(Object e, EventArgs args)
            {
                shoot.MakeShootEnemy();
                makeSmallerPBar();
            }
        }

        public void MoveEnemy(int index)
        {
            var i = 0;
            timer1.Tick += (e, a) =>
            {
                if (i == 10 && !Game.enemies[index].Death && !Entity.Death)
                {
                    Game.enemies[index].EnemyMovement(new Point(Entity.posX, Entity.posY));
                    i = 0;
                }
                else i++;
            };
        }
        public void makeSmallerPBar()
        {
            pBar1.Value = Entity.Health;
        }
        public void UpdateScore(object sender, EventArgs e)
        {
            labelScoreNumber.Text = Game.Score.ToString();
        }

        private void buttonNameConfirmation_Click(object sender, EventArgs e)
        {
            textBoxPlayerName.Enabled = false;
        }
    }
}
