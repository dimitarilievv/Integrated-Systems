using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using HospitalApplication.Domain.IdenitityModels;
using Microsoft.AspNetCore.Identity;

namespace HospitalApplication.Domain.DomainModels
{
    public class TransferRequest : BaseEntity
    {
        public DateTime DateCreated { get; set; }
        public string? OwnerId { get; set; }
        public HospitalApplicationUser? Owner { get; set; }

        public virtual ICollection<PatientTransfer>? PatientTransfers { get; set; }
    }
}
