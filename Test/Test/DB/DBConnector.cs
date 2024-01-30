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

        

        public void connect()
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                try
                {
                    connection.Open();
                    MessageBox.Show("성공");
                    string queryString = "select * from dbo.Employee_";

                    SqlCommand cmd = new SqlCommand(queryString, connection);

                    SqlDataReader reader = cmd.ExecuteReader();
                    
                    while (reader.Read()) 
                    {
                        MessageBox.Show($"{reader[0]} + {reader[1]}");
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
        }


        #region 메인
        public DataSet getDepartmentDataSet()
        {
            DataSet ds = new DataSet();
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                try
                {
                    connection.Open();

                    string queryString = "select * from dbo.Department_ as D join dbo.Employee_ as E on D.id = E.depId;" ;

                    SqlCommand cmd = new SqlCommand(queryString, connection);

                    SqlDataAdapter adapter = new SqlDataAdapter(cmd);
                    adapter.Fill(ds);
                }
                catch(Exception ex)
                {
                    MessageBox.Show("실패" + ex);
                }
                finally
                {
                    connection.Close();
                }
                return ds;
            }
        }
        #endregion

        #region 사원
        public List<Department> getDepartments()
        {
            List<Department> list = new List<Department>();

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                try
                {
                    connection.Open();
                    string queryString = "select * from dbo.Department_";

                    SqlCommand cmd = new SqlCommand(queryString, connection);
                    
                    SqlDataReader reader = cmd.ExecuteReader();

                    while (reader.Read())
                    {
                        Department department = new Department(Int32.Parse(reader["id"].ToString()), reader["code"].ToString(), reader["name"].ToString(), reader["memo"].ToString());
                        list.Add(department);
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
        public int setEmployee(Employee employee)
        {
            using(SqlConnection connection = new SqlConnection(connectionString))
            {
                try
                {
                    connection.Open();
                    string queryString = $"insert into dbo.Employee_(depId, code, name, loginId, password, rank, state, phone, email, messengerId, memo, gender) " +
                        $"values ('{employee.depId}', '{employee.code}', '{employee.name}', '{employee.loginId}', '{employee.password}', '{employee.rank}', '{employee.state}', " +
                        $"'{employee.phone}', '{employee.email}', '{employee.messengerId}', '{employee.memo}', '{employee.gender}')";
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
        public int updateEmployee(Employee employee, int id)
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                try
                {
                    connection.Open();
                    string queryString = $"update dbo.Employee_ set depId = {employee.depId}, code = '{employee.code}', name = '{employee.name}', " +
                        $"rank = '{employee.rank}', state = '{employee.state}', phone = '{employee.phone}', email = '{employee.email}', " +
                        $"messengerId = '{employee.messengerId}', memo = '{employee.memo}', gender = '{employee.gender}' where id = {id}";
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
        public int deleteEmployee(int id)
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                try
                {
                    connection.Open();
                    string queryString = $"delete from dbo.Employee_ where id = {id}";
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
        
        public Employee getEmployeeById(int id)
        {
            Employee employee;
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                try
                {
                    connection.Open();
                    string queryString = $"select * from dbo.Employee_ where id = {id}";

                    SqlCommand cmd = new SqlCommand(queryString, connection);

                    SqlDataReader reader = cmd.ExecuteReader();

                    while (reader.Read())
                    {
                        employee = new Employee(Int32.Parse(reader["id"].ToString()), Int32.Parse(reader["depId"].ToString()), reader["code"].ToString(), reader["name"].ToString(),
                            reader["loginId"].ToString(), reader["password"].ToString(), reader["rank"].ToString(), reader["state"].ToString(), reader["phone"].ToString(), reader["email"].ToString(),
                            reader["messengerId"].ToString(), reader["memo"].ToString(), (char)reader["gender"]);
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
            return null;
        }
        #endregion

        #region 부서
        public DataSet getDepartment()
        {
            DataSet ds = new DataSet();
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                try
                {
                    connection.Open();

                    string queryString = "select * from dbo.Department_";

                    SqlCommand cmd = new SqlCommand(queryString, connection);

                    SqlDataAdapter adapter = new SqlDataAdapter(cmd);
                    adapter.Fill(ds);
                }
                catch (Exception ex)
                {
                    MessageBox.Show("실패" + ex);
                }
                finally
                {
                    connection.Close();
                }
                return ds;
            }
        }
        public int setDepartment(Department department)
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                try
                {
                    connection.Open();
                    string queryString = $"insert into dbo.Department_(code, name, memo) values ('{department.code}', '{department.name}', '{department.memo}')";
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
        public int updateDepartment(Department department)
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                try
                {
                    connection.Open();
                    string queryString = $"update dbo.Department_ set code = '{department.code}', name = '{department.name}', memo = '{department.memo}' where id = {department.id}";
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
        public int deleteDepartment(int id)
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                try
                {
                    connection.Open();
                    string queryString = $"delete from dbo.Department_ where id = {id}";
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
        #endregion
    }
}
