using PlayersAndMonsters.Models.Players.Contracts;
using PlayersAndMonsters.Repositories.Contracts;
using System;
using System.Collections.Generic;
using System.Text;

namespace PlayersAndMonsters.Models.Players
{
    public abstract class Player : IPlayer
    {
        private string username;
        private int health;
        public Player(ICardRepository cardRepository, string username, int health)
        {
            Username = username;
            Health = health;
            CardRepository = cardRepository;
        }
        public ICardRepository CardRepository { get; private set; }

        public string Username
        {
            get { return this.username; }
            private set
            {
                if (string.IsNullOrEmpty(value))
                {
                    throw new ArgumentException("Player's username cannot be null or an empty string. ");
                }
                this.username = value;
            }
        }

        public int Health
        {
            get { return this.health; }
            set
            {
                if (value<0)
                {
                    throw new ArgumentException("Player's health bonus cannot be less than zero. ");
                }
                this.health = value;
            }
        }

        public bool IsDead { get; private set; }

        public void TakeDamage(int damagePoints)
        {
            if (Health-damagePoints<0)
            {
                throw new ArgumentException("Damage points cannot be less than zero.");
            }
            Health -= damagePoints;
        }
    }
}
