using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using APBD_cw_11.DTOs.Requests;
using APBD_cw_11.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Wyklad10Sample.Models;

namespace APBD_cw_11.Controllers
{
    [Route("api/doctors")]
    [ApiController]
    public class DoctorController : ControllerBase
    {
        private readonly IDbService _service;
        public DoctorController(IDbService service)
        {
            _service = service;
        }

        [HttpGet]
        public async Task<IActionResult> GetDoctors()
        {
            return await _service.GetDoctors();
        }

        [HttpPost]
        public async Task<IActionResult> AddDoctor(Doctor doctor)
        {
            
            return await _service.AddDoctor(doctor); ;
        }
        [HttpPut("edit")]
        public async Task<IActionResult> EditDoctor(EditDoctorRequest request)
        {
            return await _service.EditDoctor(request);
        }


        [HttpDelete("delete/{id:int}")]
        public async Task<IActionResult> DeleteDoctor(int id)
        {
            return await _service.DeleteDoctor(id);
        }
    }
}
