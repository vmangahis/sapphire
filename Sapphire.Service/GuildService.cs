﻿using AutoMapper;
using Sapphire.Contracts;
using Sapphire.Service.Contracts;
using Sapphire.Shared.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sapphire.Service
{
    public sealed class GuildService : IGuildService
    {
        private readonly IRepositoryManager _repomanager;
        private readonly ILoggerManager _loggerManager;
        private readonly IMapper _mapper;
        public GuildService(IRepositoryManager repo, ILoggerManager logger, IMapper mapper) {
            _repomanager = repo;
            _loggerManager = logger;
            _mapper = mapper;
        }

        public IEnumerable<GuildDTO> GetAllGuild(bool track)
        {
            var guild = _repomanager.Guild.GetAllGuild(track : false);
            return null; 
        }

        public GuildDTO GetSingleGuild(Guid gid, bool track)
        {
            throw new NotImplementedException();
        }
    }
}
