using ApplicationServices.DTOs;
using ApplicationServices.Features.Clients.Commands.CreateClientCommand;
using ApplicationServices.Features.Estates.Commands.CreateEstateCommand;
using ApplicationServices.Features.Recepcionists.Commands.CreateRecepcionistCommands;
using ApplicationServices.Features.Rentals.Commands.CreateRentalCommand;
using ApplicationServices.Features.Rooms.Commands.CreateRoomCommand;
using ApplicationServices.Features.Tipes.Commands.CreateTipeCommand;
using ApplicationServices.Features.UserReceps.Commands.CreateUserRecepCommand;
using AutoMapper;
using DomainClass.Entity;
namespace ApplicationServices.Mapping
{
    public class GeneralMapping : Profile
    {
        public GeneralMapping()
        {
            // Mapeo de comandos a entidades y viceversa

            // Client
            CreateMap<CreateClientCommand, Client>();
            CreateMap<Client, ClientDTOs>();

            // UserRecep
            CreateMap<CreateUserRecepCommand, UserRecep>();
            CreateMap<UserRecep, UserRecepDTOs>();

            // Receptionist
            CreateMap<CreateRecepcionistCommand, Receptionist>();
            CreateMap<Receptionist, ReceptionistDTOs>();

            // Rental
            CreateMap<CreateRentalCommand, Rental>();
            CreateMap<Rental, RentalDTOs>();

            // Room
            CreateMap<CreateRoomCommand, Room>();
            CreateMap<Room, RoomDTOs>();

            // Type
            CreateMap<CreateTipeCommand, Types>();
            CreateMap<Types, TipeDTOs>();

            // Estate
            CreateMap<CreateEstateCommand, Estate>();
            CreateMap<Estate, EstateDTOs>();
        }
    }
}