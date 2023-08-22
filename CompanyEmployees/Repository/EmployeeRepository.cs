﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Contracts;
using Entities.Models;

namespace Repository
{
    public class EmployeeRepository : RepositoryBase<Employee>, IEmployeeRepository
    {
        public EmployeeRepository(RepositoryContext repositoryContext)
            : base(repositoryContext)
        {

        }

        public IEnumerable<Employee> GetAllEmployees(bool trackChanges) =>
            FindAll(trackChanges)
            .OrderBy(c => c.Name)
            .ToList();

        public Employee GetEmployee(Guid companyId, Guid id, bool trackChanges) =>
             FindByCondition(e => e.CompanyId.Equals(companyId) && e.Id.Equals(id), trackChanges)
            .SingleOrDefault();



        //public Employee GetEmployees(Guid employeeId, bool trackChanges)
        //{
        //    throw new NotImplementedException();
        //}


        public IEnumerable<Employee> GetEmployees(Guid companyId, bool trackChanges) =>
             FindByCondition(e => e.CompanyId.Equals(companyId), trackChanges)
             .OrderBy(e => e.Name).ToList();
    }
}
