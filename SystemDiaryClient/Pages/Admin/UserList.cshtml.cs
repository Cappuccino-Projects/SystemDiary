using ClientAPI;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Models.Users;

namespace SystemDiaryClient.Pages.Admin
{
    [Authorize]
    public class UserListModel : PageModel
    {
        public List<UserModel> Users { get; set; }
        public Client Client { get => client; private set => client = value; }

        private Client client = new Client();
        
        public async Task OnGetAsync()
        {
            Users = client.GetAllUsers().Result;
        }
    }
}
