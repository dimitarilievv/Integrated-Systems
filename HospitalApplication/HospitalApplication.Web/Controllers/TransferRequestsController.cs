using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using HospitalApplication.Domain.DomainModels;
using HospitalApplication.Repository.Data;
using HospitalApplication.Service.Interface;

namespace HospitalApplication.Web.Controllers
{
    public class TransferRequestsController : Controller
    {
        private readonly ITransferRequestService _transferRequestService;

        public TransferRequestsController(ITransferRequestService transferRequestService)
        {
            _transferRequestService = transferRequestService;
        }


        // GET: TransferRequests/Details/5
        public async Task<IActionResult> Details(Guid? id)
        {
            // TODO: Implement method
            // Create ViewModel with Count or pass it through ViewBag/ViewData
            if (id == null)
                return NotFound();

            var transferRequest = _transferRequestService.GetTransferRequestDetails(id.Value);

            if (transferRequest == null)
                return NotFound();

            var viewModel = new TransferRequestDetailsViewModel
            {
                TransferRequest = transferRequest,
                PatientTransfers = transferRequest.PatientTransfers?.ToList() ?? new List<PatientTransfer>()
            };

            ViewData["TotalCount"] = viewModel.PatientTransfers.Count;

            return View(viewModel);

        }
    }
}
