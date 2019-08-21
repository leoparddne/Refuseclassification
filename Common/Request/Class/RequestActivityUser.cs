using System.ComponentModel.DataAnnotations;

namespace TianLeClass.Entity.Request.Class
{
    public class RequestActivityUser
    {
        public string phone;
        [Required(ErrorMessage = "NameNotNull")]
        public string name;
        public int grade;
        [Required(ErrorMessage = "SubjectNotNull")]
        public int[] subjects;
    }
}
