using APBD_cw_11.DTOs.Requests;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Wyklad10Sample.Models;

namespace APBD_cw_11.Services
{
    public class SqlServerDbServices : IDbService
    {

        private readonly DoctorsDbContext _context;
        public SqlServerDbServices(DoctorsDbContext context)
        {
            _context = context;
        }
        public Task<IActionResult> AddDoctor(Doctor doctor)
        {
            throw new NotImplementedException();
        }

        public Task<IActionResult> DeleteDoctor(int id)
        {
            throw new NotImplementedException();
        }

        public Task<IActionResult> EditDoctor(EditDoctorRequest request)
        {
            throw new NotImplementedException();
        }

        public Task<IActionResult> GetDoctors()
        {
            throw new NotImplementedException();
        }
    }
}
