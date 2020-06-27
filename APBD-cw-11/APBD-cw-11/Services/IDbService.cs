using APBD_cw_11.DTOs.Requests;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Wyklad10Sample.Models;

namespace APBD_cw_11.Services
{
    public interface IDbService
    {
        public Task<IActionResult> GetDoctors();
        public Task<IActionResult> AddDoctor(Doctor doctor);
        public Task<IActionResult> EditDoctor(EditDoctorRequest request);
        public Task<IActionResult> DeleteDoctor(int id);
    }
}
