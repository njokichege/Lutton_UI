namespace FimiAppLibrary.DataAccess
{
    public class StudentData : IStudentData
    {
        private readonly ISqlDbConnection _db;

        public StudentData(ISqlDbConnection db)
        {
            _db = db;
        }
        public Task<List<StudentModel>> GetStudent()
        {
            string sql = "SELECT * FROM dbo.Student";
            return _db.LoadData<StudentModel, dynamic>(sql, new { });
        }
        public Task InsertStudent(StudentModel student)
        {
            string sql = @"INSERT INTO dbo.Student(FirstName, MiddleName, Surname)
                            VALUES (@FirstName, @MiddleName, @Surname)";
            return _db.SaveData(sql, student);
        }
        public Task GetStudentsInClass(string stream, string sessionYear, int form)
        {
            
            string sql = "SELECT * FROM Student " +
                "INNER JOIN StudentClass ON StudentClass.StudentId = Student.StudentNumber" +
                "INNER JOIN Class ON Class.ClassId = StudentClass.ClassId" +
                "INNER JOIN Form ON Form.FormId = Class.FormId" +
                "INNER JOIN Stream ON Stream.StreamId = Class.StreamId" +
                "INNER JOIN SessionYear ON SessionYear.SessionYearId = Class.SessionYearId";
            return _db.LoadData<StudentModel, dynamic>(sql, new { });
        }
    }
}
