using MagicVilla_Api.Datos;
using MagicVilla_Api.Modelos;
using MagicVilla_Api.Modelos.Dto;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.JsonPatch;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace MagicVilla_Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class VillaController : ControllerBase
    {
        private readonly ILogger<VillaController> _logger;
        private readonly ApliacionDbContext _db;

        public VillaController(ILogger<VillaController> logger , ApliacionDbContext db  )
        {
            _logger = logger;
            _db = db;
        }



        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public ActionResult<IEnumerable<VillaDto>> GetVillas()
        {
            _logger.LogInformation("Obtener las Villas");
            return Ok(_db.villa.ToList());



        }

        [HttpGet("id:int", Name ="Getilla")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public ActionResult<VillaDto> GetVilla(int id)
        {
            if (id == 0)
            {
                _logger.LogError("Error al traer Villa con Id " + id);
                return BadRequest();
            }
          //  var vila = VillaStore.villalist.FirstOrDefault(v => v.Id == id);
          var villa = _db.villa.FirstOrDefault(v => v.Id == id);

            if (villa == null)
            {
                return NotFound();      
            }

            return Ok(villa);
        }
        [HttpPost]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public ActionResult<VillaDto> CrearVilla([FromBody] VillaDto villaDto)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            if (_db.villa.FirstOrDefault(v => v.Nombre.ToLower() == villaDto.Nombre.ToLower()) != null)
            {
                ModelState.AddModelError("NombreExiste", "La Villa con ese Nombre ya existe ");
                return BadRequest(ModelState);
            }
          
            
            if(villaDto==null)
            {
                return BadRequest(villaDto);
            }
            if(villaDto.Id >0)
            { 
                return StatusCode(StatusCodes.Status500InternalServerError); 
            
            
            }
            Villa model = new()
            {
                
                Nombre = villaDto.Nombre,
                Detalle = villaDto.Detalle,
                ImagenUrl = villaDto.ImagenUrl,
                Ocupantes = villaDto.Ocupante,
                Tarifa = villaDto.Tarifa,
                Metroscuadrados = villaDto.Metroscuadrados,
                Amenidad = villaDto.Amenidad
            };
            _db.villa .Add(model);
            _db.SaveChanges();
          

            return CreatedAtRoute("GetVilla", new {id= villaDto.Id},villaDto);

        }

        [HttpDelete ("{id:int}")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public IActionResult DeleteVilla(int id)
        {
            if (id == 0)
            { 
                return BadRequest();
            }
            var villa = _db.villa.FirstOrDefault(v=>v.Id == id);
            if(villa == null)
            {
                return NoContent();
            }
            _db.villa.Remove(villa);
            _db.SaveChanges ();

            return NoContent();
        }
        [HttpPut("{id:int}")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public IActionResult UpadateVilla(int id, [FromBody] VillaDto villaDto)
        {
            if(villaDto==null  || id!=villaDto.Id)
            {
                return BadRequest();
            }
            var villa = VillaStore.villalist.FirstOrDefault(v=>v.Id==id);
            //villa.Nombre = villaDto.Nombre;
            //villa.Ocupante=villaDto.Ocupante;
            //villa.Metroscuadrados = villaDto.Ocupante;

            Villa model = new()
            {
                Id = villaDto.Id,
                Nombre = villaDto.Nombre,
                Detalle = villaDto.Detalle,
                ImagenUrl = villaDto.ImagenUrl,
                Ocupantes = villaDto.Ocupante,
                Tarifa = villaDto.Tarifa,
                Metroscuadrados = villaDto.Metroscuadrados,
                Amenidad = villaDto.Amenidad,
            };
            _db.villa.Update(model);
            _db.SaveChanges();
            return NoContent();
        }
        [HttpPatch("{id:int}")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public IActionResult UpadatePartialVilla(int id, JsonPatchDocument<VillaDto> patchDto)
        {
            if (patchDto == null || id ==0)
            {
                return BadRequest();
            }
           // var villa = VillaStore.villalist.FirstOrDefault(v => v.Id == id);
           var villa= _db.villa.AsNoTracking().FirstOrDefault(v=>v.Id==id);

            VillaDto villaDto = new()
            {
                Id = villa.Id,
                Nombre = villa.Nombre,
                Detalle = villa.Detalle,
                ImagenUrl = villa.ImagenUrl,
                Ocupante = villa.Ocupantes,
                Tarifa=villa.Tarifa,
                Metroscuadrados = villa.Metroscuadrados,
                Amenidad = villa.Amenidad,
            };
            if(villa == null) return BadRequest();

           patchDto.ApplyTo(villaDto,ModelState);
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            Villa model = new()
            {
                Id = villaDto.Id,
                Nombre = villaDto.Nombre,
                Detalle = villaDto.Detalle,
                ImagenUrl = villaDto.ImagenUrl,
                Tarifa = villaDto.Tarifa,
                Metroscuadrados = villaDto.Metroscuadrados,
                Amenidad = villaDto.Amenidad,
            };

             _db.villa.Update(model);
            _db.SaveChanges();
            return NoContent();
        }
    }
}
