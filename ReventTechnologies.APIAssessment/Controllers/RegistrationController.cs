using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ReventTechnologies.Data.Context;
using EF.Core.Repository.Manager;
using ReventTechnologies.Data.Manager;
using ReventTechnologies.Data.Interfaces.Manager;
using Microsoft.AspNetCore.Authorization;

namespace ReventTechnologies.APIAssessment.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]

    [Authorize]
    public class RegistrationController : ControllerBase
    {
        IRegistrationManager _registrationmanager;

        private readonly ILogger<RegistrationController> _logger;



        public RegistrationController(IRegistrationManager registrationManager, ILogger<RegistrationController> logger)
        {
            _registrationmanager = registrationManager;

            _logger = logger;
        }


        [HttpGet]
        public ActionResult<Registration> GetById(int id)
        {
            _logger.LogInformation("get registered user is processing...");

            var reg = _registrationmanager.GetById(id);

            if (reg == null)
            {
                return NotFound();
            }

            return Ok(reg);
        }


        [HttpGet]
        public ActionResult<List<Registration>> GetAllRegisteredUser()
        {
            var lst = _registrationmanager.GetAll().ToList();

            return lst;
        }


        [HttpPost]
        public ActionResult<Registration> Register(Registration registration)
        {
            try
            {
                _logger.LogInformation("get registered user is processing...");

                registration.DateCreated = DateTime.Now.AddDays(-10);
                bool save = _registrationmanager.Add(registration);
                if (save)
                {
                    return Created("", registration);
                }

                return BadRequest("Something went wrong!");

            }
            catch (Exception ex)
            {

                throw ex;
            }

            
        }

        [HttpPost]   
        public Registration EditRegistration(Registration registration)
        {
            bool isUpdated = _registrationmanager.Update(registration);
            if (isUpdated)
            {
                return registration;
            }

            return null;
        }



        [HttpDelete("id")]
        public ActionResult<string> Delete(int id)
        {
            try
            {
                var reg = _registrationmanager.GetById(id);

                if (reg == null)
                {
                    return NotFound();
                }

                bool isDelete = _registrationmanager.Delete(reg);
                if (isDelete)
                {
                    return Ok(reg);
                }

                return BadRequest($"registration id:{reg.Id} failed to delete");

            }
            catch (Exception ex)
            {

                throw ex;
            }
          
        }





    }
}
