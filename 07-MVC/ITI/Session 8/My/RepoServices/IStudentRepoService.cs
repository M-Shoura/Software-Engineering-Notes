using My.Models;

namespace My.RepoServices
{
    public interface IStudentRepoService
    {
        public IEnumerable<Student> GetAll();
        public Student GetStdDetails(int id);
        public void InsertStd(Student s);
        public void UpdateStd(Student s);
        public void DeleteStd(int id);
    }
}
