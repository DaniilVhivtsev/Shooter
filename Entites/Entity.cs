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
        public bool CanMakeOtherShoot;

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

                if (value == 0)
                {
                    Death = true;
                    health = value;
                }
                else if (value > 0)
                {
                    health = value;
                }
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
            CanMakeOtherShoot = true;
        }

        public void Move ()
        {
            if (!Death)
            {
                posX += dirX;
                posY += dirY;
            }
        }
        public void PlayAnimation(Graphics g)
        {
            if (currentFrame < currentLimit - 1)
                currentFrame++;
            else if (!Death) 
                currentFrame = 0;

            g.DrawImage(spriteSheet, new Rectangle(new Point(posX, posY), new Size(size, size)), 32 * currentFrame, 32 * currentAnimation, size, size, GraphicsUnit.Pixel);
        }

        public void SetAnimationConfiguration(int currentAnimation)
        {
            if (Death)
                currentAnimation = 4;
            
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
                case 7:
                    currentLimit = runFrames;
                    break;

            }
        }
    }
}
