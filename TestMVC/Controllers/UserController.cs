using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using TestMVC.DTOs;
using TestMVC.Models;
using TestMVC.Services;


namespace TestMVC.Controllers
{
    public class UserController : Controller
    {
        private readonly UserService Service;
        private readonly IMapper mapper;
        public UserController(IMapper mapper, UserService service)
        {
            this.mapper = mapper;
            Service = service;
        }

        // GET: AllUser
        public IActionResult Index()
        {

            var users = new List<User>();

            users = Service.GetAll();

            return View(users);
        }

        // GET: SingleUser
        public IActionResult GetById(int id)
        {
            User user = new User();
            user = Service.GetAll().FirstOrDefault(y => y.Id == id);

            //return View("Index",user); TODO
            return View("Index", Service.GetAll());
        }

        [HttpPost]
        public IActionResult Add([FromForm]UserDto userDto)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    Service.Add(userDto);
                }
                catch (Exception)
                {
                    ModelState.AddModelError("", "Can't add User");
                    return RedirectToAction("Index");
                }

            }
            ModelState.AddModelError("", "Can't add User. Data not valid");
            return RedirectToAction("Index");
        }



        [HttpDelete]
        public void DeleteUser(int id)
        {
            Service.Remove(id);
        }

        [HttpPost]
        public ActionResult GetList()
        {

            var draw = HttpContext.Request.Form["draw"].FirstOrDefault();

            // Skip number of Rows count  
            var start = Request.Form["start"].FirstOrDefault();

            // Paging Length 10,20  
            var length = Request.Form["length"].FirstOrDefault();

            // Sort Column Name  
            var sortColumn = Request.Form["columns[" + Request.Form["order[0][column]"].FirstOrDefault() + "][name]"].FirstOrDefault();

            // Sort Column Direction (asc, desc)  
            var sortColumnDirection = Request.Form["order[0][dir]"].FirstOrDefault();

            // Search Value from (Search box)  
            var searchValue = Request.Form["search[value]"].FirstOrDefault();

            //Paging Size (10, 20, 50,100)  
            int pageSize = length != null ? Convert.ToInt32(length) : 0;

            int skip = start != null ? Convert.ToInt32(start) : 0;

            int recordsTotal = 0;

            var usersq = Service.GetAll().AsQueryable();


            //filter
            if (!string.IsNullOrEmpty(searchValue))
            {
                usersq = usersq.Where(
                   x => x.UserName.ToLower().Contains(searchValue.ToLower())
                || x.Password.ToLower().Contains(searchValue.ToLower())
                || x.Id.ToString().Contains(searchValue.ToLower()));

            }

            //sorting
            switch (sortColumnDirection)
            {
                case "asc": usersq = usersq.OrderBy(a => a.GetType().GetProperty(sortColumn).GetValue(a, null)); break;
                case "desc": usersq = usersq.OrderByDescending(a => a.GetType().GetProperty(sortColumn).GetValue(a, null)); break;
            }

            //total number of rows counts   
            recordsTotal = usersq.Count();

            //Paging   
            var data = usersq.Skip(skip).Take(pageSize).ToList();

            return Json(new { draw, recordsFiltered = recordsTotal, recordsTotal, data });

        }
    }
}