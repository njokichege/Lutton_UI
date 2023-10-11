﻿using MySql.Data.MySqlClient;

namespace FimiAppApi.Repository
{
    public class StudentClassRepository : IStudentClassRepository
    {
        private readonly DapperContext _dapperContext;

        public StudentClassRepository(DapperContext dapperContext)
        {
            _dapperContext = dapperContext;
        }
        public async Task<StudentModel> GetStudentClassById(int studentClassId)
        {
            string sql = "SELECT " +
                                "* " +
                         "FROM StudentClass WHERE StudentClass.StudentClassId = @StudentClassId";

            var parameteres = new DynamicParameters();
            parameteres.Add("StudentClassId", studentClassId);

            return await _dapperContext.LoadSingleData<StudentModel, dynamic>(sql, parameteres);
        }
        public async Task<StudentClassModel> AddStudentClass(StudentClassModel studentClassModel)
        {
            string sql = "INSERT INTO StudentClass " +
                            "(ClassId,StudentNumber) " +
                         "VALUES " +
                            "(@ClassId,@StudentNumber); SELECT LAST_INSERT_ID();";

            var parameters = new DynamicParameters();
            parameters.Add("ClassId", studentClassModel.ClassId, DbType.Int32);
            parameters.Add("StudentNumber", studentClassModel.StudentNumber, DbType.Int32);

            int id = await _dapperContext.LoadSingleData<int, dynamic>(sql, parameters);

            var createdModel = new StudentClassModel
            {
                StudentClassId = id,
                ClassId = studentClassModel.ClassId,
                StudentNumber = studentClassModel.StudentNumber
            };
            return createdModel;
        }
        public async Task AddStudentClassBulk(List<StudentClassModel> studentClasses)
        {
            StringBuilder sql = new StringBuilder("INSERT INTO StudentClass (ClassId,StudentNumber) VALUES ");

            List<string> rows = new List<string>();
            foreach(var studentClass in studentClasses)
            {
                for (int i = 0; i < 100000; i++)
                {
                    rows.Add(string.Format("('{0}','{1}')", MySqlHelper.EscapeString($"{studentClass.StudentNumber}"), MySqlHelper.EscapeString($"]")));
                }
            }
        }
    }
}
