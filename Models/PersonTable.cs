using System.ComponentModel.DataAnnotations;
using Dapper.Contrib.Extensions;

namespace Api.Models
{
    [Table("PersonTable")]
    public class PersonTable
    {
        public int Id { get; set; }
        [Required]
        public string FullName { get; set; }
        [Required]
        public int Age { get; set; }
    }
}