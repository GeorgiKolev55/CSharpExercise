using System;
using System.Collections.Generic;
using System.Text;
using ViceCity.Models.Guns.Contracts;

namespace ViceCity.Models.Guns
{
    public abstract class Gun : IGun
    {
        private string name;
        private int bulletsPerBarrel;
        private int totalBullets;
        private bool canFire;
        public Gun(string name, int bulletsPerBarrel, int totalBullets)
        {
            Name = name;
            BulletsPerBarrel = bulletsPerBarrel;
            TotalBullets = totalBullets;
        }
        public string Name
        {
            get { return this.name; }
            private set
            {
                if (string.IsNullOrEmpty(value))
                {
                    throw new ArgumentException("Name cannot be null or a white space!");
                }
                this.name = value;
            }
        }


        public int BulletsPerBarrel
        {
            get { return this.bulletsPerBarrel; }
            protected set
            {
                if (value<0)
                {
                    throw new ArgumentException("Bullets cannot be below zero!");
                }
                this.bulletsPerBarrel = value;
            }
        }


        public int TotalBullets
        {
            get { return this.totalBullets; }
            protected set
            {
                if (value<0)
                {
                    throw new ArgumentException("Total bullets cannot be below zero!");
                }
                this.totalBullets = value;
            }
        }

        public bool CanFire { get { return this.canFire; }
            private set
            {
                if (BulletsPerBarrel==0)
                {
                    value = false;
                }
                else
                {
                    value = true;
                }
                this.canFire = value;
            }
        }

        public abstract int Fire();
        
    }
}
