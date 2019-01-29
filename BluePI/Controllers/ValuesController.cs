﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace BluePI.Controllers
{
    /// <summary>
    /// ValueController
    /// </summary>
    [Route("api/[controller]")]     
    //[Authorize]
    public class ValuesController : ControllerBase
    {
        /// <summary>
        ///  GET api/values 
        /// </summary>
        /// <returns></returns> 
        [HttpGet]
        public ActionResult<IEnumerable<string>> Get()
        {
            return new string[] { "value1", "value2" };
        }

        /// <summary>
        /// GET api/values/5
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns> 
        [HttpGet("{id}")]
        public ActionResult<string> Get(int id)
        {
            return "value";
        }

        /// <summary>
        /// POST api/values
        /// </summary>
        /// <param name="value"></param> 
        [HttpPost]
        public void Post([FromBody] string value)
        {
        }
        /// <summary>
        /// PUT api/values/5
        /// </summary>
        /// <param name="id"></param>
        /// <param name="value"></param> 
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        /// <summary>
        ///  DELETE api/values/5
        /// </summary>
        /// <param name="id"></param> 
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
