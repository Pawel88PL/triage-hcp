using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using triage_hcp.Services.Interfaces;

namespace triage_hcp.Controllers
{
    
    public class DeleteController : ControllerBase
    {
        private readonly IDeleteService _deleteService;

        public DeleteController(IDeleteService deleteService)
        {
            _deleteService = deleteService;
        }

        [HttpPost]
        public async Task<IActionResult> DeletePatient(int id)
        {
            var result = await _deleteService.DeletePatientAsync(id);
            if (!result)
            {
                return NotFound();
            }

            return RedirectToAction("AdminList","ListsOfPatients");
        }
    }
}
