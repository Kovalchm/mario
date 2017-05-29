﻿using Global;
using Mario.Properties;
using System.Collections.Generic;
using System.Drawing;

namespace GameEngine
{
    class Player : Unit, Jumpable
    {
        int StartPoint;
        bool isInJump;


        public Player(Coordinates position):base(position)
        {
            isInJump = true;
            this.animator = new Animator(new List<Image>{
                new Bitmap(Resources.mario1),
                new Bitmap(Resources.mario2),
                new Bitmap(Resources.mario3),
            }, 25);
            this.priority = Settings.Default.playerPriority;
        }

        public override Image getTexture()
        {
            if(currentSpeed.getHorizontalSpeed() == 0)
            {
                animator.reset();
                return animator.getCurrentFrame();
            }
            return animator.getNextFrame();
        }


        public void jump()
        {
            if (!isInJump)
            {
                setVerticalSpeed(Settings.Default.speedOfJump);
                StartPoint = GetPosition().bottomLeft.Y;
                isInJump = true;
            }
        }


        public void inJump(bool b)
        {
            isInJump = b;
        }

        public void limitJump()
        {
            if(isInJump)
            {
                if(GetPosition().bottomLeft.Y > StartPoint + (position.topRight.Y - position.bottomLeft.Y) * Settings.Default.heightOfJump)
                {
                    setVerticalSpeed(0);
                }
            }
            else
            {
                setVerticalSpeed(0);
            }
        }
    }
}
