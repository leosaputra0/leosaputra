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
    [Route("mapel")]
    [MapelController]
    public class MapelController : ControllerBase
    {
        private readonly MapelService _mapelService;

        public MapelController(MapelService mapelService)
        {
            _mapelService = mapelService;
        }

        /// <summary>
        /// Get all Mapel items.
        /// </summary>
        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<ActionResult<List<Mapel>>> Get()
        {
            try
            {
                var mapelItems = await _mapelService.GetAsync();
                return Ok(mapelItems);
            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, "Error retrieving data from the database");
            }
        }

        /// <summary>
        /// Get a specific Mapel item by ID.
        /// </summary>
        [HttpGet("{id:length(24)}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<ActionResult<Mapel>> Get(string id)
        {
            try
            {
                var mapel = await _mapelService.GetAsync(id);

                if (mapel == null)
                {
                    return NotFound();
                }

                return Ok(mapel);
            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, "Error retrieving data from the database");
            }
        }

        /// <summary>
        /// Creates a Mapel item.
        /// </summary>
        [HttpPost]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<ActionResult<Mapel>> Post(Mapel newMapel)
        {
            try
            {
                if (newMapel == null)
                {
                    return BadRequest();
                }

                await _mapelService.CreateAsync(newMapel);

                return CreatedAtAction(nameof(Get), new { id = newMapel.Id }, newMapel);
            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, "Error retrieving data from the database");
            }
        }

        /// <summary>
        /// Updates a specific Mapel item by ID.
        /// </summary>
        [HttpPut("{id:length(24)}")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> Put(string id, Mapel updatedMapel)
        {
            try
            {
                var mapel = await _mapelService.GetAsync(id);

                if (mapel == null)
                {
                    return NotFound();
                }

                updatedMapel.Id = mapel.Id;

                await _mapelService.UpdateAsync(id, updatedMapel);

                return NoContent();
            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, "Error retrieving data from the database");
            }
        }

        /// <summary>
        /// Deletes a specific Mapel item by ID.
        /// </summary>
        [HttpDelete("{id:length(24)}")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> Delete(string id)
        {
            try
            {
                var mapel = await _mapelService.GetAsync(id);

                if (mapel == null)
                {
                    return NotFound();
                }

                await _mapelService.RemoveAsync(id);

                return NoContent();
            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, "Error retrieving data from the database");
            }
        }

    }
}
