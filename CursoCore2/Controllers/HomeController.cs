using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using CursoCore2.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.DependencyInjection;
using System.Threading;

namespace CursoCore2.Controllers
{
    public class HomeController : Controller
    {
        public HomeController(IServiceProvider serviceProvider)
        {
            //CreateRoles(serviceProvider).Wait();
            ejecutarTareaAsync();
        }
        public IActionResult Index()
        {
            return View();
        }

        public IActionResult About()
        {
            ViewData["Message"] = "Your application description page.";

            return View();
        }

        public IActionResult Contact()
        {
            ViewData["Message"] = "Your contact page.";

            return View();
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

        private async Task CreateRoles(IServiceProvider serviceProvider)
        {
            var roleManager = serviceProvider.GetRequiredService<RoleManager<IdentityRole>>();
            var userManager = serviceProvider.GetRequiredService<UserManager<IdentityUser>>();
            //Creando roles
            String[] rolesName = { "Admin", "User" };
            IdentityResult roleResult;
            foreach (var item in rolesName)
            {
                var roleExist = await roleManager.RoleExistsAsync(item);
                if(!roleExist)
                {
                    roleResult = await roleManager.CreateAsync(new IdentityRole(item));
                }
            }
            //Asignando Rol a un usuario
            var user = await userManager.FindByIdAsync("f38e402c-bfcd-4786-bdac-8448a10ae6e9");
            await userManager.AddToRoleAsync(user, "Admin");
        }

        private async Task ejecutarTareaAsync() //este metodo se va sincronizar con la tarea Tareas
        {
            var data = await Tareas();
            String tarea = "Ahora ejecutaremos las demas lineas de codigo porque la tarea a finalizado ";
        }

        //metodo asincronico que va retornar un data de tipo string
        private async Task<String> Tareas()
        {
            Thread.Sleep(20 * 1000);//1 seg. contiene 1000 milesegundos para otener una pausa de 20 segundos
            String tarea = "Tarea finalizada";
            return tarea;
        }
    }
}
