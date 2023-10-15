using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Teach.Entities;
using Teach.Repositories;

namespace Teach.Controllers;

[Route("api/[controller]")]
[ApiController]
public class RoomController : MoldController<Room, RoomRepository>
{
    public RoomController(RoomRepository roomRepository) : base(roomRepository) { }
}