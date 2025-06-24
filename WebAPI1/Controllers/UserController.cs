using CoreApp;
using DTOs;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace WebAPI1.Controllers
{
    //Indicamos que la direccion de este controlador
    //sera https://servidor:puerto/api/User
    [Route("api/[controller]")]  
    [ApiController]
    public class UserController : ControllerBase
    {
        [HttpPost]
        [Route("Create")]

        public ActionResult Create (User user)
        {
            try
            {
                var um = new UserManager();
                um.Create(user);
                return Ok(user);

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
                var um = new UserManager();
                var listResult = um.RetrieveAll();

                return Ok(listResult);

            }catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
        }

        [HttpGet]
        [Route("RetrieveByEmail")]
        public ActionResult RetrieveByEmail()
        {
            try
            {
                var um = new UserManager();
                //var listResult = um.Retr

                return Ok(User);

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
                return Ok(user);
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
        }


        [HttpDelete]
        [Route("Delete")]
        public ActionResult Delete(User user)
        {
            try
            {
                return Ok(user);
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
        }
    }
}
