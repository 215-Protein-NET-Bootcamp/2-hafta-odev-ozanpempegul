using DatabaseHomework.DbProvider;
using DatabaseHomework.Models;

namespace DatabaseHomework.Repository;

public class DepartmentRepository : IDepartmentRepository
{
    private readonly IDapperDbProvider _dapperDbProvider;

    private const string InsertDepartmentSqlStatement = @"INSERT INTO department (DepartmentId, DeptName, CountryId) VALUES(@Id, @DeptName, @CountryId)";
    private const string SelectDepartmentSqlStatement = @"SELECT * FROM department WHERE DepartmentId = @Id LIMIT 1";
    private const string SelectAllDepartmentsSqlStatement = @"SELECT * FROM department LIMIT 50";
    private const string DeleteDepartmentSqlStatement = @"DELETE department WHERE CountryId = @Id LIMIT 1";

    public DepartmentRepository(IDapperDbProvider dapperDbProvider)
    {
        _dapperDbProvider = dapperDbProvider;
    }

    public async Task SaveDepartment(Department department)
    {
        using var connection = _dapperDbProvider.GetConnection();

        await _dapperDbProvider.ExecuteAsync(connection, InsertDepartmentSqlStatement, department);
    }

    public async Task<Department> GetDepartment(int id)
    {
        using var connection = _dapperDbProvider.GetConnection();

        return await _dapperDbProvider.QueryFirstOrDefaultAsync<Department>(connection, SelectDepartmentSqlStatement, new { Id = id });
    }

    public async Task<IEnumerable<Department>> GetAllDepartments()
    {
        using var connection = _dapperDbProvider.GetConnection();

        return await _dapperDbProvider.QueryAsync<Department>(connection, SelectAllDepartmentsSqlStatement);
    }

    public async Task<Department> DeleteDepartment(int id)
    {
        using var connection = _dapperDbProvider.GetConnection();

        return await _dapperDbProvider.QueryFirstOrDefaultAsync<Department>(connection, DeleteDepartmentSqlStatement, new { Id = id });
    }
}
