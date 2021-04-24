using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using NorthwindModel;
using OData.Models;
using OData.ViewModels;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using ODataWebExperimental.Northwind.Model;

namespace OData.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }
        
        public IActionResult Index(string searchPhrase, string sortOrder)
        {
            ViewBag.NameSortParm = String.IsNullOrEmpty(sortOrder) ? "firstname" : "";
            ViewBag.NameSortParm = sortOrder == "firstname" ? "firstname_desc" : "firstname";
            ViewBag.LastNameSortParm = sortOrder == "lastname" ? "lastname_desc" : "lastname";
            ViewBag.TitleSortParm = sortOrder == "title" ? "title_desc" : "title";
            ViewBag.CitySortParm = sortOrder == "city" ? "city_desc" : "city";
            ViewBag.CountrySortParm = sortOrder == "country" ? "country_desc" : "country";
            ViewBag.AddressSortParm = sortOrder == "address" ? "address_desc" : "address";
            ViewBag.AddressSortParm = sortOrder == "address" ? "address_desc" : "address";
            ViewBag.BirthSortParm = sortOrder == "birth" ? "birth_desc" : "birth";
            ViewBag.HireSortParm = sortOrder == "hire" ? "hire_desc" : "hire";
            
            NorthwindEntities context = new NorthwindEntities(new Uri("https://services.odata.org/V4/Northwind/Northwind.svc/"));
            IQueryable<Employee> employees = context.Employees;

            switch (sortOrder)
            {
                case "firstname":
                    employees = employees.OrderBy(x => x.FirstName);
                    break;
                case "firstname_desc":
                    employees = employees.OrderByDescending(x => x.FirstName);
                    break;
                case "lastname":
                    employees = employees.OrderBy(x => x.LastName);
                    break;
                case "lastname_desc":
                    employees = employees.OrderByDescending(x => x.LastName);
                    break;
                case "title":
                    employees =employees.OrderBy(x => x.Title);
                    break;
                case "title_desc":
                    employees = employees.OrderByDescending(x => x.Title);
                    break;
                case "city":
                    employees = employees.OrderBy(x => x.City);
                    break;
                case "city_desc":
                    employees = employees.OrderByDescending(x => x.City);
                    break;
                case "country":
                    employees = employees.OrderBy(x => x.Country);
                    break;
                case "country_desc":
                    employees = employees.OrderByDescending(x => x.Country);
                    break;
                case "address":
                    employees = employees.OrderBy(x => x.Address);
                    break;
                case "address_desc":
                    employees = employees.OrderByDescending(x => x.Address);
                    break;
                case "birth":
                    employees = employees.OrderBy(x => x.BirthDate);
                    break;
                case "birth_desc":
                    employees = employees.OrderByDescending(x => x.BirthDate);
                    break;
                case "hire":
                    employees = employees.OrderBy(x => x.HireDate);
                    break;
                case "hire_desc":
                    employees = employees.OrderByDescending(x => x.HireDate);
                    break;
                default:
                    employees = employees.OrderBy(x => x.LastName);
                    break;
            }

            if (!string.IsNullOrEmpty(searchPhrase))
            {
                employees = employees.Where(x => x.FirstName.Contains(searchPhrase) || x.LastName.Contains(searchPhrase));
            }

            var vm = new EmployeeViewModel()
            {
                Employees = employees.ToArray()
            };

            return View(vm);
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
