using mongodbplusApi.Models;
using MongoDB.Driver;
namespace mongodbplusApi.Services
{
    public class StudentServices : IStudentServices
    {
        private readonly IMongoCollection<Student> _students;

        public StudentServices(IStudentStoreDatabaseSettings settings, IMongoClient mongoClient)
        {
            var database = mongoClient.GetDatabase(settings.DatabaseName);
            _students=database.GetCollection<Student>(settings.StudentCourseCollectionName);
        }
        public Student Create(Student student)
        {
            _students.InsertOne(student);
            return student;
        }

        public void Delete(string id)
        {
            _students.DeleteOne(student => student.Id == id);
        }

        public List<Student> Get()
        {
          return  _students.Find(student => true).ToList();

        }

        public Student Get(string id)
        {
            return _students.Find(student => student.Id == id).FirstOrDefault();
        }

        public void Update(string id, Student student)
        {
            _students.ReplaceOne(student => student.Id == id, student);
        }
    }
}
