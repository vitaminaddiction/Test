using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Test.DB
{
    class DBConnector
    {
        public string DbSource = "localhost";
        public string DbName = "Test";
        public string DbUser = "test";
        public string DbPassword = "1234";

        public string connectionString;

        public DBConnector()
        {
            connectionString = $"Data Source={DbSource};" +
                               $"Initial Catalog={DbName};" +
                               $"User ID={DbUser};" +
                               $"Password={DbPassword};";

        }

        public DataSet DataAdapter(string queryString)
        {
            DataSet ds = new DataSet();
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                try
                {
                    connection.Open();
                    SqlCommand cmd = new SqlCommand(queryString, connection);
                    SqlDataAdapter adapter = new SqlDataAdapter(cmd);
                    adapter.Fill(ds);
                }
                catch (Exception ex)
                {
                    MessageBox.Show("오류" + ex);
                }
                finally
                {
                    connection.Close();
                }
                return ds;
            }
        }
        public int NonQuery(string queryString)
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                try
                {
                    connection.Open();
                    SqlCommand cmd = new SqlCommand(queryString, connection);
                    int result = cmd.ExecuteNonQuery();
                    return result;
                }
                catch (Exception ex)
                {
                    MessageBox.Show("실패" + ex);
                    return -1;
                }
                finally
                {
                    connection.Close();
                }
            }
        }
        //https://blog.naver.com/dbswn2414/221865765728
        //https://coderzero.tistory.com/entry/%EC%9C%A0%EB%8B%88%ED%8B%B0-C-%EA%B0%95%EC%A2%8C-18-%EC%9D%B5%EB%AA%85-%ED%98%95%EC%8B%9DAnonymous-Type-%EC%9D%B5%EB%AA%85-%EB%A9%94%EC%84%9C%EB%93%9CAnonymous-Method-%EB%9E%8C%EB%8B%A4%EC%8B%9DLambda-Expression
        public List<T> GetList<T>(string queryString, Func<SqlDataReader, T> classMapping)
        {
            List<T> list = new List<T>();

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                try
                {
                    connection.Open();
                    SqlCommand cmd = new SqlCommand(queryString, connection);

                    SqlDataReader reader = cmd.ExecuteReader();

                    while (reader.Read())
                    {
                        T obj = classMapping(reader);
                        list.Add(obj);
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("실패" + ex);
                }
                finally
                {
                    connection.Close();
                }
            }
            return list;
        }

        #region 메인
        public List<DepEmp> GetDataSourse()
        {
            string queryString = "select * from dbo.Department_ as D join dbo.Employee_ as E on D.id = E.depId;";
            List<DepEmp> list = GetList(queryString, reader =>
            {
                return new DepEmp(
                    Int32.Parse(reader[0].ToString()),
                    reader[1].ToString(),
                    reader[2].ToString(),
                    reader[3].ToString(),
                    Int32.Parse(reader[4].ToString()),
                    Int32.Parse(reader[5].ToString()),
                    reader[6].ToString(),
                    reader[7].ToString(),
                    reader[8].ToString(),
                    reader[9].ToString(),
                    reader[10].ToString(),
                    reader[11].ToString(),
                    reader[12].ToString(),
                    reader[13].ToString(),
                    reader[14].ToString(),
                    reader[15].ToString(),
                    Char.Parse(reader[16].ToString().Trim())
                    );
            });
            return list;
        }
        #endregion

        #region 사원
        public List<DepartmentForDB> GetDepartments()
        {
            string queryString = "select * from dbo.Department_";

            List<DepartmentForDB> list = GetList(queryString, reader => 
            {
                return new DepartmentForDB(
                    Int32.Parse(reader["id"].ToString()), 
                    reader["code"].ToString(), 
                    reader["name"].ToString(), 
                    reader["memo"].ToString()
                    );
            });
            return list;
        }
        public int SetEmployee(EmployeeForDB employee)
        {
            string queryString = $"insert into dbo.Employee_(depId, code, name, loginId, password, rank, state, phone, email, messengerId, memo, gender) " +
                        $"values ('{employee.depId}', '{employee.code}', '{employee.name}', '{employee.loginId}', '{employee.password}', '{employee.rank}', '{employee.state}', " +
                        $"'{employee.phone}', '{employee.email}', '{employee.messengerId}', '{employee.memo}', '{employee.gender}')";

            return NonQuery(queryString);
        }
        public int UpdateEmployee(EmployeeForDB employee)
        {
            string queryString = $"update dbo.Employee_ set depId = {employee.depId}, code = '{employee.code}', name = '{employee.name}', " +
                        $"rank = '{employee.rank}', state = '{employee.state}', phone = '{employee.phone}', email = '{employee.email}', " +
                        $"messengerId = '{employee.messengerId}', memo = '{employee.memo}', gender = '{employee.gender}' where id = {employee.id}";

            return NonQuery(queryString);
        }
        public int DeleteEmployee(int id)
        {
            string queryString = $"delete from dbo.Employee_ where id = {id}";

            return NonQuery(queryString);
        }
        public int UpdateLoginID(EmployeeForDB employee)
        {
            string queryString = $"update dbo.Employee_ set loginId = '{employee.loginId}', password = '{employee.password}' where id = {employee.id}";

            return NonQuery(queryString);
        }
        #endregion

        #region 부서
        public int SetDepartment(DepartmentForDB department)
        {
            string queryString = $"insert into dbo.Department_(code, name, memo) values ('{department.code}', '{department.name}', '{department.memo}')";

            return NonQuery(queryString);
        }
        public int UpdateDepartment(DepartmentForDB department)
        {
            string queryString = $"update dbo.Department_ set code = '{department.code}', name = '{department.name}', memo = '{department.memo}' where id = {department.id}";

            return NonQuery(queryString);
        }
        public int DeleteDepartment(int id)
        {
            string queryString = $"delete from dbo.Department_ where id = {id}";

            return NonQuery(queryString);
        }
        #endregion
    }
}
