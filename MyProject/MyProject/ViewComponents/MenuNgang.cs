using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using MyProject.DataModels;
using System.Threading.Tasks;

namespace MyProject.ViewComponents
{
    public class MenuNgang : ViewComponent
    {
        private readonly MyDbContext DbContext;
        public MenuNgang(MyDbContext dbContext)
        {
            DbContext = dbContext;
        }

        public async Task<IViewComponentResult> InvokeAsync()
        {
            return View("_MenuLoai", await DbContext.Loais.ToListAsync());
        }
    }
}
