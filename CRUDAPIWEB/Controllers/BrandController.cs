﻿using CRUDAPIWEB.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.JsonPatch;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace CRUDAPIWEB.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class brandController : ControllerBase
    {
        private readonly BrandContext _dbContext;
        public brandController(BrandContext dbContext)
        {
            _dbContext = dbContext;

        }
        [HttpGet]
      
      
        public async Task<ActionResult<IEnumerable<Brand>>> GetBrands()
        {
            if(_dbContext.Brands == null)
            {
                return NotFound();
            }
            return await _dbContext.Brands.ToListAsync();
        }
        [HttpGet("{id}")]
        
        public async Task<ActionResult<Brand>> GetBrands(int id)
        {
            if (_dbContext.Brands == null)
            {
                return NotFound();
            }
            var brand =await _dbContext.Brands.FindAsync(id);
            if (brand == null)
            {
                return NotFound();
            }
            return brand;
        }

        [HttpPost]
        
        public async Task<ActionResult<Brand>> PostBrand(Brand brand)
        {
            _dbContext.Brands.Add(brand); 
            await _dbContext.SaveChangesAsync();
            return CreatedAtAction(nameof(GetBrands), new {id = brand.ID},brand);
        }

        [HttpPut]
        
        public async Task<ActionResult> PutBrand(int id, Brand brand)
        {
            if(id!= brand.ID)
            {
                return BadRequest();
            }
            _dbContext.Entry(brand).State = EntityState.Modified;
            try
            {
                await _dbContext.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!BrandAvailable(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }
            return Ok();
        }

        [HttpDelete("{id}")]
       
        public async Task<IActionResult> DeleteBrand(int id)
        {
            if(_dbContext.Brands == null)
            {
                return NotFound();
            }
            var brand =await _dbContext.Brands.FindAsync(id);
            if(brand == null)
            {
                return NotFound();
            }
            _dbContext.Brands.Remove(brand);
            await _dbContext.SaveChangesAsync();
            return Ok();

        }
        [HttpPatch("{id}")]
    

        public async Task<IActionResult> PatchBrand(int id, JsonPatchDocument<Brand> patchDoc)
        {
            if (patchDoc == null)
            {
                return BadRequest();
            }

            var brand = await _dbContext.Brands.FindAsync(id);
            if (brand == null)
            {
                return NotFound();
            }

            patchDoc.ApplyTo(brand, ModelState);

            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            // Check if applying the patch was successful
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            try
            {
                await _dbContext.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!BrandExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return NoContent();
        }


        private bool BrandExists(int id)
        {
            return _dbContext.Brands.Any(e => e.ID == id);
        }

        private bool BrandAvailable(int id)
        {
            return (_dbContext.Brands?.Any(x=>x.ID==id)).GetValueOrDefault();   
        }


    }
}
