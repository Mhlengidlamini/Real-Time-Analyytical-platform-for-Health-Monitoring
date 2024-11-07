--Add JavaScript for color change and 3D effect-- >
    @section Scripts {
    <script>
        // Change colors of buttons on hover
        const patientsBtn = document.getElementById('patientsBtn');
        const healthDataBtn = document.getElementById('healthDataBtn');

        patientsBtn.addEventListener('mouseover', function () {
            patientsBtn.style.backgroundColor = '#007bff'; // Blue color
        patientsBtn.style.transform = 'scale(1.1)';  // 3D hover effect
        });

        patientsBtn.addEventListener('mouseout', function () {
            patientsBtn.style.backgroundColor = ''; // Reset to default
        patientsBtn.style.transform = '';  // Remove scale effect
        });

        healthDataBtn.addEventListener('mouseover', function () {
            healthDataBtn.style.backgroundColor = '#6c757d'; // Grey color
        healthDataBtn.style.transform = 'scale(1.1)';  // 3D hover effect
        });

        healthDataBtn.addEventListener('mouseout', function () {
            healthDataBtn.style.backgroundColor = ''; // Reset to default
        healthDataBtn.style.transform = '';  // Remove scale effect
        });
    </script>
}
