using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using RoomReservtion.Reservations;
using RoomReservtion.Rooms;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Volo.Abp.AspNetCore.Mvc;

namespace RoomReservtion.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RoomsController : AbpController
    {
        private readonly IRoomAppService _roomAppservice;

        public RoomsController(IRoomAppService roomAppservice)
        {
            _roomAppservice = roomAppservice;
        }
        // all get methods  AllowAnonymous so user can discover rooms without login
        [HttpGet]
        [Route("/[action]/{id}")]
        public async Task<RoomDto> GetAsync(int id)
        {
            // we can check and return 404 in case of not found 
            return await _roomAppservice.GetRoom(id);
        }
        [HttpGet]
        [Route("/[action]/")]
        public async Task<List<RoomDto>> GetAllAsync()
        {
            return await _roomAppservice.GetAllRooms();
        }
        [HttpGet]
        [Route("/[action]/")]
        public async Task<List<RoomDto>> SearchAsync([FromQuery]RoomFilter filter)
        {
            return await _roomAppservice.Search(filter);
        }
        [HttpPost]
        [Route("/[action]")]
        [Authorize] // we can use permission here with Authorize to allow user with specific permission only to create 
        public async Task CreateAsync(CreateRoomDto dto)
        {
            await _roomAppservice.AddRoom(dto);
        }
        [HttpPut]
        [Route("/[action]")]
        [Authorize]
        public async Task UpdateAsync(CreateRoomDto dto)
        {
            await _roomAppservice.EditRoom(dto);
        }
        [HttpDelete]
        [Route("/[action]/{id}")]
        [Authorize]
        public async Task DeleteAsync(int id)
        {
            await _roomAppservice.DeleteRoom(id);
        }
        [HttpPost]
        [Route("/[action]")]
        public async Task<bool> ReserveAsync(ReservationDto dto)
        {
            return await _roomAppservice.ReserveRoomAsync(dto);
        }
        // in all actions we can return custom success messages but now we made the simpleset solution
    }
}
