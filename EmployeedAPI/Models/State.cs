using System.ComponentModel.DataAnnotations;

namespace EmployeedAPI.Models
{
    public class State
    {
        [Key]
        public int IdState { get; set; }
        public string NameState { get; set; } = string.Empty;
    }
}
