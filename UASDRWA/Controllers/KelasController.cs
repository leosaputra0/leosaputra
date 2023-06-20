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
    [Route("kelas")]
    [KelasController]
    public class KelasController : ControllerBase
    {
        private readonly KelasService _kelasService;

        public KelasController(KelasService kelasService)
        {
            _kelasService = kelasService;
        }

        /// <summary>
        /// Get all Kelas items.
        /// </summary>
        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<ActionResult<List<Kelas>>> Get()
        {
            try
            {
                var kelasItems = await _kelasService.GetAsync();
                return Ok(kelasItems);
            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, "Error retrieving data from the database");
            }
        }

        /// <summary>
        /// Get a specific Kelas item by ID.
        /// </summary>
        [HttpGet("{id:length(24)}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<ActionResult<Kelas>> Get(string id)
        {
            try
            {
                var kelas = await _kelasService.GetAsync(id);

                if (kelas == null)
                {
                    return NotFound();
                }

                return Ok(kelas);
            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, "Error retrieving data from the database");
            }
        }

        /// <summary>
        /// Creates a Kelas item.
        /// </summary>
        [HttpPost]
        [Authorize]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> Post(Kelas newKelas)
        {
            try
            {
                if (newKelas == null)
                {
                    return BadRequest();
                }

                await _kelasService.CreateAsync(newKelas);

                return CreatedAtAction(nameof(Get), new { id = newKelas.Id }, newKelas);
            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, "Error retrieving data from the database");
            }
        }


        /// <summary>
        /// Updates a specific Kelas item by ID.
        /// </summary>
        [HttpPut("{id:length(24)}")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> Put(string id, Kelas updatedKelas)
        {
            try
            {
                var kelas = await _kelasService.GetAsync(id);

                if (kelas == null)
                {
                    return NotFound();
                }

                updatedKelas.Id = kelas.Id;

                await _kelasService.UpdateAsync(id, updatedKelas);

                return NoContent();
            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, "Error retrieving data from the database");
            }
        }

        /// <summary>
        /// Deletes a specific Kelas item by ID.
        /// </summary>
        [HttpDelete("{id:length(24)}")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> Delete(string id)
        {
            try
            {
                var kelas = await _kelasService.GetAsync(id);

                if (kelas == null)
                {
                    return NotFound();
                }

                await _kelasService.RemoveAsync(id);

                return NoContent();
            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, "Error retrieving data from the database");
            }
        }

    }
}
