using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using Contracts;
using Entities.Exceptions;
using Entities.Models;
using Service.Contracts;
using Shared.DataTransferObjects;

namespace Service
{
    internal sealed class EmployeeService : IEmployeeService
    {
        private readonly IRepositoryManager _repository;
        private readonly ILoggerManager _logger;
        private readonly IMapper _mapper;

        public EmployeeService(IRepositoryManager repository, ILoggerManager logger, IMapper mapper)
        {
            _repository = repository;
            _logger = logger;
            _mapper = mapper;
        }

        public IEnumerable<EmployeeDto> GetEmployees(Guid companyId, bool trackChanges)
        {
            var company = _repository.Company.GetCompany(companyId, trackChanges);

            if (company is null)
                throw new CompanyNotFoundException(companyId);

            var employeesFromDb = _repository.Employee.GetEmployees(companyId,
                trackChanges);

            var employeesDto = _mapper.Map<IEnumerable<EmployeeDto>>(employeesFromDb);

            return employeesDto;
        }


        //public IEnumerable<EmployeeDto> GetAllEmployees(bool trackChanges)
        //{

        //    var employees = _repository.Employee.GetAllEmployees(trackChanges);

        //    var employeesDto = employees.Select(e => new EmployeeDto(e.Id, e.Name, e.Age, e.Position, e.CompanyId));

        //    return employeesDto;

        //}

        //public EmployeeDto GetEmployee(Guid employeeId, bool trackChanges)
        //{
        //    var employee = _repository.Employee.GetEmployee(employeeId, trackChanges);
        //    //Check if the company is null

        //    if (employee is null)

        //        throw new CompanyNotFoundException(employeeId);

        //    var employeeDto = _mapper.Map<EmployeeDto>(employee);

        //    return employeeDto;
        //}
    }
}
