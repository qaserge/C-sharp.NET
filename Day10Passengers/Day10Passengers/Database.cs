using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Day10Passengers
{
    public class Database
    {
        private SqlConnection conn;

        // Note: Handle SqlException and SystemException when using constructor
        public Database()
        {
            conn = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Users\1896190\Documents\ipd17-dotnet\Day10Passengers\PassengersDB.mdf;Integrated Security=True;Connect Timeout=30");
            conn.Open();
        }

        public List<Passenger> GetAllPassengers()
        {
            List<Passenger> result = new List<Passenger>();
            SqlCommand command = new SqlCommand("SELECT * FROM Passengers", conn);
            using (SqlDataReader reader = command.ExecuteReader())
            {
                // while there is another record present
                while (reader.Read())
                {
                    int id = (int)reader["Id"];
                    string name = (string)reader["Name"];
                    string passport = (string)reader["Passport"];
                    string destination = (string)reader["Destination"];
                    DateTime departDate = (DateTime)reader["DepartDate"];
                    //string departTime = (string)reader["DepartTime"];


                    //double engineSizeL = (double)reader["EngineSize"];
                    // FIXME: decided what to do with parsing exception
                    //FuelType fuelType = (FuelType)Enum.Parse(typeof(FuelType), (string)reader["FuelType"]);

                    Passenger passenger = new Passenger() { Id = id, Name = name, Destination=destination, Passport = passport, DepartDate= departDate};
                    result.Add(passenger);
                }
            }
            return result;
        }

        public void AddPassenger(Passenger passenger)
        {
            SqlCommand command = new SqlCommand("INSERT INTO Passengers (Name, Passport, Destination, DepartDate) VALUES (@Name, @Passport, @Destination, @DepartDate)", conn);
            command.Parameters.AddWithValue("@Name", passenger.Name);
            command.Parameters.AddWithValue("@Passport", passenger.Passport);
            command.Parameters.AddWithValue("@Destination", passenger.Destination);
            command.Parameters.AddWithValue("@DepartDate", passenger.DepartDate);
            command.ExecuteNonQuery();
        }

        public void UpdatePassenger(Passenger passenger)
        {
            SqlCommand command = new SqlCommand("UPDATE Passengers SET Name=@Name, Passport=@Passport, Destination=@Destination, DepartDate=@DepartDate,  WHERE Id=@Id", conn);
            command.Parameters.AddWithValue("@Name", passenger.Name);
            command.Parameters.AddWithValue("@Passport", passenger.Passport);
            command.Parameters.AddWithValue("@Destination", passenger.Destination);
            command.Parameters.AddWithValue("@DepartDate", passenger.DepartDate);
            command.Parameters.AddWithValue("@Id", passenger.Id);
            command.ExecuteNonQuery();
        }

        public void DeletePassenger(int id)
        {
            SqlCommand command = new SqlCommand("DELETE FROM Passengers WHERE Id=@Id", conn);
            command.Parameters.AddWithValue("@Id", id);
            command.ExecuteNonQuery();
        }


    }
}

/*

CREATE TABLE [dbo].[Passengers]
(
	[Id] INT NOT NULL PRIMARY KEY IDENTITY, 
    [MakeModel] NVARCHAR(50) NOT NULL, 
    [EngineSize] FLOAT NOT NULL, 
    [FuelType] NVARCHAR(20) NOT NULL, 
    CONSTRAINT [CK_Passengers_Column] CHECK (FuelType IN ('Gasoline', 'Diesel', 'Hybrid', 'Electric', 'Propane', 'Alcohol'))
)


*/
