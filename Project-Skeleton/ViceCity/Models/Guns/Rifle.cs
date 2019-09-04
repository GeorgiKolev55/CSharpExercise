using System;
using System.Collections.Generic;
using System.Text;

namespace ViceCity.Models.Guns
{
    public class Rifle : Gun
    {
        private const int bulletsPerBarrel = 50;
        private const int totalBullets = 500;
        private int countBulletsShoted = 0;
        public Rifle(string name) : base(name, bulletsPerBarrel, totalBullets)
        {
        }
        public override int Fire()
        {

            this.BulletsPerBarrel -= 5;
            if (this.BulletsPerBarrel == 0 && this.TotalBullets > 0)
            {
                this.BulletsPerBarrel = bulletsPerBarrel;
                this.TotalBullets -= bulletsPerBarrel;
            }
            return 5;

        }
    }
}
