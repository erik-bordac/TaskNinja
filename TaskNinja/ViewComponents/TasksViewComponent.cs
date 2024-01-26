using Microsoft.AspNetCore.Mvc;
using TaskNinja.Services.Interfaces;

namespace TaskNinja.ViewComponents
{
    public class TasksViewComponent : ViewComponent
    {
        public async Task<IViewComponentResult> InvokeAsync(int n)
        {
            var l = new List<int> { n,n+1,n+2 };
            return View(l);
        }
    }
}
