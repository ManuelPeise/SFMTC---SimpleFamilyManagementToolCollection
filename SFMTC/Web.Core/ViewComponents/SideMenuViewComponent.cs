using Data.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace Web.Core.ViewComponents
{
    public class SideMenuViewComponent: ViewComponent
    {
        private ILayoutService _layOutService;

        public SideMenuViewComponent(ILayoutService layoutService)
        {
            _layOutService = layoutService;
        }

        public async Task<IViewComponentResult> InvokeAsync()
        {
            var result = await _layOutService.LoadLayoutViewModel();

            return View(result);
        }
    }
}
