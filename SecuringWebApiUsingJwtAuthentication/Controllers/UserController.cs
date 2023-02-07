﻿using Microsoft.AspNetCore.Mvc;
using SecuringWebApiUsingJwtAuthentication.IServices;

namespace SecuringWebApiUsingJwtAuthentication.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly IUserService _userService;
        public UserController(IUserService userService)
        {
            _userService = userService;
        }
    }
}
