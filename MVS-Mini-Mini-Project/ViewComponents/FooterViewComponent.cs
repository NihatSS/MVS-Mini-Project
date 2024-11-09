using Microsoft.AspNetCore.Mvc;

namespace MVS_Mini_Mini_Project.ViewComponents
{
    public class FooterViewComponent : ViewComponent
    {
        public async Task<IViewComponentResult> InvokeAsync()
        {
            return await Task.FromResult(View());
        }
    }
}
