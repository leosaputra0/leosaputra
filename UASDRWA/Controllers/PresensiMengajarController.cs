using BookStoreApi.Models;
using BookStoreApi.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace TodoApi.Controllers
{
    [Route("presensimengajar")]
    [PresensiMengajarController]
    public class PresensiMengajarController : ControllerBase
    {
        private readonly PresensiMengajarService _presensimengajarService;

        public PresensiMengajarController(PresensiMengajarService presensimengajarService)
        {
            _presensimengajarService = presensimengajarService;
        }

        /// <summary>
        /// Get all PresensiMengajar items.
        /// </summary>
        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<ActionResult<List<PresensiMengajar>>> Get()
        {
            try
            {
                var presensimengajarItems = await _presensimengajarService.GetAsync();
                return Ok(presensimengajarItems);
            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, "Error retrieving data from the database");
            }
        }

        /// <summary>
        /// Get a specific PresensiMengajar item by ID.
        /// </summary>
        [HttpGet("{id:length(24)}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<ActionResult<PresensiMengajar>> Get(string id)
        {
            try
            {
                var presensimengajar = await _presensimengajarService.GetAsync(id);

                if (presensimengajar == null)
                {
                    return NotFound();
                }

                return Ok(presensimengajar);
            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, "Error retrieving data from the database");
            }
        }

        /// <summary>
        /// Creates a PresensiMengajar item.
        /// </summary>
        [HttpPost]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<ActionResult<PresensiMengajar>> Post(PresensiMengajar newPresensiMengajar)
        {
            try
            {
                if (newPresensiMengajar == null)
                {
                    return BadRequest();
                }

                await _presensimengajarService.CreateAsync(newPresensiMengajar);

                return CreatedAtAction(nameof(Get), new { id = newPresensiMengajar.Id }, newPresensiMengajar);
            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, "Error retrieving data from the database");
            }
        }

        /// <summary>
        /// Updates a specific PresensiMengajar item by ID.
        /// </summary>
        [HttpPut("{id:length(24)}")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> Put(string id, PresensiMengajar updatedPresensiMengajar)
        {
            try
            {
                var presensimengajar = await _presensimengajarService.GetAsync(id);

                if (presensimengajar == null)
                {
                    return NotFound();
                }

                updatedPresensiMengajar.Id = presensimengajar.Id;

                await _presensimengajarService.UpdateAsync(id, updatedPresensiMengajar);

                return NoContent();
            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, "Error retrieving data from the database");
            }
        }

        /// <summary>
        /// Deletes a specific PresensiMengajar item by ID.
        /// </summary>
        [HttpDelete("{id:length(24)}")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> Delete(string id)
        {
            try
            {
                var presensimengajar = await _presensimengajarService.GetAsync(id);

                if (presensimengajar == null)
                {
                    return NotFound();
                }

                await _presensimengajarService.RemoveAsync(id);

                return NoContent();
            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, "Error retrieving data from the database");
            }
        }

    }
}
