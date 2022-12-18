using MySql.Data.MySqlClient;

string connectionString = "connectionString";

MySqlConnection connection = new MySqlConnection(connectionString);
try
{
    Console.WriteLine("Connecting to MySQL...");
    connection.Open();
    
    string sql = @"SELECT e.emp_no, e.first_name, e.last_name, SUM(salary), MIN(s.from_date), MAX(s.to_date), eh.end_date FROM salaries AS s 
    JOIN (SELECT emp_no, MAX(eh.to_date) AS end_date FROM dept_emp AS eh GROUP BY eh.emp_no) AS eh ON eh.emp_no = s.emp_no
    JOIN employees as e ON e.emp_no = s.emp_no   
    WHERE eh.end_date < s.to_date
    GROUP BY e.emp_no;";
    MySqlCommand cmd = new MySqlCommand(sql, connection);
    MySqlDataReader reader = cmd.ExecuteReader();

    Console.WriteLine("Employee fullname -- Salary -- From date -- To date   -- End date");
    while (reader.Read())
    {
        Console.WriteLine(reader[1] + " " + reader[2] + "     -- " + reader[3] + " -- " + reader[4].ToString().Split()[0] + " -- " + reader[5].ToString().Split()[0] + " -- " + reader[6].ToString().Split()[0]);
    }
    reader.Close();
}
catch (Exception err)
{
    Console.WriteLine(err.ToString());
}

connection.Close();
Console.WriteLine("Connection Closed. Press any key to exit...");
Console.Read();