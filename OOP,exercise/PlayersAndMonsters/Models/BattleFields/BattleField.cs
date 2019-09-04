using PlayersAndMonsters.Models.BattleFields.Contracts;
using PlayersAndMonsters.Models.Players;
using PlayersAndMonsters.Models.Players.Contracts;
using System;
using System.Collections.Generic;
using System.Text;

namespace PlayersAndMonsters.Models.BattleFields
{
    public class BattleField : IBattleField
    {
        public void Fight(IPlayer attackPlayer, IPlayer enemyPlayer)
        {
            if (attackPlayer.IsDead==true||enemyPlayer.IsDead==true)
            {
                throw new ArgumentException("Player is dead!");
            }
            if (attackPlayer is Beginner)
            {
                attackPlayer.Health += 40;
                foreach (var item in attackPlayer.CardRepository.Cards)
                {
                    item.DamagePoints += 30;
                }
            }
            if (enemyPlayer is Beginner)
            {
                enemyPlayer.Health += 40;
                foreach (var item in enemyPlayer.CardRepository.Cards)
                {
                    item.DamagePoints += 30;
                }
            }

        }
    }
}
