using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Contracts;
using Service.Contracts;
using Shared.DataTransferObjects;

namespace Service
{
    internal sealed class EmployeeService : IEmployeeService
    {
        private readonly IRepositoryManager _repository;
        private readonly ILoggerManager _logger;

        public EmployeeService(IRepositoryManager repository, ILoggerManager logger)
        {
            _repository = repository;
            _logger = logger;
        }

        public IEnumerable<EmployeeDto> GetAllEmployees(bool trackChanges)
        {
            try
            {
                var employees = _repository.Employee.GetAllEmployees(trackChanges);

                var employeesDto = employees.Select(e => new EmployeeDto(e.Id, e.Name, e.Age, e.Position, e.CompanyId));

                return employeesDto;
            }
            catch (Exception ex)
            {
                _logger.LogError($"Something went wrong in the {nameof(GetAllEmployees)} service method {ex}");
                throw;
            }
        }
    }
}
