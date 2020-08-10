using System.ComponentModel.DataAnnotations;

namespace AFORO255.MS.TEST.Security.Model
{
    public class Access
    {
        [Key]
        public int Id_User { get; set; }
        public string UserName { get; set; }
        public string Password { get; set; }
    }
}