using My.Models;
using System.ComponentModel.DataAnnotations;

namespace My.ViewModels
{
    public class StdDeptCrsLst_ViewModel
    {
        [Key]                                  // for making auto generating views applicable for this type , otherwise make it manually ! 
        public int StdID { get; set; }
        public string StdName { get; set; }
        public List<string> CourseList { get; set; }
        public int CourseHrs { get; set; }
        public Department Dept { get; set; }
    }

}
