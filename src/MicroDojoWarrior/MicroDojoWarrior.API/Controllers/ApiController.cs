﻿using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Linq;

namespace MicroDojoWarrior.API.Controllers
{
    public class ApiController : ControllerBase
    {
        protected new ActionResult Response(object result = null)
        {
            return Ok(result);
        }

        protected new ActionResult Response(string link, object result = null)
        {
            return Created(link, result);
        }

        protected ActionResult ResponseNotFound()
        {
            return NotFound();
        }

        protected ActionResult ResponseError(Exception ex)
        {
            return StatusCode(StatusCodes.Status500InternalServerError, ex);
        }

        protected Guid GetCurrentUserId()
        {
            var userId = Guid.Parse(User.Claims.FirstOrDefault(c => c.Type == "sub").Value);
            return userId;
        }
    }
}