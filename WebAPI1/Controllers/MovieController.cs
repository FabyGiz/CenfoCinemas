using CoreApp;
using DTOs;
using Microsoft.AspNetCore.Mvc;

namespace WebAPI1.Controllers
{

    //Indicamos que la direccion de este controlador
    //sera https://servidor:puerto/api/User
    [Route("api/[controller]")] //route
    [ApiController]
    public class MovieController: ControllerBase
    {
        [HttpPost]
        [Route("Create")]

        public ActionResult Create(Movies movies)
        {
            try
            {
                var mm = new MovieManager();
                mm.Create(movies);
                return Ok(movies);
            }catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
        }

        [HttpGet]
        [Route("RetrieveAll")]

        public ActionResult RetrieveAll()
        {
            try
            {
                var mm = new MovieManager();
                var listResult = mm.RetrieveAll();

                return Ok(listResult);

            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
        }

        [HttpGet]
        [Route("RetrieveById")]
        public ActionResult RetriveById(int id)
        {
            try
            {

                var mm = new MovieManager();
                var result = mm.RetrieveById(id);

                if (result != null)
                {
                    return NotFound("No se encontro");
                }

                return Ok(result);

            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
        }

        [HttpPut]
        [Route("Update")]
        public ActionResult Update(Movies movies)
        {
            try
            {
                var mm = new MovieManager();
                mm.Update(movies);
                return Ok("Pelicula actualizado");
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
        }

        [HttpDelete]
        [Route("Delete")]
        public ActionResult Delete(Movies movies)
        {
            try
            {

                var mm = new MovieManager();
                mm.Delete(movies.Id);

                return Ok("Pelicula eliminada");

            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
        }

    }
}
