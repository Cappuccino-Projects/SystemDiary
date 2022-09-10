using ClientAPI;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace SystemDiaryClient.Pages
{
    public class IndexModel : PageModel
    {

        public string UserName { get; set; }
        public string WelkomeMessage { get; set; }

        public async Task OnGetAsync()
        {
            var client = new Client();

            var date = DateTime.Now;

            var identity = User.Identity.Name;

            var user = client.GetUserData(identity).Result;

            WelkomeMessage = (date.Hour >= 12 && date.Hour <= 17) ? 
                "Добрый день" : 
                (date.Hour >= 18 && date.Hour <= 23) ? 
                "Добрый вечер" : 
                (date.Hour >= 0 && date.Hour <= 6) ? 
                "Доброй ночи" : 
                (date.Hour >= 7 && date.Hour <= 11) ? 
                "Доброе утро" : "NOOP";

            UserName = user.Name;
        }
    }
}