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
    [Route("guru")]
    [GuruController]
    public class GuruController : ControllerBase
    {
        private readonly GuruService _guruService;

        public GuruController(GuruService guruService)
        {
            _guruService = guruService;
        }

        /// <summary>
        /// Get all Guru items.
        /// </summary>
        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<ActionResult<List<Guru>>> Get()
        {
            try
            {
                var guruItems = await _guruService.GetAsync();
                return Ok(guruItems);
            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, "Error retrieving data from the database");
            }
        }

        /// <summary>
        /// Get a specific Guru item by ID.
        /// </summary>
        [HttpGet("{id:length(24)}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<ActionResult<Guru>> Get(string id)
        {
            try
            {
                var guru = await _guruService.GetAsync(id);

                if (guru == null)
                {
                    return NotFound();
                }

                return Ok(guru);
            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, "Error retrieving data from the database");
            }
        }

        /// <summary>
        /// Creates a Guru item.
        /// </summary>
        [HttpPost]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<ActionResult<Guru>> Post(Guru newGuru)
        {
            try
            {
                if (newGuru == null)
                {
                    return BadRequest();
                }

                await _guruService.CreateAsync(newGuru);

                return CreatedAtAction(nameof(Get), new { id = newGuru.Id }, newGuru);
            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, "Error retrieving data from the database");
            }
        }

        /// <summary>
        /// Updates a specific Guru item by ID.
        /// </summary>
        [HttpPut("{id:length(24)}")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> Put(string id, Guru updatedGuru)
        {
            try
            {
                var guru = await _guruService.GetAsync(id);

                if (guru == null)
                {
                    return NotFound();
                }

                updatedGuru.Id = guru.Id;

                await _guruService.UpdateAsync(id, updatedGuru);

                return NoContent();
            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, "Error retrieving data from the database");
            }
        }

        /// <summary>
        /// Deletes a specific Guru item by ID.
        /// </summary>
        [HttpDelete("{id:length(24)}")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> Delete(string id)
        {
            try
            {
                var guru = await _guruService.GetAsync(id);

                if (guru == null)
                {
                    return NotFound();
                }

                await _guruService.RemoveAsync(id);

                return NoContent();
            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, "Error retrieving data from the database");
            }
        }
    }
}
