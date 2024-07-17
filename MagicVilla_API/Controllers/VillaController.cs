using MagicVilla_API.Datos;
using MagicVilla_API.Modelos;
using MagicVilla_API.Modelos.DTO;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.JsonPatch;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace MagicVilla_API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class VillaController : ControllerBase
    {
        //variables privadas van con guion bajo
        private readonly ILogger<VillaController> _logger;

        //Inyextar el DbContext para usarlo mediante inyeccion de dependencias
        private readonly ApplicationDbContext _db;

        //Inyectando el servicio de Looger ctro tab
        public VillaController(ILogger<VillaController> logger, ApplicationDbContext db)
        {
            _logger = logger;
            _db = db;
        }


        //Retornar el estado  con ActionResult
        //Se manejan los tipos de resultado con ProducesResponseType
        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public ActionResult <IEnumerable<VillaDto>> GetVillas()
        {
            _logger.LogInformation("Obteniendo villas");
            //Select * from villas
            return Ok(_db.Villas.ToList());
        }


        //Creando un endpoint para obtener una villa por id, agregando nombre
        [HttpGet("id:int", Name = "GetVilla")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public ActionResult<VillaDto> GetVilla(int id)
        {
            if(id==0)
            {
                _logger.LogError("Error al traer la villa con id: "+ id);
                return BadRequest();
            }
            //SI no se encuentra un registro con el id enviado. 
            var villa = _db.Villas.FirstOrDefault(v => v.Id == id);

            //Si el villa es nulo 404
            if(villa == null)
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
            //Si el modelo es valido
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            //Validacion personalizada
            if(_db.Villas.FirstOrDefault(v => v.Nombre.ToLower() == villaDto.Nombre.ToLower()) != null)
            {
                //Nombre de la validacion  y mensaje de la validacion
                ModelState.AddModelError("Nombre", "El nombre de la villa ya existe");
                return BadRequest(ModelState);
            }

            //Si es nulo
            if (villaDto == null)
            {
                return BadRequest();

            }if(villaDto.Id > 0)
            {
                return StatusCode(StatusCodes.Status500InternalServerError);
            }
            //Creando nuevo modelo con base a la villa
            Villa modelo = new()
            {
                Nombre = villaDto.Nombre,
                Detalle = villaDto.Detalle,
                ImagenUrl = villaDto.ImagenUrl,
                Ocupantes = villaDto.Ocupantes,
                Tarifa = villaDto.Tarifa,
                MetrosCuadrados = villaDto.MetrosCuadrados,
                Amenidad = villaDto.Amenidad
            };
            //Agregando el registro a la base de datos
            _db.Villas.Add(modelo);
            _db.SaveChanges();

            //return Ok(villaDto);
            return CreatedAtRoute("GetVilla", new {id = villaDto.Id }, villaDto);   
        }

        //SOlo se usa la Interfaz porque no se utiliza el modelo como tal
        [HttpDelete("{id:int}")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]        
        public IActionResult DeleteVilla(int id)
        {

           //Si el id es 0
            if(id == 0)
            {
                return BadRequest();
            }
            //Si no se encuentra el registro
            var villa = _db.Villas.FirstOrDefault(v => v.Id == id);
            if(villa == null)
            {
                return NotFound();
            }
            //Eliminando el registro
            _db.Villas.Remove(villa);
            _db.SaveChanges();

            return NoContent();
        }


        [HttpPut("{id:int}")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public IActionResult UpdateVilla(int id, [FromBody] VillaDto villaDto)
        {
            //Si el id es 0, si es el id diferente dentro del objeto villaDto
            if(villaDto == null ||  id != villaDto.Id)
            {
                return BadRequest();
            }
            //Crear el modelo tioo villa
            Villa modelo = new()
            {
                Id = villaDto.Id,
                Nombre = villaDto.Nombre,
                Detalle = villaDto.Detalle,
                ImagenUrl = villaDto.ImagenUrl,
                Ocupantes = villaDto.Ocupantes,
                Tarifa = villaDto.Tarifa,
                MetrosCuadrados = villaDto.MetrosCuadrados,
                Amenidad = villaDto.Amenidad
            };
            //Actualizar el registro
            _db.Villas.Update(modelo);
            _db.SaveChanges();

            return NoContent();
        }


        [HttpPatch("{id:int}")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public IActionResult UpdatePartialVilla(int id, JsonPatchDocument<VillaDto> patchDto)
        {
            //Si el id es 0, si es el id diferente dentro del objeto villaDto
            if (patchDto == null || id == 0)
            {
                return BadRequest();
            }
            //Capturando el registro que se va a modificar
            var villa = _db.Villas.AsNoTracking().FirstOrDefault(v => v.Id == id);
            VillaDto villaDto = new()
            {
                Id = villa.Id,
                Nombre = villa.Nombre,
                Detalle = villa.Detalle,
                ImagenUrl = villa.ImagenUrl,
                Ocupantes = villa.Ocupantes,
                Tarifa = villa.Tarifa,
                MetrosCuadrados = villa.MetrosCuadrados,
                Amenidad = villa.Amenidad
            };
            //Conultar si la villa no existe
            if (villa == null) return BadRequest();


            patchDto.ApplyTo(villaDto, ModelState);

            //Si el modelo no es valido
            if(!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            //Creando un modelo tipo villa llenando c/u de las propiedades, despues de pasar el patch
            Villa modelo = new()
            {
                Id = villaDto.Id,
                Nombre = villaDto.Nombre,
                Detalle = villaDto.Detalle,
                ImagenUrl = villaDto.ImagenUrl,
                Ocupantes = villaDto.Ocupantes,
                Tarifa = villaDto.Tarifa,
                MetrosCuadrados = villaDto.MetrosCuadrados,
                Amenidad = villaDto.Amenidad
            };
            //Este modelo es el que se envia al metodo update del _dbContext
            _db.Villas.Update(modelo);
            _db.SaveChanges();

            return NoContent();
        }




    }

    
}
