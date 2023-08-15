﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Entities.Models;

namespace Service.Contracts
{
    public interface IEmployeeService
    {
        IEnumerable<Employee> GetAllEmployees(bool trackChanges);
    }
}
