
function downloadReceipt() {
    // Create a new jsPDF instance
    const pdf = new jsPDF('p', 'pt', 'a4');

    const titleText = document.querySelector('.result-request-details h2').textContent;
    pdf.text(titleText, 40, 30); // Add title to PDF
    
    // Define table columns and rows
    const columns = ['Field', 'Value'];
    const rows = [];

    // Iterate over labels and inputs inside .result-request-details
    document.querySelectorAll('.result-request-details label').forEach(label => {
        const parent = label.parentElement;
        if (parent.previousElementSibling && parent.previousElementSibling.tagName === 'H3') {
            const element = parent.previousElementSibling;
            rows.push([element.textContent, '']);
        }


        const fieldName = label.textContent;
        const fieldValue = label.nextElementSibling.value; // Get value from corresponding input
        rows.push([fieldName, fieldValue]);
    });

    // Set font size and font style
    pdf.setFontSize(12); // Font size
    pdf.setFont('helvetica', 'normal'); // Font family and style

    // Add table to PDF
    pdf.autoTable({
        head: [columns],
        body: rows,
        startY: 50, // Y-coordinate to start the table
        margin: { top: 20 }, // Top margin
    });


    // Save the PDF with the name 'receipt.pdf'
    pdf.save('reservation-request.pdf');
}


