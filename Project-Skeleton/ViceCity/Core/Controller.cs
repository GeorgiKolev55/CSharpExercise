using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using ViceCity.Core.Contracts;
using ViceCity.Models.Guns;
using ViceCity.Models.Guns.Contracts;
using ViceCity.Models.Neghbourhoods;
using ViceCity.Models.Neghbourhoods.Contracts;
using ViceCity.Models.Players;
using ViceCity.Models.Players.Contracts;


namespace ViceCity.Core
{
    public class Controller : IController
    {
        private IPlayer player;
        private List<IPlayer> players;
        private Queue<IGun> queueOfGuns;
        private INeighbourhood gangNeighbourhood;

        public Controller()
        {
            
            player = new MainPlayer();
            players = new List<IPlayer>();
            this.queueOfGuns = new Queue<IGun>();
            gangNeighbourhood = new GangNeighbourhood();
        }
        public string AddGun(string type, string name)
        {
            if (type =="Pistol")
            {
                Pistol pistol = new Pistol(name);
                queueOfGuns.Enqueue(pistol);
                return $"Successfully added {name} of type: {type}";
            }
            else if (type=="Rifle")
            {
                Rifle rifle = new Rifle(name);
                queueOfGuns.Enqueue(rifle);
                return "Successfully added {name} of type: {type}";
            }
            else
            {
                return "Invalid gun type!";
            }
        }

        public string AddGunToPlayer(string name)
        {
            string gunName = string.Empty;
            if (queueOfGuns.Count==0)
            {
                return "There are no guns in the queue!";
            }
            if (name == "Vercetti")
            {
                gunName = this.queueOfGuns.Peek().Name;
                this.player.GunRepository.Add(this.queueOfGuns.Dequeue());
                return $"Successfully added {gunName} to the Main Player: Tommy Vercetti";
            }
            if (!this.players.Any(p => p.Name == name) && name != "Vercetti")
            {
                return "Civil player with that name doesn't exists!";
            }
            gunName = this.queueOfGuns.Peek().Name;
            this.players.First(p => p.Name == name).GunRepository.Add(this.queueOfGuns.Dequeue());
            return $"Successfully added {gunName} to the Civil Player: {name}";
        }

        public string AddPlayer(string name)
        {
            CivilPlayer player = new CivilPlayer(name);
            players.Add(player);
            return $"Successfully added civil player: {name}!";
        }

        public string Fight()
        {
            int numberOfCivilPlayers = this.players.Count;
            this.gangNeighbourhood.Action(this.player, this.players);
            if (this.player.LifePoints == 100 && this.players.Count == numberOfCivilPlayers && this.players.All(p => p.LifePoints == 50))
            {
                return $"Everything is okay!";
            }
            else
            {
                StringBuilder sb = new StringBuilder();
                sb.AppendLine("A fight happened:");
                sb.AppendLine($"Tommy live points: {this.player.LifePoints}!");
                sb.AppendLine($"Tommy has killed: {numberOfCivilPlayers - this.players.Count} players!");
                sb.AppendLine($"Left Civil Players: {this.players.Count}!");
                return sb.ToString().TrimEnd();
            }
        }
    }
}
