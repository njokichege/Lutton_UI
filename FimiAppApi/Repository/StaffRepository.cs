using System.Reflection;
using System.Xml;

namespace FimiAppApi.Repository
{
    public class StaffRepository : IStaffRepository
    {
        private readonly DapperContext _dapperContext;

        public StaffRepository(DapperContext dapperContext)
        {
            _dapperContext = dapperContext;
        }
        public async Task<StaffModel> GetStaffById(int nationalId)
        {
            string sql = "SELECT\r\n    * \r\nFROM Staff\r\nWHERE NationalId = @NationalId";
            var parameteres = new DynamicParameters();
            parameteres.Add("NationalId", nationalId,DbType.Int32);
            return await _dapperContext.LoadSingleData<StaffModel, dynamic>(sql, parameteres);
        }
        public async Task<StaffModel> AddStaff(StaffModel staff)
        {
            string sql = "INSERT INTO " +
                            "Staff " +
                                "(NationalId,FirstName,MiddleName,Surname,DateOfBirth,PhoneNumber,Gender,EmploymentDate,Designation) " +
                            "VALUES " +
                                "(@NationalId,@FirstName,@MiddleName,@Surname,@DateOfBirth,@PhoneNumber,@Gender,@EmploymentDate,@Designation); SELECT LAST_INSERT_ID();";
            var parameters = new DynamicParameters();
            parameters.Add("NationalId", staff.NationalId, DbType.Int32);
            parameters.Add("FirstName", staff.FirstName, DbType.String);
            parameters.Add("MiddleName", staff.MiddleName, DbType.String);
            parameters.Add("Surname", staff.Surname, DbType.String);
            parameters.Add("DateOfBirth",staff.DateOfBirth, DbType.Date);
            parameters.Add("PhoneNumber", staff.PhoneNumber, DbType.String);
            parameters.Add("Gender", staff.Gender, DbType.String);
            parameters.Add("EmploymentDate", DateTime.Now, DbType.Date);
            parameters.Add("Designation", staff.Designation, DbType.String);

            int id = await _dapperContext.LoadSingleData<int, dynamic>(sql, parameters);
            var createdModel = new StaffModel
            {
                NationalId = staff.NationalId,
                FirstName = staff.FirstName,
                MiddleName = staff.MiddleName,
                Surname = staff.Surname,
                DateOfBirth = staff.DateOfBirth,
                PhoneNumber = staff.PhoneNumber,
                Gender = staff.Gender,
                EmploymentDate = DateTime.Now,
                Designation = staff.Designation
            };
            return createdModel;
        }
    }
}
