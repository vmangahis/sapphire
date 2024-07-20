﻿using Microsoft.EntityFrameworkCore;
using Sapphire.Contracts;
using Sapphire.Entities.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sapphire.Repository
{
    public class HunterRepository : RepositoryBase<Hunters>, IHunterRepository
    {
        public HunterRepository(RepositoryContext repContext) : base(repContext) { }

        public async Task<IEnumerable<Hunters>> GetAllHuntersAsync(bool track) => await GetAll(track).OrderBy(x => x.HunterName).Include(e => e.Guild).ToListAsync();

        public async Task<Hunters> GetHunterAsync(Guid huntId, bool track) => await GetThroughCondition(x => x.Id.Equals(huntId), track).Include(e => e.Guild).SingleOrDefaultAsync();
        public async Task<Hunters> GetHunterByNameAsync(string HunterName, bool track) => await GetThroughCondition(x => x.HunterName.Equals(HunterName), track).SingleOrDefaultAsync();
        public void CreateHunter(Hunters hunt) => Create(hunt);
        public void DeleteHunter(Hunters hunt) => Delete(hunt);
        public void UpdateHunter(Hunters hunt) => Update(hunt);
    }
}
