using Shooter.Entites;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace Shooter.Controllers
{
    public class Phisics_Of_Shoot
    {
        public Point Position;
        public int StepX;
        public int StepY;
        public const int Speed = 10;

        public Point CursorPosition;

        public int CountOfStep;

        public bool CanMakeShootHero;
        public bool CanMakeShootEnemy;

        public Phisics_Of_Shoot(Point dir)
        {
            Position.X = dir.X - 5;
            Position.Y = dir.Y + 20;

            CursorPosition.X = Cursor.Position.X;
            CursorPosition.Y = Cursor.Position.Y - 20;
            StepX = (CursorPosition.X - Position.X) / Speed;
            StepY = (CursorPosition.Y - Position.Y) / Speed;

            CountOfStep = 0;
            CanMakeShootHero = true;
            
        }

        public Phisics_Of_Shoot(Point dir, Point person)
        {
            Position.X = dir.X - 5;
            Position.Y = dir.Y + 20;

            StepX = (person.X + 14 - Position.X) / Speed;
            StepY = (person.Y + 14 - Position.Y) / Speed;

            CountOfStep = 0;
            CanMakeShootEnemy = true;
        }

        public void PlayShoot (Graphics g)
        {
            g.DrawEllipse(new Pen(Color.Black, 5), Position.X, Position.Y, 5, 5);
            g.DrawEllipse(new Pen(Color.Black, 1), CursorPosition.X, CursorPosition.Y, 5, 5);

/*            g.DrawRectangle(new Pen(Color.Black, 5), Entity.posX * 31, Entity.posY * 31, 17, 21);
*/        }

        public void MakeShoot()
        {
            if (CountOfStep == 10)
            {
                CanMakeShootHero = false;
                return;
            }
            CountOfStep++;
            Position.X += StepX;
            Position.Y += StepY;
            KillEnemy();
            CanMakeShootHero = true;
        }

        public void KillEnemy()
        {
            for (int i = 0; i < MapController.Enemies.Count; i++)
            {
                var enemy = MapController.Enemies[i];

                if (Position.X >= enemy.Position.X  && Position.X <= enemy.Position.X + 17)
                    if (Position.Y >= enemy.Position.Y && Position.Y <= enemy.Position.Y + 21)
                    {
                        enemy.Health -= Game.HeroDamageNumericNumber;
                        if (!enemy.Death)
                        {
                            if (Game.HeroDamageNumericNumber < 20)
                                Game.Score += Game.HeroDamageNumericNumber * 3;
                            else if (Game.HeroDamageNumericNumber < 30)
                                Game.Score += Game.HeroDamageNumericNumber * 2;
                            else Game.Score += Game.HeroDamageNumericNumber;
                        }
                    }
            }
        }

        public void MakeShootEnemy()
        {
            if (CountOfStep == 10)
            {
                CanMakeShootEnemy = false;
                return;
            }

            CountOfStep++;
            Position.X += StepX;
            Position.Y += StepY;

            KillHero();
        }

        public void KillHero()
        {
            if (Position.X >= Entity.PosX && Position.X <= Entity.PosX + 20)
                if (Position.Y >= Entity.PosY && Position.Y <= Entity.PosY + 31)
                {
                    Entity.Health -= Game.EnemyDamageNumericNumber;

                    if (Game.EnemyDamageNumericNumber >= 50)
                        Game.Score -= Game.EnemyDamageNumericNumber / 2;
                    else if (Game.EnemyDamageNumericNumber >= 35)
                        Game.Score -= Game.EnemyDamageNumericNumber / 3;
                    else Game.Score -= Game.EnemyDamageNumericNumber;

                    CanMakeShootEnemy = false;
                    return;
                }

            CanMakeShootEnemy = true;
        }
    }
}
