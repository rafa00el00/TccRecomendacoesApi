﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using TCCApi.VendaApi.Services;

namespace TCCApi.VendaApi.Controllers
{

    [Route("api/[controller]")]
    public class ValuesController : Controller
    {
        private readonly IAuthService _authService;

        public ValuesController(IAuthService authService)
        {
            this._authService = authService;
        }
        // GET api/values
        [HttpGet]
        public async Task<string> GetAsync()
        {
            return await _authService.AuthenticateAsync();
        }

        // GET api/values/5
        [HttpGet("{id}")]
        public string Get(int id)
        {
            return "value";
        }

        // POST api/values
        [HttpPost]
        public void Post([FromBody]string value)
        {
        }

        // PUT api/values/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE api/values/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
