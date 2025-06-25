using CoreApp;
using DTOs;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace WebAPI1.Controllers
{
    //Indicamos que la direccion de este controlador
    //sera https://servidor:puerto/api/User
    [Route("api/[controller]")] //route
    [ApiController]
    public class UserController : ControllerBase
    {
        [HttpPost]
        [Route("Create")]

        public ActionResult Create(User user)
        {
            try
            {
                var um = new UserManager();
                um.Create(user);
                return Ok(user);

            } catch (Exception ex)
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
                var um = new UserManager();
                var listResult = um.RetrieveAll();

                return Ok(listResult);

            } catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
        }

        [HttpGet]
        [Route("RetrieveById")]
        public ActionResult RetrivebyId(int id)
        {
            try
            {

                var um = new UserManager();
                var result = um.RetrievebyId(id);

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

        [HttpGet]
        [Route("RetrieveByUserCode")]
        public ActionResult RetrivebyUserCode(string userCode)
        {
            try
            {

                var um = new UserManager();
                var result = um.RetrieveByUserCode(userCode);

                if (result == null)
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

        [HttpGet]
        [Route("RetrieveByEmail")]
        public ActionResult RetrieveByEmail(string email)
        {
            try
            {
                var um = new UserManager();
                var result = um.RetrieveByEmail(email);

                if (result == null)
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
        public ActionResult Update(User user)
        {
            try
            {
                var um = new UserManager();
                um.Update(user);
                return Ok("Usuario actualizado");
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
        }


        [HttpDelete]
        [Route("Delete")]
        public ActionResult Delete(int id)
        {
            try
            {

                var um = new UserManager();
                um.Delete(id);

                return Ok("Usuario eliminado");

            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
        }
    }
}
