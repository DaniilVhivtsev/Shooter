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
        public Point position;
        public int stepX;
        public int stepY;
        public const int speed = 10;

        public Point cursorPosition;

        public int countOfStep;

        public bool CanMakeShootHero;
        public bool CanMakeShootEnemy;

        public Phisics_Of_Shoot(Point dir)
        {
            position.X = dir.X - 5;
            position.Y = dir.Y + 20;

            cursorPosition.X = Cursor.Position.X;
            cursorPosition.Y = Cursor.Position.Y - 20;
            stepX = (cursorPosition.X - position.X) / speed;
            stepY = (cursorPosition.Y - position.Y) / speed;

            countOfStep = 0;
            CanMakeShootHero = true;
            
        }

        public Phisics_Of_Shoot(Point dir, Point person)
        {
            position.X = dir.X - 5;
            position.Y = dir.Y + 20;

            stepX = (person.X + 14 - position.X) / speed;
            stepY = (person.Y + 14 - position.Y) / speed;

            countOfStep = 0;
            CanMakeShootEnemy = true;
        }

        public void PlayShoot (Graphics g)
        {
            g.DrawEllipse(new Pen(Color.Black, 5), position.X, position.Y, 5, 5);
            g.DrawEllipse(new Pen(Color.Black, 1), cursorPosition.X, cursorPosition.Y, 5, 5);

/*            g.DrawRectangle(new Pen(Color.Black, 5), Entity.posX * 31, Entity.posY * 31, 17, 21);
*/        }

        public void MakeShoot()
        {
            if (countOfStep == 10)
            {
                CanMakeShootHero = false;
                return;
            }
            countOfStep++;
            position.X += stepX;
            position.Y += stepY;
            KillEnemy();
            CanMakeShootHero = true;
        }

        public void KillEnemy()
        {
            for (int i = 0; i < MapController.enemies.Count; i++)
            {
                var enemy = MapController.enemies[i];

                if (position.X >= enemy.Position.X  && position.X <= enemy.Position.X + 17)
                    if (position.Y >= enemy.Position.Y && position.Y <= enemy.Position.Y + 21)
                    {
                        enemy.Health -= Game.heroDamageNumericNumber;
                        if (!enemy.Death)
                        {
                            if (Game.heroDamageNumericNumber < 20)
                                Game.Score += Game.heroDamageNumericNumber * 3;
                            else if (Game.heroDamageNumericNumber < 30)
                                Game.Score += Game.heroDamageNumericNumber * 2;
                            else Game.Score += Game.heroDamageNumericNumber;
                        }
                    }
            }
        }

        public void MakeShootEnemy()
        {
            if (countOfStep == 10)
            {
                CanMakeShootEnemy = false;
                return;
            }

            countOfStep++;
            position.X += stepX;
            position.Y += stepY;

            KillHero();
        }

        public void KillHero()
        {
            if (position.X >= Entity.posX && position.X <= Entity.posX + 20)
                if (position.Y >= Entity.posY && position.Y <= Entity.posY + 31)
                {
                    Entity.Health -= Game.enemyDamageNumericNumber;

                    if (Game.enemyDamageNumericNumber >= 50)
                        Game.Score -= Game.enemyDamageNumericNumber / 2;
                    else if (Game.enemyDamageNumericNumber >= 35)
                        Game.Score -= Game.enemyDamageNumericNumber / 3;
                    else Game.Score -= Game.enemyDamageNumericNumber;

                    CanMakeShootEnemy = false;
                    return;
                }

            CanMakeShootEnemy = true;
        }
    }
}
