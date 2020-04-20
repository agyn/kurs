
namespace Kurs.Identity.Data.Model
{
    public class UserForLogin
    {
        public int Id { get; set; }
        public string Pwdhash { get; set; }
        public string Login { get; set; }
    }
}