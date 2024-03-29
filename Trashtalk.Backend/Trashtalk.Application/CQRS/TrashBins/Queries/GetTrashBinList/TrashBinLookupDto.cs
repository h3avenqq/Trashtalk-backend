﻿using AutoMapper;
using System;
using Trashtalk.Application.Common.Mappings;
using Trashtalk.Domain;

namespace Trashtalk.Application.CQRS.TrashBins.Queries.GetTrashBinList
{
    public class TrashBinLookupDto : IMapWith<TrashBin>
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public string Color { get; set; }

        public void Mapping(Profile profile)
        {
            profile.CreateMap<TrashBin, TrashBinLookupDto>()
                .ForMember(x => x.Id, opt => opt.MapFrom(x => x.Id))
                .ForMember(x => x.Name, opt => opt.MapFrom(x => x.Name))
                .ForMember(x => x.Color, opt => opt.MapFrom(x => x.Color));
        }
    }
}
