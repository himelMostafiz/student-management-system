
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BLL.Services;
using DLL.Repositories;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using BLL.Request_Validation;
using LightQuery;
using LightQuery.EntityFrameworkCore;

namespace WebApi.Controllers
{
    /*[Route("api/[controller]")]*/
    [ApiController]
    [Route("[Controller]")]
    public class DepartmentController : ControllerBase
    {
        private readonly IDepartmentService _departmentService;
        public DepartmentController(IDepartmentService departmentService)
        {
            _departmentService = departmentService;
        }

        [AsyncLightQuery(forcePagination: true, defaultPageSize: 5, defaultSort: "DepartmentId desc")]
        [HttpGet("GetAllDepartment")]
        public IActionResult GetAllDepartment()
        {
            return Ok( _departmentService.GetAllDepartmentQueryable());
        }

        [HttpGet("GetAll")]
        public async Task<IActionResult> GetAll()
        {
            return Ok(await _departmentService.GetAllDepartmentAsync());
        }

        [HttpGet(template: "{code}")]
        public async Task<IActionResult> GetADepartment(string code)
        {
            return Ok(await _departmentService.GetADepartmentAsync(code));
        }

        [HttpPost]
        public async Task<IActionResult> Insert(DepartmentInserRequestValidationModel departmentRequestValidation)
        {
            return Ok(await _departmentService.AddDepartmentAsync(departmentRequestValidation));
        }

        [HttpPut(template:"{code}")]
        public async Task<IActionResult> Update(string code, DepartmentInserRequestValidationModel departmentRequestValidation)
        {
            return Ok(await _departmentService.UpdateDepartmentAsync(code, departmentRequestValidation));
        }

        [HttpDelete(template: "{code}")]
        public async Task<IActionResult> Delete(string code)
        {
            return Ok(await _departmentService.DeleteDepartmentAsync(code));
        }

        //[HttpGet]
        //public IActionResult GetAll()
        //{
        //    //return Ok("Get all Students of all departments");
        //    return Ok(DepartmentStatic.GetAllDepartment());
        //}

        
        //[HttpGet(template: "{code}")]
        //public IActionResult GetAStudent(string code)
        //{
        //    //return Ok("Get " + deptName + " department's students data");
        //    return Ok(DepartmentStatic.GetADepartment(code));
        //}


        //[HttpPost]
        //public IActionResult Insert(Department adept)
        //{
        //    //return Ok("Insert new Department");
        //    return Ok(DepartmentStatic.InsertADepartment(adept));
        //}

        //[HttpPut(template: "{deptName}")]
        //public IActionResult Update(string deptName, Department adept)
        //{
        //    //return Ok("Update this " + deptName + " Name");
        //    return Ok(DepartmentStatic.GetAllDepartment());
        //}

        //[HttpDelete(template: "{code}")]
        //public IActionResult Delete(string code)
        //{
        //    //return Ok("Delete this " + deptName + " department Name");
        //    return Ok(DepartmentStatic.DeleteADepartment(code));
        //}
    }

    //public static class DepartmentStatic
    //{

    //    private static List<Department> departmentList { get; set; } = new List<Department>();


    //    public static List<Department> GetAllDepartment()
    //    {
    //        return departmentList;
    //    }
    //    public static Department GetADepartment(string code)
    //    {
    //        if (!string.IsNullOrEmpty(code))
    //            return departmentList.FirstOrDefault(x => x.Code.Equals(code));
    //        else
    //            return new Department();
    //    }

    //    public static Department InsertADepartment(Department aDept)
    //    {
    //        if (aDept != null)
    //            departmentList.Add(aDept);

    //        return aDept;
    //    }

    //    public static Department UpdateADepartment(string code,Department aDept)
    //    {
    //        var updatedDepartment = new Department();
    //        if (aDept != null && code!= null)
    //        {
    //            foreach (var dept in departmentList)
    //            {
    //                if (dept.Code == code)
    //                {
    //                    dept.Name = aDept.Name;
    //                    updatedDepartment = dept;
    //                } 
    //            }
    //        }
    //        return updatedDepartment;
    //    }

    //    public static List<Department> DeleteADepartment(string code)
    //    {
    //        if (!String.IsNullOrEmpty(code))
    //        {
    //             var dept = departmentList.FirstOrDefault(x => x.Code == code);
    //            if(dept!= null)
    //             departmentList = departmentList.Where(d => d.Code != dept.Code).ToList();
    //        }
    //        return departmentList;
    //    }
    //}

}
