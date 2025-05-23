﻿using HospitalApplication.Domain.DomainModels;
using HospitalApplication.Repository.Interface;
using HospitalApplication.Service.Interface;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HospitalApplication.Service.Implementation
{
    public class PatientDepartmentService : IPatientDepartmentService
    {
        private readonly IPatientService _patientService;
        private readonly IDepartmentService _departmentService;
        private readonly IRepository<PatientDepartment> _repository;
        private readonly IRepository<TransferRequest> _transferRequestRepository;
        private readonly IRepository<PatientTransfer> _patientTransferRepository;

        public PatientDepartmentService(
            IPatientService patientService,
            IDepartmentService departmentService,
            IRepository<PatientDepartment> repository,
            IRepository<TransferRequest> transferRequestRepository,
            IRepository<PatientTransfer> patientTransferRepository)
        {
            _patientService = patientService;
            _departmentService = departmentService;
            _repository = repository;
            _transferRequestRepository = transferRequestRepository;
            _patientTransferRepository = patientTransferRepository;
        }

        public PatientDepartment AddPatientToDepartment(Guid patientId, Guid departmentId, string userId)
        {
            var patient = _patientService.GetById(patientId);
            var department = _departmentService.GetById(departmentId);

            if(patient == null || department == null) 
            {
                throw new ArgumentNullException(nameof(patient));
            }

            var patientDepartment = new PatientDepartment()
            {
                Patient = patient,
                Department = department,
                PatientId = patientId,
                DepartmentId = departmentId,
                DateAssigned = DateTime.Now,
                OwnerId = userId
            };

            return _repository.Insert(patientDepartment);
        }

        public TransferRequest CreateTransferRequest(string userId)
        {
            var patientDepartments = _repository.GetAll(
                selector: x => x,
                predicate: x => x.OwnerId == userId,
                include: x => x.Include(y => y.Patient)
                                .Include(y => y.Department))
                                .ToList();

            if (!patientDepartments.Any())
                return null;

            var transferRequest = new TransferRequest
            {
                Id = Guid.NewGuid(),
                OwnerId = userId,
                DateCreated = DateTime.Now,
                PatientTransfers = new List<PatientTransfer>()
            };

            _transferRequestRepository.Insert(transferRequest);

            foreach (var pd in patientDepartments)
            {
                var patientTransfer = new PatientTransfer
                {
                    Id = Guid.NewGuid(),
                    PatientId = pd.PatientId,
                    DepartmentId = pd.DepartmentId,
                    TransferRequestId = transferRequest.Id
                };

                _patientTransferRepository.Insert(patientTransfer);
                _repository.Delete(pd);
            }

            return transferRequest;
        }

        public PatientDepartment DeleteById(Guid id)
        {
            var entity = _repository.Get(x => x, x => x.Id == id);
            if (entity == null)
                return null;

            return _repository.Delete(entity);
        }

        public List<PatientDepartment> GetAll()
        {
            return _repository.GetAll(selector: x => x).ToList();
        }

        public List<PatientDepartment> GetAllByCurrentUser(string userId)
        {
            return _repository.GetAll(selector: x => x,
                predicate: x => x.OwnerId == userId,
                include: x => x.Include(y => y.Patient).Include(y => y.Department).Include(y => y.Owner)).ToList();
        }

        public PatientDepartment? GetById(Guid id)
        {
            return _repository.Get(selector: x => x,
                predicate: x => x.Id == id,
                include: x => x.Include(y => y.Patient).Include(x => x.Owner).Include(x => x.Department));
        }
    }
}
