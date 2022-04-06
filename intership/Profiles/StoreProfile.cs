using AutoMapper;
using intership.DTO;
using intership.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace intership.Profiles
{
    public class StoreProfile : Profile
    {
        public StoreProfile()
        { 
            CreateMap<Store, StoreReadDTO>();
            CreateMap<StoreCreateDTO, Store>();
            CreateMap<StoreUpdateDTO, Store>();
            CreateMap<Store, StoreUpdateDTO>();
        }
    }
}
