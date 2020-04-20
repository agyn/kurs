using System.ComponentModel.DataAnnotations;
using Newtonsoft.Json;

namespace Kurs.Identity.Data.Model
{
    public class LoginDto
    {
        //[Required, JsonProperty("login"), RegularExpression("^[0-9]+$"), StringLength(12)]
        public string Login { get; set; }

        [Required, JsonProperty("password")] 
        public string Password { get; set; }
    }
}