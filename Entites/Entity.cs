using System;
using System.Collections.Generic;
using System.Drawing;
using System.Text;

namespace Shooter.Entites
{
    public class Entity
    {
        public static int posX;
        public static int posY;

        public int dirX;
        public int dirY;
        public bool isMoovng;
        public bool isShoot;

        public int flip;

        public int currentAnimation;
        public int currentFrame;
        public int currentLimit;

        public int idleFrames;
        public int runFrames;
        public int atackFrames;
        public int deathFrames;

        public int size;

        public Image spriteSheet;

        public static bool Death;

        private static int health;
        public static int Health
        {
            get
            {
                return health;
            }
            set
            {
                var form1 = new Form1();
                form1.makeSmallerPBar(health - value);
                health = value;
                if (health <= 0)
                    Death = true;
            }
        }

        public Entity(int positionX, int positionY, int idleFrames, int runFrames, int atackFrames, int deathFrames, Image spriteSheet)
        {
            posX = positionX;
            posY = positionY;
            this.idleFrames = idleFrames;
            this.runFrames = runFrames;
            this.atackFrames = atackFrames;
            this.deathFrames = deathFrames;
            this.spriteSheet = spriteSheet;
            size = 31;
            currentAnimation = 2;
            currentFrame = 0;
            currentLimit = idleFrames;
            flip = 1;
            Health = 100;
            Death = false;
        }

        public void Move ()
        {
            posX += dirX;
            posY += dirY;
        }
        public void PlayAnimation(Graphics g)
        {
            if (currentFrame < currentLimit - 1)
                currentFrame++;
            else currentFrame = 0;

            g.DrawImage(spriteSheet, new Rectangle(new Point(posX - flip*size/2, posY), new Size(flip*size, size)), 32 * currentFrame, 32 * currentAnimation, size, size, GraphicsUnit.Pixel);
        }

        public void SetAnimationConfiguration(int currentAnimation)
        {
            this.currentAnimation = currentAnimation;

            switch (currentAnimation)
            {
                case 2:
                    currentLimit = idleFrames;
                    break;
                case 0:
                    currentLimit = runFrames;
                    break;
                case 5:
                    currentLimit = atackFrames;
                    break;
                case 4:
                    currentLimit = deathFrames;
                    break;

            }
        }
    }
}
