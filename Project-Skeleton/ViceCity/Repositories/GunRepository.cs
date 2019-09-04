using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using ViceCity.Models.Guns;
using ViceCity.Models.Guns.Contracts;
using ViceCity.Repositories.Contracts;

namespace ViceCity.Repositories
{
    public class GunRepository : IRepository<IGun>
    {
        private IList<IGun> guns;
        public GunRepository()
        {
            guns = new List<IGun>();
        }
        public IReadOnlyCollection<IGun> Models => this.guns.ToList();

        public void Add(IGun model)
        {
            if (!guns.Contains(model))
            {
                guns.Add(model);
            }
        }

        public IGun Find(string name)
        {
            if (guns.Any(x=>x.Name==name))
            {
                IGun gun= guns.FirstOrDefault(x => x.Name == name);
                return gun;
            }
            return null;
        }

        public bool Remove(IGun model)
        {
            if (guns.Contains(model))
            {
                guns.Remove(model);
                return true;
            }
            return false;
        }
    }
}
