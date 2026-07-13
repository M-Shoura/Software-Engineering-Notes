using System.ComponentModel.DataAnnotations;

namespace IKIA.PL.ViewModels.Departments
{
    public class DepartmentEditViewModel
    {
        public string Name { get; set; } = null!;
        public string Code { get; set; } = null!;
        public string? Description { get; set; }

        [Display(Name = "Creation Data [ViewM]")]
        public DateOnly CreationDate { get; set; }
    }
}
