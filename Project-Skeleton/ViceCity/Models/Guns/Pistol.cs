using System;
using System.Collections.Generic;
using System.Text;

namespace ViceCity.Models.Guns
{
    public class Pistol : Gun
    {
        private const int bulletsPerBarrel = 10;
        private const int totalBullets = 100;
        private int countBulletsShoted=0;
        public Pistol(string name) : base(name, bulletsPerBarrel, totalBullets)
        {
            
        }
        public override int Fire()
        {

            this.BulletsPerBarrel--;
            if (this.BulletsPerBarrel == 0 && this.TotalBullets > 0)
            {
                this.BulletsPerBarrel = bulletsPerBarrel;
                this.TotalBullets -= bulletsPerBarrel;
            }
            return 1;

        }
    }
}
