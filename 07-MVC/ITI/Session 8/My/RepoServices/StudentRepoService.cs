using Microsoft.EntityFrameworkCore;
using My.Models;

namespace My.RepoServices
{
    public class StudentRepoService : IStudentRepoService
    {
        private readonly MainDbContext _context;

        public StudentRepoService(MainDbContext context)
        {
            _context = context;
        }

        public IEnumerable<Student> GetAll()
        {
            return _context.Students.Include(x=>x.Department).ToList();
        }

        public Student GetStdDetails(int id)
        {
            return _context.Students.Include(x=>x.Department).FirstOrDefault(x=>x.StudentID == id);
        }

        public void InsertStd(Student s)
        {
            // if(ModelState.IsValid)            // Wrong here , ModelState is a controller property that can be found in the controller only.

            if(s != null)
            {
                _context.Students.Add(s);
                _context.SaveChanges();
            }
            
        }

        public void UpdateStd(Student s)
        {
            if(s != null)
            {
                var updateStd = _context.Students.AsNoTracking().FirstOrDefault(x => x.StudentID == s.StudentID);
                if(updateStd != null)
                {
                    // updatedStd.StdName = s.StdName;
                    // ........
                    // ........
                    // ........
                    // or directly 

                    _context.Students.Update(s);
                    _context.SaveChanges();
                }
            }
        }
        public void DeleteStd(int id)
        {
            var std = _context.Students.FirstOrDefault(x => x.StudentID == id);
            if(std != null)
            {
                _context.Remove(std);
                _context.SaveChanges();
            }
        }
    }
}
