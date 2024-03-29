﻿using EndProject.Business.Interfaces;
using EndProject.DataContext.Repositories;
using EndProject.Domain;
using EndProject.Helpers;

namespace EndProject.Business.Services
{
    public class DepartmentService : IDepartment
    {
        private readonly DepartmentRepository _departmentRepository;
        private readonly EmployeeRepository _employeeRepository;

        private int Count = 1;
        public DepartmentService()
        {
            _departmentRepository = new DepartmentRepository();
            _employeeRepository = new EmployeeRepository();
        }
        public Department Create(Department department)
        {
            Department existDepartmentWithName = _departmentRepository.Get(d => d.Name.Equals(department.Name, StringComparison.OrdinalIgnoreCase));
            if (existDepartmentWithName is not null)
            {
                Helper.Print("Department is Already Exist with this name",ConsoleColor.Red);
                return null;
            }
            department.Id = Count;
            if (_departmentRepository.Create(department))
            {
                Count++;
                return department;
            }
            return null;
        }

        public Department Delete(int id)
        {
            Department existDepartment  = _departmentRepository.Get(d => d.Id == id);
            if (existDepartment is null) return null;
            if (_departmentRepository.Delete(existDepartment))
            {
                List<Employee> employeeList = _employeeRepository.GetAll(e => e.Id == id);
                if (employeeList.Count > 0)
                {
                    foreach (var employee in employeeList)
                    {
                        _employeeRepository.Delete(employee);
                    }
                }
            }
            return null;
        }

        public Department Get(int id)
        {
            Department existDepartment = _departmentRepository.Get(d=>d.Id== id);
            if (existDepartment is null) return null;
            return existDepartment;
        }

        public List<Department> GetAll()
        {
            return _departmentRepository.GetAll();
        }

        public Department Get(string name)
        {
            return _departmentRepository.Get(d=>d.Name== name);
        }

        public List<Department> GetAll(int capacity)
        {
           return _departmentRepository.GetAll(d=>d.Capacity== capacity);
        }

        public Department Update(int id, Department department)
        {
            Department existDepartment = _departmentRepository.Get(d => d.Id == id);
            if (existDepartment is null) return null;
            Department existDepartmentWithName = _departmentRepository.Get(d => d.Name.Equals(department.Name, StringComparison.OrdinalIgnoreCase) && d.Id != existDepartment.Id);
            if (existDepartmentWithName is not null) return null;
            existDepartment.Name = department.Name;
            existDepartment.Capacity = department.Capacity;
            bool result = _departmentRepository.Update(department);
            if (result)
            {
                return existDepartment;
            }
            return null;
        }
    }
}
