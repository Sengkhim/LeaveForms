
using Domain.Authentication;

namespace Domain.Entites
{
    public class Student
    {
        public Guid StudentId { get; set; } 
        public Guid UserId { get; set; }
        public string? Name { get; set; }    
        public int Age { get; set; }
        public DateTime Date { get; set; }
        public User? user { get; set; }
    }
}
