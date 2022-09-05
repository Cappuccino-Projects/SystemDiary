using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace SystemDiaryClient.Pages.Admin
{
    [Authorize]
    public class UserListModel : PageModel
    {
        public void OnGet()
        {
        }
    }
}
