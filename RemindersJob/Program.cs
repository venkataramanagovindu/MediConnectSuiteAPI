using System;
using System.Data.SqlClient;
using System.Timers;

namespace RemindersJob;
class Program
{
    private static System.Timers.Timer timer;
    private static string connectionString = "Server=your_server_name; Database=your_database_name; User Id=your_username; Password=your_password;";
    private static string sqlUpdate = "UPDATE Users SET Status = @NewStatus WHERE UserId = @UserId;";

    static void Main(string[] args)
    {
        SetTimer();
        Console.WriteLine("Press 'Enter' to exit the application...");
        Console.ReadLine();

        timer.Stop();
        timer.Dispose();
        Console.WriteLine("Terminating the application.");
    }

    private static void SetTimer()
    {
        // Set the timer for 5 minutes (300,000 milliseconds).
        timer = new System.Timers.Timer(300000);
        timer.Elapsed += OnTimedEvent;
        timer.AutoReset = true;
        timer.Enabled = true;
    }

    private static void OnTimedEvent(Object source, ElapsedEventArgs e)
    {
        Console.WriteLine("Executing SQL Update at: {0:HH:mm:ss.fff}", e.SignalTime);
        UpdateDatabase();
    }

    private static void UpdateDatabase()
    {
        // Using the SqlConnection class to connect to the database
        using (SqlConnection con = new SqlConnection(connectionString))
        {
            try
            {
                // Open the SqlConnection
                con.Open();
                Console.WriteLine("Connection successfully opened.");

                // SqlCommand object to execute the SQL update statement
                using (SqlCommand cmd = new SqlCommand(sqlUpdate, con))
                {
                    // Set the parameters for the SQL command
                    cmd.Parameters.AddWithValue("@UserId", 1); // Example user ID
                    cmd.Parameters.AddWithValue("@NewStatus", "Active"); // Example new status

                    // Execute the SqlCommand
                    int rowsAffected = cmd.ExecuteNonQuery();

                    // Output the number of rows affected
                    Console.WriteLine("Rows affected: " + rowsAffected);
                }

                // Close the connection
                con.Close();
                Console.WriteLine("Connection closed.");
            }
            catch (SqlException ex)
            {
                // Handle SQL exceptions here
                Console.WriteLine("SQL Error: " + ex.ToString());
            }
            catch (Exception ex)
            {
                // Handle general exceptions here
                Console.WriteLine("Error: " + ex.ToString());
            }
        }
    }
}
