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
                //Origen Client Destino ClientDTOs
                CreateMap<CreateClientCommand, Client>();
                CreateMap<Client, ClientDTOs>();

                CreateMap<CreateUserRecepCommand, UserRecep>();
                CreateMap<UserRecep, UserRecepDTOs>();
            
                CreateMap<CreateRecepcionistCommand, Receptionist>();
                CreateMap<Receptionist, ReceptionistDTOs>();
            
                CreateMap<CreateRentalCommand, Rental>();
                CreateMap<Rental, RentalDTOs>();
            
                CreateMap<CreateRoomCommand, Room>();
                CreateMap<Room, RoomDTOs>();

                CreateMap<CreateTipeCommand,Type>();
                CreateMap<Types, TipeDTOs>();
            
                CreateMap<CreateEstateCommand, Estate>();
                CreateMap<Estate, EstateDTOs>();
        }
    }
}
