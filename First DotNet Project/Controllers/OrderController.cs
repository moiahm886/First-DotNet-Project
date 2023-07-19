using First_DotNet_Project.Data;
using First_DotNet_Project.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace First_DotNet_Project.Controllers
{
 
    public class OrderController : Controller
    {
        private readonly ApplicationDB applicationDB;

        public OrderController(ApplicationDB applicationDB)
        {
            this.applicationDB = applicationDB;
        }
        [HttpGet]
        public async Task<IActionResult> Add()
        {
            return await Task.Run(()=> View());
        }
        public async Task<IActionResult> Index()
        {
            var orders = await applicationDB.Categories.ToListAsync();
            return View(orders);
        }
        [HttpPost]
        public async Task<IActionResult> Add(AddOrderViewModel addOrderViewModel)
        {
            var category = new Category()
            {
                ID = new int(),
                Name = addOrderViewModel.Name,
                Order = addOrderViewModel.Order,
                Ordertime = addOrderViewModel.Ordertime,
            };
            await applicationDB.Categories.AddAsync(category);
            await applicationDB.SaveChangesAsync();
            return RedirectToAction("Index");
        }
        [HttpGet]
        public async Task <IActionResult> Update(int id) {
            var order = await applicationDB.Categories.FirstOrDefaultAsync(c => c.ID == id);
            if(order != null)
            {
                var update = new UpdateModel()
                {
                    ID = order.ID,
                    Name = order.Name,
                    Order = order.Order,
                    Ordertime = order.Ordertime,
                };
                return await Task.Run(()=>View("Update", update));

            }
            return RedirectToAction("Index");
        }
        [HttpPost]
        public  async Task<IActionResult> Update(UpdateModel updateModel) {
            var check = await applicationDB.Categories.FindAsync(updateModel.ID);
            if (check != null)
            {
                check.Name = updateModel.Name;
                check.Order = updateModel.Order;   
                check.Ordertime = updateModel.Ordertime;
                await applicationDB.SaveChangesAsync();
                return RedirectToAction("Index");
            }
            return RedirectToAction("Index");
        }
        [HttpPost]
        public async Task<IActionResult> delete(UpdateModel model)
        {
            var check = await applicationDB.Categories.FindAsync(model.ID);
            if (check != null)
            {
                applicationDB.Categories.Remove(check);
                await applicationDB.SaveChangesAsync();
                return RedirectToAction("Index");
            }
            return RedirectToAction("Index");
        }        

       
      
    }
}
