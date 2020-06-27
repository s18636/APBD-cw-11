using APBD_cw_11.DTOs.Requests;
using APBD_cw_11.Models;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

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
