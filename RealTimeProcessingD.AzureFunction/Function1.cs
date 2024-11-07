using Microsoft.Data.SqlClient;  // Updated namespace
using System;
using System.IO;
using Microsoft.AspNetCore.Http;
using Microsoft.Azure.Functions.Worker;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;
using Microsoft.Azure.WebJobs;

public static class ProcessHealthData
{
    [FunctionName("ProcessHealthData")]
    public static async Task Run(
        [HttpTrigger(AuthorizationLevel.Function, "post")] HttpRequest req,
        ILogger log)
    {
        // Read the health data from the HTTP request body
        string requestBody = await new StreamReader(req.Body).ReadToEndAsync();
        var healthData = JsonConvert.DeserializeObject<HealthRecord>(requestBody);

        // Log the received data (for debugging)
        log.LogInformation($"Received health data for Patient ID: {healthData.PatientId}, Vital Sign: {healthData.VitalSignType}, Value: {healthData.Value}");

        // SQL Connection to Azure SQL Database
        string connectionString = Environment.GetEnvironmentVariable("SqlConnectionString");

        using (var connection = new SqlConnection(connectionString))
        {
            await connection.OpenAsync();

            // Insert health record into the database
            var command = new SqlCommand(
                "INSERT INTO HealthRecords (PatientId, Timestamp, VitalSignType, Value) VALUES (@PatientId, @Timestamp, @VitalSignType, @Value)",
                connection);
            command.Parameters.AddWithValue("@PatientId", healthData.PatientId);
            command.Parameters.AddWithValue("@Timestamp", healthData.Timestamp);
            command.Parameters.AddWithValue("@VitalSignType", healthData.VitalSignType);
            command.Parameters.AddWithValue("@Value", healthData.Value);

            await command.ExecuteNonQueryAsync();
        }

        log.LogInformation("Health data processed and saved to database.");
    }
}

public class HealthRecord
{
    public int PatientId { get; set; }
    public DateTime Timestamp { get; set; }
    public string VitalSignType { get; set; }
    public double Value { get; set; }
}

