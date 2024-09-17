using AutoMapper;
using BoletosApi.Models.Dtos;
using BoletosApi.Models.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BoletosApi.Models.Mapper
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<BoletoRequest, Boleto>();
            CreateMap<BancoRequest, Banco>();
        }
    }
}
