using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Identity;

namespace API.Data.Entities
{
    /// <summary>
    /// StudentJoinClass
    /// </summary>
    public class StudentJoinClass
    {
        /// <summary>
        /// Id
        /// </summary>
        public Guid StudentJoinClassId { get; set; }

        /// <summary>
        /// Student Id
        /// </summary>
        public Guid StudentId { get; set; }

        /// <summary>
        /// Student
        /// </summary>
        public virtual Student? Student { get; set; }

        /// <summary>
        /// ClassId
        /// </summary>
        public Guid ClassId { get; set; }

        /// <summary>
        /// Class
        /// </summary>
        public virtual Class? Class { get; set; }
    }
}
