using ClientAPI;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace SystemDiaryClient.Pages
{
    [Authorize]
    public class ProfileModel : PageModel
    {
        public string UserName { get; set; }
        public string Surname { get; set; }
        public string FatherName { get; set; }
        public string Email { get; set; }
        public string Role { get; set; }

        public async Task OnGetAsync()
        {
            var client = new Client();

            var identity = User.Identity.Name;

            var userData = client.GetUserData(identity).Result;
            var role = client.GetUserRole(identity).Result;

            UserName = userData.Name;
            Surname = userData.Surname;
            FatherName = userData.Fathername;
            Email = userData.Email;
            Role = role;
        }
    }
}
