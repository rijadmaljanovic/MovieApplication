using AutoMapper;
using MovieApplication.Core.Entities;
using MovieApplication.Core.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MovieApplication.Infrastructure.AutoMapper
{
    public class CustomMapper : Profile
    {
        public CustomMapper()
        {
            CreateMap<Movie, MovieModel>()
                .ForMember(d => d.AvgRating, s => s.MapFrom(m1 => Decimal.Round(m1.Ratings.Count > 0 ? (decimal)m1.Ratings.Average(m => m.Rating) : 0, 1)))
                .ForMember(d => d.ReleaseDate, s => s.MapFrom(m => m.ReleaseDate.ToShortDateString()))
                .ForMember(d => d.RatingByUser, s => s.MapFrom(m => 0));

            CreateMap<Movie, MovieActorModel>()
                .ForMember(d => d.Actors, s => s.MapFrom(m => m.Actors.Select(ma => new ActorModel { Id = ma.ActorId, Name = ma.Actor.Name, ImagePath = ma.Actor.ImagePath}).ToList()))
                .ForMember(d => d.AvgRating, s => s.MapFrom(m1 => Decimal.Round(m1.Ratings.Count > 0 ? (decimal)m1.Ratings.Average(m => m.Rating) : 0, 1)))
                .ForMember(d => d.ReleaseDate, s => s.MapFrom(m => m.ReleaseDate.ToShortDateString()))
                .ForMember(d => d.RatingByUser, s => s.MapFrom(m => 0));
        }
    }
}
