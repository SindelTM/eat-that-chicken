﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EatThatChicken.GameObjects.Birds
{
    public class SkinyBird: Bird
    {
        private const int SkinnyBirdHealth = 1;

        protected SkinyBird(int health)
        {
            this.Health = health;
        }

        public SkinyBird()
            :this(SkinnyBirdHealth)
        {
        }

        protected int Health { get; set; }


        public override bool IsAlive
        {
            get
            {
                return this.Health > 0;
            }
            set
            {
                if (!value)
                {
                    --this.Health;
                }
            }
        }



    }
}