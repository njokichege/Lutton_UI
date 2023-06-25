﻿
using FimiAppApi.Context;
using Microsoft.SqlServer.Server;
using System.Data.SqlClient;
using System.Security.Claims;

namespace FimiAppApi.Repository
{
    public class ClassRepository : IClassRepository
    {
        private readonly DapperContext _context;
        public ClassRepository(DapperContext context)
        {
            _context = context;
        }
        public async Task<ClassModel> CreateClass(ClassForCreationDto classForCreation)
        {
            string sql = "INSERT INTO Class" +
                "(FormId,StreamId,SessionYearId,Capacity,ClassTeacherId)" +
                "VALUES" +
                "(@FormId,@StreamId,@SessionYearId,@Capacity,@ClassTeacherId)" +
                "SELECT CAST(SCOPE_IDENTITY() AS INT)";
            var parameters = new DynamicParameters();
            parameters.Add("FormId", classForCreation.FormId, DbType.Int32);
            parameters.Add("StreamId", classForCreation.StreamId, DbType.Int32);
            parameters.Add("SessionYearId", classForCreation.SessionYearId, DbType.Int32);
            parameters.Add("Capacity", classForCreation.Capacity, DbType.Int32);
            parameters.Add("ClassTeacherId", classForCreation.ClassTeacherId, DbType.Int32);

            var id = await _context.AddData<ClassModel,dynamic>(sql, parameters);
            var createdClass = new ClassModel
            {
                ClassId = id,
                //FormId = classForCreation.FormId,
                //StreamId = classForCreation.StreamId,
                //SessionYearId = classForCreation.SessionYearId,
                //Capacity = classForCreation.Capacity,
                //ClassTeacherId = classForCreation.ClassTeacherId
            };
            return createdClass;
        }

        public async Task DeleteClass(int id)
        {
            string sql = "DELETE FROM dbo.Class WHERE ClassId=@Id";
            
            await _context.UpdateData<ClassModel, dynamic>(sql, new {id});
        }

        public async Task<ClassModel> GetClass(int id)
        {
            string sql = "SELECT * FROM dbo.Class WHERE ClassId = @Id";
            return await _context.LoadSingleData<ClassModel, dynamic>(sql, new { id });
        }

        public async Task<IEnumerable<ClassModel>> GetClasses()
        {
            string sql = "SELECT* FROM dbo.Class";
            return await _context.LoadData<ClassModel, dynamic>(sql, new { });
        }
        public async Task UpdateClassGrade(int id, ClassForUpdateGradesDto classForUpdate)
        {
            string sql = "UPDATE dbo.Class SET GradeId=@GradeId WHERE ClassId=@ClassId";
            var parameters = new DynamicParameters();
            parameters.Add("ClassId", id, DbType.Int32);
            parameters.Add("GradeId", classForUpdate.GradeId, DbType.Int32);

            await _context.UpdateData<ClassModel, dynamic>(sql, parameters);
        }
        public async Task<IEnumerable<ClassModel>> GetMultipleMapping()
        {
            string query = "SELECT \r\n    Class.ClassId,\r\n    Class.FormId,\r\n    Class.StreamId,\r\n    Class.TeacherId,\r\n    Form.FormId,\r\n    Form.Form,\r\n    Stream.StreamId,\r\n    Stream.Stream,\r\n    Teacher.TeacherId,\r\n    Staff.NationalId,\r\n    Staff.FirstName,\r\n    Staff.MiddleName,\r\n    Staff.Surname\r\nFROM Class\r\nINNER JOIN Form ON Class.FormId = Form.FormId\r\nINNER JOIN Stream ON Class.StreamId = Stream.StreamId\r\nINNER JOIN Teacher ON Class.TeacherId = Teacher.TeacherId\r\nINNER JOIN Staff ON Teacher.NationalId = Staff.NationalId\r\n";
            return await _context.MapMultipleObjects(query);
        }
    }
}
