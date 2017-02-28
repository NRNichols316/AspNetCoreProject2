using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit http://go.microsoft.com/fwlink/?LinkID=397860

namespace NevasFirstProject.Controllers
{
    [Route("api/[controller]")]
    public class MsgController : Controller
    {
        #region --- Data persisted while API runs ---
        /// <summary>
        /// The first word of our response, referenced by ID 1 in parameterized requests
        /// </summary>
        private static string firstWord = "Hello";

        /// <summary>
        /// The second word of our response, referenced by ID 2 in parameterized requests
        /// </summary>
        private static string secondWord = "World";
        #endregion
        // GET: api/values
       
        #region --- API methods in this controller ---
        /// <summary>
        /// Returns the full 2-word message
        /// </summary>
        /// <example>
        /// GET api/message
        /// </example>
        [HttpGet]
        public ActionResult Get()
        {
            return Ok(firstWord + " " + secondWord);
        }

        /// <summary>
        /// Retrieves the specified word in our message.
        /// </summary>
        /// <example>
        /// GET api/message/2
        /// </example>
        /// <returns>
        /// Retrieves the specified word in our message. If the user requests a word ID outside of accepted values of 1 or 2,
        /// we will return a "404 Not found" error to the client.
        /// </returns>
        [HttpGet("{id}")]
        public ActionResult Get(int id)
        {
            if (id == 1)
                return Ok(firstWord);
            else if (id == 2)
                return Ok(secondWord);

            return NotFound("Not found");
        }

        /// <summary>
        /// Updates the speficied word in our message with a new word.
        /// </summary>
        /// <example>
        /// PUT api/message/2/world
        /// </example>
        [HttpPut("{id}/{value}")]
        public ActionResult Put(int id, string value)
        {
            if (id == 1)
            {
                firstWord = value;
                return Ok("Updated successfully");
            }
            else if (id == 2)
            {
                secondWord = value;
                return Ok("Updated successfully");
            }
            else
                return NotFound("Not found");
        }
#endregion

   }
}
