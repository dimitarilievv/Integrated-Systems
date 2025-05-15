using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using HospitalApplication.Domain.DomainModels;
using HospitalApplication.Repository.Interface;
using HospitalApplication.Service.Interface;
using Microsoft.EntityFrameworkCore;

namespace HospitalApplication.Service.Implementation
{
    public class TransferRequestService : ITransferRequestService
    {
        private readonly IRepository<TransferRequest> _transferRequestRepository;

        public TransferRequestService(IRepository<TransferRequest> transferRequestRepository)
        {
            _transferRequestRepository = transferRequestRepository;
        }

        public TransferRequest? GetTransferRequestDetails(Guid id)
        {
            return _transferRequestRepository.Get(
                selector: x => x,
                predicate: x => x.Id == id,
                include: query => query
                    .Include(tr => tr.PatientTransfers)
                     .ThenInclude(pt => pt.Patient)
                    .Include(tr => tr.PatientTransfers)
                     .ThenInclude(pt => pt.Department)
                );
        }
    }
}
