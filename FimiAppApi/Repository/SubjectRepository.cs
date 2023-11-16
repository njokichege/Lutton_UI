using FimiAppLibrary.Models;
using System.Xml;

namespace FimiAppApi.Repository
{
    public class SubjectRepository : ISubjectRepository
    {
        private readonly DapperContext _dapperContext;

        public SubjectRepository(DapperContext dapperContext)
        {
            _dapperContext = dapperContext;
        }
        public async Task<IEnumerable<SubjectModel>> GetSubjects()
        {
            string sql = "SELECT* FROM Subjects";
            var data = await _dapperContext.LoadData<SubjectModel, dynamic>(sql, new { });

            int index = 0;
            foreach (var item in data)
            {
                index++;
                item.Index = index;
            }
            return data;
        }
        public async Task<SubjectModel> GetSubjectId(int code)
        {
            string sql = "SELECT * " +
                            "FROM Subjects " +
                            "WHERE Subjects.Code = @Code";
            var parameteres = new DynamicParameters();
            parameteres.Add("Code", code, DbType.Int32);
            return await _dapperContext.LoadSingleData<SubjectModel, dynamic>(sql, parameteres);
        }
        public async Task<SubjectModel> CreateSubject(int code, string name, int category)
        {
            string sql = "INSERT INTO Subjects " +
                                "(Code,SubjectName,SubjectCategoryId) " +
                         "VALUES " +
                                "(@Code,@SubjectName,@SubjectCategoryId); SELECT LAST_INSERT_ID();";
            var parameters = new DynamicParameters();
            parameters.Add("Code", code, DbType.Int32);
            parameters.Add("SubjectName", name, DbType.String);
            parameters.Add("SubjectCategoryId", category, DbType.Int32);

            int id = await _dapperContext.LoadSingleData<int, dynamic>(sql, parameters);
            var createdModel = new SubjectModel
            {
                Code = id,
                SubjectName = name,
                SubjectCategoryId = category,
            };
            return createdModel;
        }
        public async Task<IEnumerable<SubjectModel>> MapSubjectOnCategory()
        {
            string sql = "SELECT " +
                            "Subjects.Code, " +
                            "Subjects.SubjectName, " +
                            "SubjectCategory.SubjectCategoryId, " +
                            "SubjectCategory.SubjectCategoryName " +
                         "FROM Subjects " +
                         "INNER JOIN SubjectCategory ON Subjects.SubjectCategoryId = SubjectCategory.SubjectCategoryId ";

            Type[] types =
            {
                 typeof(SubjectModel),
                 typeof(SubjectCategoryModel)
            };
            Func<object[], SubjectModel> map = delegate (object[] obj)
            {
                SubjectModel subjectModel = obj[0] as SubjectModel;
                SubjectCategoryModel subjectCategoryModel = obj[1] as SubjectCategoryModel;

                subjectModel.SubjectCategory = subjectCategoryModel;

                return subjectModel;
            };
            string splitOn = "SubjectCategoryId";

            var data = await _dapperContext.MapMultipleObjects<SubjectModel, dynamic>(sql, types, map, splitOn,new {});

            int index = 0;
            foreach (var item in data)
            {
                index++;
                item.Index = index;
            }
            return data;
        }
    }
}
