using Microsoft.AspNetCore.Mvc;
using Shop1.Data.Interfaces;

namespace Shop1.Controllers
{
    public class ItemsController : Controller
    {
        private IItems IAllItems;
        private ICategorys IAllCategorys;

        public ItemsController(IItems IAllItems, ICategorys IAllCategorys)
        {
            this.IAllItems = IAllItems;
            this.IAllCategorys = IAllCategorys;
        }

        public ActionResult List()
        {
            ViewBag.Title = "Страница с предметами";
            var Items = IAllItems.AllItems;
            return View(Items);
        }
    }
}