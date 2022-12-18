using MySql.Data.MySqlClient;

string connStr = "connectionString";

MySqlConnection conn = new MySqlConnection(connStr);
try
{
    Console.WriteLine("Connecting to MySQL...");
    conn.Open();
    
    string sql = @"SELECT e.emp_no, e.first_name, e.last_name, SUM(salary), MIN(s.from_date), MAX(s.to_date), eh.end_date FROM salaries as s 
    JOIN (SELECT emp_no, MAX(eh.to_date) as end_date FROM dept_emp AS eh GROUP BY eh.emp_no) as eh ON eh.emp_no = s.emp_no
    JOIN employees as e ON e.emp_no = s.emp_no   
    WHERE eh.end_date < s.to_date
    GROUP BY e.emp_no;";
    MySqlCommand cmd = new MySqlCommand(sql, conn);
    MySqlDataReader rdr = cmd.ExecuteReader();

    Console.WriteLine("Employee fullname -- Salary -- From date -- To date   -- End date");
    while (rdr.Read())
    {
        Console.WriteLine(rdr[1] + " " + rdr[2] + "     -- " + rdr[3] + " -- " + rdr[4].ToString().Split()[0] + " -- " + rdr[5].ToString().Split()[0] + " -- " + rdr[6].ToString().Split()[0]);
    }
    rdr.Close();
}
catch (Exception err)
{
    Console.WriteLine(err.ToString());
}

conn.Close();
Console.WriteLine("Connection Closed. Press any key to exit...");
Console.Read();