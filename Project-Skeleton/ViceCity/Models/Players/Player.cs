using System;
using System.Collections.Generic;
using System.Text;
using ViceCity.Models.Guns.Contracts;
using ViceCity.Models.Players.Contracts;
using ViceCity.Repositories;
using ViceCity.Repositories.Contracts;

namespace ViceCity.Models.Players
{
    public abstract class Player : IPlayer
    {
        private string name;
        private int lifePoints;
        private IRepository<IGun> gunRepository; 
        
        public Player(string name, int lifePoints)
        {
            gunRepository = new GunRepository();
            Name = name;
            LifePoints = lifePoints;
        }
        public string Name
        {
            get { return this.name; }
            private set
            {
                if (string.IsNullOrWhiteSpace(value))
                {
                    throw new ArgumentNullException("Player's name cannot be null or a whitespace!");
                }
                this.name = value;
            }
        }

        public bool IsAlive { get; private set; }

        public IRepository<IGun> GunRepository => this.gunRepository;

        public int LifePoints
        {
            get { return this.lifePoints; }
            private set
            {
                if (value<0)
                {
                    IsAlive = false;
                    throw new ArgumentException("Player life points cannot be below zero!");
                }
                IsAlive = true;
                this.lifePoints = value;
            }
        }

        public void TakeLifePoints(int points)
        {
            if (LifePoints-points>=0)
            {
                LifePoints -= points;
            }
        }
    }
}
