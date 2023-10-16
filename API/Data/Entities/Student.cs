using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Identity;

namespace API.Data.Entities
{
    /// <summary>
    /// Student
    /// </summary>
    public class Student : User
    {
        /// <summary>
        /// Student Join Classes
        /// </summary>
        public virtual IEnumerable<StudentJoinClass>? StudentJoinClasses { get; set; }

        /// <summary>
        /// Student Join Tests
        /// </summary>
        public virtual IEnumerable<StudentJoinTest>? StudentJoinTests { get; set; }


        /// <summary>
        /// Student Join Tests
        /// </summary>
        public virtual IEnumerable<TestAnswer>? TestAnswers { get; set; }
    }
}
