using System;
using Adesso.DTOs;
using Adesso.Models;
using AutoMapper;
namespace Adesso.MapProfiles
{
	public class TravelProfile : Profile
	{
		public TravelProfile()
		{
			CreateMap<Travel, TravelDto>().ForMember(desc => desc.Id, opt => opt.MapFrom(src => src.Id));
		}
	}
}

