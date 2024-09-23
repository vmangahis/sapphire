﻿using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Sapphire.Contracts;
using Sapphire.Entities.Exceptions.BadRequest;
using Sapphire.Entities.Models;
using Sapphire.Service.Contracts;
using Sapphire.Shared.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sapphire.Service
{
    public class CharacterService : ICharacterService
    {
        private readonly IRepositoryManager _repoManager;
        private readonly IMapper _mapper;
        private readonly UserManager<SapphireUser> _saphUser;
        private SapphireUser? sapphireUser;
        public CharacterService(IRepositoryManager repomanager, IMapper mapper, UserManager<SapphireUser> saphUser)
        {
            _repoManager = repomanager;
            _mapper = mapper;
            _saphUser = saphUser;
        }

        public async Task CreateCharacter(CharacterCreationDTO charDto, SapphireUser saphUser)
        {
            
            var characterFull = await CheckCharacterLimit(saphUser);

            if (characterFull)
                throw new MaxCharacterCreation();
            var character = _mapper.Map<Character>(charDto);
            character.User = saphUser;
            character.RoleId = charDto.RoleId;
        

            _repoManager.Character.CreateCharacter(character);
            await _repoManager.SaveAsync();

            

        }

        private async Task<bool> CheckCharacterLimit(SapphireUser saphUser)
        {
            var owners = await _repoManager.Character.GetCharacterOwnerById(new Guid(saphUser.Id));
            if(owners.Count() == 2)
              return true;
            
            return false;
        }

    }
}
