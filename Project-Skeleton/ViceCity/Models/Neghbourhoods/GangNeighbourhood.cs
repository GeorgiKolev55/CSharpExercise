using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using ViceCity.Models.Guns;
using ViceCity.Models.Neghbourhoods.Contracts;
using ViceCity.Models.Players.Contracts;
using ViceCity.Repositories.Contracts;

namespace ViceCity.Models.Neghbourhoods
{
    public class GangNeighbourhood : INeighbourhood
    {

        public void Action(IPlayer mainPlayer, ICollection<IPlayer> civilPlayers)
        {
            while (mainPlayer.GunRepository.Models.Count > 0 && civilPlayers.Count > 0)
            {
                var currentGun = mainPlayer.GunRepository.Models.First();

                if (currentGun.CanFire)
                {
                    int firedBullets = currentGun.Fire();
                    var currentCivilPlayer = civilPlayers.First();
                    currentCivilPlayer.TakeLifePoints(firedBullets);
                    if (!currentCivilPlayer.IsAlive)
                    {
                        civilPlayers.Remove(currentCivilPlayer);
                        continue;
                    }
                }
                else
                {
                    mainPlayer.GunRepository.Remove(currentGun);
                }
            }

            foreach (var civilPlayer in civilPlayers)
            {
                foreach (var gun in civilPlayer.GunRepository.Models)
                {
                    while (gun.CanFire)
                    {
                        int firedBullets = gun.Fire();
                        mainPlayer.TakeLifePoints(firedBullets);
                        if (!mainPlayer.IsAlive)
                        {
                            break;
                        }
                    }
                    if (!mainPlayer.IsAlive)
                    {
                        break;
                    }
                    civilPlayer.GunRepository.Remove(gun);
                }
            }
        }
    }
}
