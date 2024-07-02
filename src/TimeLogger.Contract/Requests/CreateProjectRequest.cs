using System.ComponentModel.DataAnnotations;

namespace TimeLogger.Contract.Requests
{
    public class CreateProjectRequest
    {
        [Required]
        public string Name { get; set; } = default!;
    }
}
