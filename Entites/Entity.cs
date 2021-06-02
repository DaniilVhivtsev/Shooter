using System;
using System.Collections.Generic;
using System.Drawing;
using System.Text;

namespace Shooter.Entites
{
    public class Entity
    {
        public static int PosX;
        public static int PosY;

        public int DirX
        {
            get; private set;
        }
        public int DirY
        {
            get; private set;
        }

        public bool IsMoovng;
        public bool IsShoot;

        public bool CanMakeOtherShoot;

        public int Flip;

        public int CurrentAnimation;
        public int CurrentFrame;
        public int CurrentLimit;

        public int IdleFrames;
        public int RunFrames;
        public int AtackFrames;
        public int DeathFrames;

        public int Size;

        public Image SpriteSheet;

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

                if (value <= 0)
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
            PosX = positionX;
            PosY = positionY;
            this.IdleFrames = idleFrames;
            this.RunFrames = runFrames;
            this.AtackFrames = atackFrames;
            this.DeathFrames = deathFrames;
            this.SpriteSheet = spriteSheet;
            Size = 31;
            CurrentAnimation = 2;
            CurrentFrame = 0;
            CurrentLimit = idleFrames;
            Flip = 1;

            Health = 100;
            Death = false;
            CanMakeOtherShoot = true;
        }

        public void Move ()
        {
            if (!Death)
            {
                PosX += DirX;
                PosY += DirY;
            }
        }

        public void SetAnimationConfiguration(int currentAnimation)
        {
            if (Death)
                currentAnimation = 4;
            
            this.CurrentAnimation = currentAnimation;

            switch (currentAnimation)
            {
                case 2:
                    CurrentLimit = IdleFrames;
                    break;
                case 0:
                    CurrentLimit = RunFrames;
                    break;
                case 5:
                    CurrentLimit = AtackFrames;
                    break;
                case 4:
                    CurrentLimit = DeathFrames;
                    break;
                case 7:
                    CurrentLimit = RunFrames;
                    break;

            }
        }

        public void OnPressMoveUp()
        {
            DirY = -2;
            IsMoovng = true;
            SetAnimationConfiguration(0);
        }

        public void OnPressMoveDown()
        {
            DirY = 2;
            IsMoovng = true;
            SetAnimationConfiguration(0);
        }

        public void OnPressMoveLeft()
        {
            DirX = -2;
            IsMoovng = true;
            Flip = -1;
            SetAnimationConfiguration(7);
        }
        public void OnPressMoveRight()
        {
            DirX = 2;
            IsMoovng = true;
            Flip = 1;
            SetAnimationConfiguration(0);
        }

        public void OnMousePressLeftButton()
        {
            DirX = 0;
            DirY = 0;
            IsMoovng = false;
            IsShoot = true;
            SetAnimationConfiguration(5);
        }

        public void OnKeyUpMakeDirYNull()
        {
            DirY = 0;
        }
        public void OnKeyUpMakeDirXNull()
        {
            DirX = 0;
        }

        public void MakeIsMoovinAndIsShootNull()
        {
            if (DirX == 0 && DirY == 0)
            {
                IsMoovng = false;
                IsShoot = false;
                SetAnimationConfiguration(2);
            }
        }
    }
}
