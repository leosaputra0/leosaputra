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
    [Route("presensiharianguru")]
    [PresensiHarianGuruController]
    public class PresensiHarianGuruController : ControllerBase
    {
        private readonly PresensiHarianGuruService _presensiharianguruService;

        public PresensiHarianGuruController(PresensiHarianGuruService presensiharianguruService)
        {
            _presensiharianguruService = presensiharianguruService;
        }

        /// <summary>
        /// Get all PresensiHarianGuru items.
        /// </summary>
        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<ActionResult<List<PresensiHarianGuru>>> Get()
        {
            try
            {
                var presensiharianguruItems = await _presensiharianguruService.GetAsync();
                return Ok(presensiharianguruItems);
            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, "Error retrieving data from the database");
            }
        }

        /// <summary>
        /// Get a specific PresensiHarianGuru item by ID.
        /// </summary>
        [HttpGet("{id:length(24)}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<ActionResult<PresensiHarianGuru>> Get(string id)
        {
            try
            {
                var presensiharianguru = await _presensiharianguruService.GetAsync(id);

                if (presensiharianguru == null)
                {
                    return NotFound();
                }

                return Ok(presensiharianguru);
            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, "Error retrieving data from the database");
            }
        }

        /// <summary>
        /// Creates a PresensiHarianGuru item.
        /// </summary>
        [HttpPost]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<ActionResult<PresensiHarianGuru>> Post(PresensiHarianGuru newPresensiHarianGuru)
        {
            try
            {
                if (newPresensiHarianGuru == null)
                {
                    return BadRequest();
                }

                await _presensiharianguruService.CreateAsync(newPresensiHarianGuru);

                return CreatedAtAction(nameof(Get), new { id = newPresensiHarianGuru.Id }, newPresensiHarianGuru);
            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, "Error retrieving data from the database");
            }
        }

        /// <summary>
        /// Updates a specific PresensiHarianGuru item by ID.
        /// </summary>
        [HttpPut("{id:length(24)}")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> Put(string id, PresensiHarianGuru updatedPresensiHarianGuru)
        {
            try
            {
                var presensiharianguru = await _presensiharianguruService.GetAsync(id);

                if (presensiharianguru == null)
                {
                    return NotFound();
                }

                updatedPresensiHarianGuru.Id = presensiharianguru.Id;

                await _presensiharianguruService.UpdateAsync(id, updatedPresensiHarianGuru);

                return NoContent();
            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, "Error retrieving data from the database");
            }
        }

        /// <summary>
        /// Deletes a specific PresensiHarianGuru item by ID.
        /// </summary>
        [HttpDelete("{id:length(24)}")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> Delete(string id)
        {
            try
            {
                var presensiharianguru = await _presensiharianguruService.GetAsync(id);

                if (presensiharianguru == null)
                {
                    return NotFound();
                }

                await _presensiharianguruService.RemoveAsync(id);

                return NoContent();
            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, "Error retrieving data from the database");
            }
        }

    }
}
