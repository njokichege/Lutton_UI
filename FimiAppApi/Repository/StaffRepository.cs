using System.Reflection;

namespace FimiAppApi.Repository
{
    public class StaffRepository : IStaffRepository
    {
        private readonly DapperContext _dapperContext;

        public StaffRepository(DapperContext dapperContext)
        {
            _dapperContext = dapperContext;
        }
        public async Task<StaffModel> GetStaff(int nationalId)
        {
            string sql = "SELECT\r\n    * \r\nFROM Staff\r\nWHERE NationalId = @NationalId";
            var parameteres = new DynamicParameters();
            parameteres.Add("NationalId", nationalId,DbType.Int32);
            return await _dapperContext.LoadSingleData<StaffModel, dynamic>(sql, parameteres);
        }
        public async Task<int> AddStaff(StaffModel staff)
        {
            string sql = "INSERT INTO " +
                            "Staff " +
                                "(NationalId,FirstName,MiddleName,Surname,DateOfBirth,PhoneNumber,Gender,EmploymentDate,Designation) " +
                            "VALUES " +
                                "(@NationalId,@FirstName,@MiddleName,@Surname,@DateOfBirth,@PhoneNumber,@Gender,@EmploymentDate,@Designation)";
            var parameters = new DynamicParameters();
            parameters.Add("NationalId", staff.NationalId, DbType.Int32);
            parameters.Add("FirstName", staff.FirstName, DbType.String);
            parameters.Add("MiddleName", staff.MiddleName, DbType.String);
            parameters.Add("Surname", staff.Surname, DbType.String);
            parameters.Add("DateOfBirth",staff.DateOfBirth, DbType.String);
            parameters.Add("PhoneNumber", staff.PhoneNumber, DbType.String);
            parameters.Add("Gender", staff.Gender, DbType.String);
            parameters.Add("EmploymentDate", DateTime.Now, DbType.Date);
            parameters.Add("Designation", staff.Designation, DbType.String);

            return await _dapperContext.CreateData<StaffModel, dynamic>(sql, parameters);
        }
    }
}
