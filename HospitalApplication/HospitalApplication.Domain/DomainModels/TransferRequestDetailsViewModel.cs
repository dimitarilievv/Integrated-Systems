using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HospitalApplication.Domain.DomainModels
{
    public class TransferRequestDetailsViewModel
    {
        public TransferRequest TransferRequest { get; set; }
        public List<PatientTransfer> PatientTransfers { get; set; }
        public int TotalPatients => PatientTransfers?.Count ?? 0;
    }
}
