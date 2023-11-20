using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using examMVC.Data;
using examMVC.Models;
using examMVC.Services;
using examMVC.DTO;

namespace examMVC.Controllers
{
    public class AccountsController : Controller
    {
        private readonly AppDBContext _context;
        private readonly PasswordService _passwordService;

        public AccountsController(AppDBContext context, PasswordService passwordService)
        {
            _context = context;
            _passwordService = passwordService;
        }



        // GET: Accounts/Register
        public IActionResult Register()
        {
            return View();
        }

        // POST: Accounts/Register
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        public async Task<IActionResult> Register([Bind("Id,Name,Email,Password")] Account account)
        {
            bool existsAccount = await _context.Accounts.AnyAsync(a => a.Email == account.Email);

            if (existsAccount)
            {
                ModelState.AddModelError("Email", "Email already exists");
                return BadRequest(ModelState);
            }

            if (ModelState.IsValid)
            {
                account.Password = _passwordService.HashPassword(account.Password);
                
                _context.Accounts.Add(account);
                
                await _context.SaveChangesAsync();
                return Redirect(nameof(Login));
            }
            return View(account);
        }


        // GET: Accounts/Login
        [HttpGet]
        public IActionResult Login()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Login(LoginDTO loginDTO)
        {
            var checkAccount = await _context.Accounts.FirstOrDefaultAsync(a => a.Email == loginDTO.NameOrEmail || a.Name == loginDTO.NameOrEmail);

            if (checkAccount == null || !_passwordService.VerifyPassword(checkAccount.Password, loginDTO.Password)) 
            {
                ViewBag.notice = "Invalid name or password";
            }
            else
            {
                 if(checkAccount.Role == "admin") 
                 {
                    return Redirect("/Admin/Index");
                }
                 return Redirect("Index");
            }
            return View();
        }

        // GET: Accounts/Edit/5
        //[ValidateAntiForgeryToken]
    }
}
