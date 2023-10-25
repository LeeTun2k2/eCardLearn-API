using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Identity;

namespace API.Data.Entities
{
    /// <summary>
    /// Teacher
    /// </summary>
    public class Teacher : User
    {
        /// <summary>
        /// Courses
        /// </summary>
        public virtual IEnumerable<Course>? Courses { get; set; }
    }
}
