using APBD_cw_11.DTOs.Requests;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using APBD_cw_11.Models;

namespace APBD_cw_11.Services
{
    public class SqlServerDbServices : IDbService
    {

        private readonly DoctorsDbContext _context;
        SqlServerDbServices(DoctorsDbContext context)
        {
            _context = context;
        }
        public async Task<IActionResult> AddDoctor(Doctor doctor)
        {
            await _context.Doctor.AddAsync(doctor);
            await _context.SaveChangesAsync();

            return new OkResult();
        }


        public async Task<IActionResult> DeleteDoctor(int id)
        {
            var doctor = _context.Doctor.FirstOrDefault(s => s.IdDoctor == id);
            if (doctor == null) return new BadRequestResult();
            _context.Attach(doctor);
            _context.Remove(doctor);
            await _context.SaveChangesAsync();
            return new OkObjectResult(doctor);
        }

        public async Task<IActionResult> EditDoctor(EditDoctorRequest request)
        {
            var doctor = _context.Doctor.FirstOrDefault(n => n.IdDoctor == request.IdDoctor);
            if (doctor == null)
            {
                return new BadRequestResult();
            }

            doctor.FirstName = request.FirstName;
            doctor.LastName = request.LastName;
            doctor.Email = request.Email;

            await _context.SaveChangesAsync();
            return new OkObjectResult(doctor);
        }

        public async Task<IActionResult> GetDoctors()
        {
            return new OkObjectResult(_context.Doctor.ToList());
        }
    }
}
