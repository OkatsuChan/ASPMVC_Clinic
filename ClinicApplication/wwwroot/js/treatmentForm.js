document.addEventListener('DOMContentLoaded', function () {
    var treatmentTypeSelect = document.getElementById('treatmentType');
    var restorativeFields = document.getElementById('restorativeFields');
    var extractionFields = document.getElementById('extractionFields');

    function updateFields() {
        var treatmentType = treatmentTypeSelect.value;

        // Hide all fields initially
        restorativeFields.style.display = 'none';
        extractionFields.style.display = 'none';

        // Show fields based on selected treatment type
        if (treatmentType === 'Restorative') {
            restorativeFields.style.display = 'block';
        } else if (treatmentType === 'Extraction') {
            extractionFields.style.display = 'block';
        }
        // Add conditions for other treatments as needed
    }

    // Attach change event handler
    treatmentTypeSelect.addEventListener('change', updateFields);

    // Initialize on page load
    updateFields();
});