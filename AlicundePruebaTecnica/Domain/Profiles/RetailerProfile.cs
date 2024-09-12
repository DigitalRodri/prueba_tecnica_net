using AutoMapper;
using Domain.DTOs;
using Domain.Entities;

namespace Domain.Profiles
{
    public class RetailerProfile : Profile
    {
        public RetailerProfile() 
        {
            CreateMap<Retailer, RetailerDto>();
            CreateMap<RetailerDto, Retailer>();
        }
    }
}
