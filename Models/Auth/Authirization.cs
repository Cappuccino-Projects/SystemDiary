using Models.Abstract;
using System.ComponentModel.DataAnnotations;

namespace Models.Authirization
{
    public sealed class Authirization : AbstractModel
    {
        public string Login { get; set; } = "";
        
        [DataType(DataType.Password)]
        public string Password { get; set; } = "";
    }
}
