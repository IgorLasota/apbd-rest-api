using System.Data.SqlClient;
using Newtonsoft.Json;
using RestApi.DTO;
using RestApi.Interface;
using RestApi.Model;

namespace RestApi.Service;

public class AnimalService : IAnimalService
{
    private readonly IConfiguration _configuration;

    public AnimalService(IConfiguration configuration)
    {
        _configuration = configuration;
    }

    public List<AnimalOutputDto> GetAnimals(string orderBy)
    {
        List<AnimalOutputDto> animals = new List<AnimalOutputDto>();

        string queryString = $"SELECT * FROM dbo.Animals ORDER BY {orderBy} ASC;";
        string connectionString = _configuration.GetConnectionString("AnimalDatabase");
        
        using (var connection = new SqlConnection(connectionString))
        {
            var command = new SqlCommand(queryString, connection);
            connection.Open();
            var reader = command.ExecuteReader();
            while (reader.Read())
            {
                animals.Add(new AnimalOutputDto()
                {
                    IdAnimal = reader.GetInt32(0),
                    Name = reader.GetString(1).Trim(),
                    Description = reader.GetString(2).Trim(),
                    Category = reader.GetString(3).Trim(),
                    Area = reader.GetString(4).Trim()
                });
            }
        }

        return animals;
    }

    public void CreateAnimal(AnimalInputDto animal)
    {
        string queryString = "INSERT INTO dbo.Animals (Name, Description, Category, Area) VALUES (@Name, @Description, @Category, @Area);";
        string connectionString = _configuration.GetConnectionString("AnimalDatabase");

        using (var connection = new SqlConnection(connectionString))
        {
            var command = new SqlCommand(queryString, connection);
            command.Parameters.AddWithValue("@Name", animal.Name);
            command.Parameters.AddWithValue("@Description", animal.Description);
            command.Parameters.AddWithValue("@Category", animal.Category);
            command.Parameters.AddWithValue("@Area", animal.Area);
            connection.Open();
            command.ExecuteNonQuery();
        }
    }

    public void UpdateAnimal(int id, AnimalInputDto animal)
    {
        string queryString = "UPDATE dbo.Animals SET Name = @Name, Description = @Description, Category = @Category, Area = @Area WHERE IdAnimal = @IdAnimal;";
        string connectionString = _configuration.GetConnectionString("AnimalDatabase");

        using (var connection = new SqlConnection(connectionString))
        {
            var command = new SqlCommand(queryString, connection);
            command.Parameters.AddWithValue("@Name", animal.Name);
            command.Parameters.AddWithValue("@Description", animal.Description);
            command.Parameters.AddWithValue("@Category", animal.Category);
            command.Parameters.AddWithValue("@Area", animal.Area);
            command.Parameters.AddWithValue("@IdAnimal", id);
            connection.Open();
            command.ExecuteNonQuery();
        }
    }

    public void DeleteAnimal(int id)
    {
        string queryString = "DELETE FROM dbo.Animals WHERE IdAnimal = @IdAnimal;";
        string connectionString = _configuration.GetConnectionString("AnimalDatabase");

        using (var connection = new SqlConnection(connectionString))
        {
            var command = new SqlCommand(queryString, connection);
            command.Parameters.AddWithValue("@IdAnimal", id);
            connection.Open();
            command.ExecuteNonQuery();
        }
    }
}