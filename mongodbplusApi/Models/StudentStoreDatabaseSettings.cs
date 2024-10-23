namespace mongodbplusApi.Models
{
    public class StudentStoreDatabaseSettings : IStudentStoreDatabaseSettings
    {
        public string StudentCourseCollectionName { get; set; } = string.Empty;
        public string ConnectionString { get; set; }= string.Empty;
        public string DatabaseName { get; set; } = string.Empty;
    }
}
