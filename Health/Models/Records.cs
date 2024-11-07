using System.ComponentModel.DataAnnotations;

namespace Health.Models
{
   
    public class Patient
    {
        public int Id { get; set; }

        [Required]
        [StringLength(100)]
        public string Name { get; set; }

        [Required]
        public string Gender { get; set; }

        [Required]
        public DateTime BirthDate { get; set; }
    }

    public class HealthData
    {
        public int Id { get; set; }

        [Required]
        public int PatientId { get; set; }

        [Required]
        public DateTime Timestamp { get; set; }

        [Required]
        [Range(0, 200)] // Assuming heart rate should be between 0 and 200
        public double HeartRate { get; set; }

        [Required]
        [Range(0, 300)] // Assuming blood pressure should be between 0 and 300
        public double BloodPressure { get; set; }

        public Patient Patient { get; set; }
    }


}