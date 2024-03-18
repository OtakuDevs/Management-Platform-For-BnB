document.addEventListener('DOMContentLoaded', function () {
    const createNewCustomerCheckbox = document.getElementById('createNewCustomer');
    const customerFields = document.getElementById('customerFields');
    const newCustomerFields = document.getElementById('newCustomerFields');
    const submitNewCustomerButton = document.getElementById('submitNewCustomer');


    // Toggle between customer selection and creating a new customer
    createNewCustomerCheckbox.addEventListener('change', function () {
        if (createNewCustomerCheckbox.checked) {
            customerFields.style.display = 'none';
            newCustomerFields.style.display = 'grid';
        } else {
            customerFields.style.display = 'grid';
            newCustomerFields.style.display = 'none';
        }
    });

    // Create a new customer
    submitNewCustomerButton.addEventListener('click', function () {
        // Perform AJAX request to submit new customer form
        [firstName, lastName, email, phoneNumber] = newCustomerFields.querySelectorAll('input');

        if (!firstName.value || !lastName.value || !email.value || !phoneNumber.value) {
            alert('Please fill in all customer fields');
            return;
        }

        const newCustomerData = {
            Id: uuidv4(),
            FirstName: firstName.value,
            LastName: lastName.value,
            Email: email.value,
            PhoneNumber: phoneNumber.value
        };

        const antiForgeryToken = $('input[name="__RequestVerificationToken"]').val();

        const jsonData = JSON.stringify(newCustomerData);

        $.ajax({
            url: "/Admin/AdminPanel/CreateNewCustomer",
            type: "POST",
            contentType: "application/json",
            dataType: "json",
            data: jsonData,
            headers: {
                'RequestVerificationToken': antiForgeryToken
            },
            success: function (result) {
                // Handle the success response
                console.log(result);
                updateCustomerDropdown(result);
            },
            error: function (error) {
                // Handle the error response
                console.log(error);
            }
        });

    });

    // Reloads the dropdown with the new customer and switches back to the customer selection dropdown
    function updateCustomerDropdown(result) {
        // Assuming there's a function to add a new option to the dropdown
        addOptionToDropdown(result.customer);

        // Optionally, you can switch back to the customer selection dropdown
        createNewCustomerCheckbox.checked = false;
        customerFields.style.display = 'block';
        newCustomerFields.style.display = 'none';
    }

    // Add a new option to the customer dropdown
    function addOptionToDropdown(newCustomer) {
        const customerDropdown = document.getElementById('customerDropdown');

        console.log('id:', newCustomer.id);
        console.log('firstName:', newCustomer.firstName);
        console.log('lastName:', newCustomer.lastName);
        // Assuming newCustomer has properties 'id' and 'firstName' and 'lastName'
        const option = document.createElement('option');
        option.value = newCustomer.id;
        option.text = `${newCustomer.firstName} ${newCustomer.lastName}`;
        customerDropdown.appendChild(option);
    }

    // Multistep form

    const form = document.getElementById('multiStepForm');
    const prevBtn = document.getElementById('prevBtn');
    const nextBtn = document.getElementById('nextBtn');
    const steps = form.getElementsByClassName('step');
    const validationModal = document.getElementById('validationModal');

    let currentStep = 0;

    // Show the first step by default
    showStep(currentStep);

    // Add click event listener to the previous button
    prevBtn.addEventListener('click', function () {
        if (currentStep > 0) {
            currentStep--;
            showStep(currentStep);
        }
    });

    // Add click event listener to the next button
    nextBtn.addEventListener('click', function () {
        // Check if the current step is valid before proceeding
        if (validateForm(currentStep)) {
            // Move to the next step if the current step is valid

            currentStep++;
            showStep(currentStep);
        } else {
            // Display the validation error modal
            validationModal.style.display = 'block';


            window.onclick = function (event) {
                if (event.target === validationModal) {
                    validationModal.style.display = "none";
                }
            }
        }
    });

    // Function to display the current step and hide the others
    function showStep(stepIndex) {
        for (let i = 0; i < steps.length; i++) {
            steps[i].style.display = 'none';
        }
        steps[stepIndex].style.display = 'block';

        if (stepIndex === 0) {
            prevBtn.style.display = 'none';
        } else {
            prevBtn.style.display = 'inline';
        }

        if (stepIndex === steps.length - 1) {
            nextBtn.style.display = 'none';
        } else {
            nextBtn.style.display = 'inline';
        }
    }

    // Function to validate the current step of the form if it has required fields
    function validateForm(step) {
        const currentForm = steps[step];
        const inputs = currentForm.querySelectorAll('input[required], select');

        for (let i = 0; i < inputs.length; i++) {
            validationModal.querySelector('p').textContent = 'Please fill in all required fields';
            if (inputs[i].value === '') {
                return false;
            }
            if (step === 2) {
                const numberOfPeople = document.querySelector('input[type="number"]');
                console.log(numberOfPeople);
                if (isNaN(numberOfPeople.value) || numberOfPeople.value <= 0) {
                    validationModal.querySelector('p').textContent = 'Number of people must be a number greater than 0';
                    return false;
                }
            }
        }
        return true;
    }
    
    // Add event listener to the check-in date input
    const checkInDate = document.getElementById('checkIn');
    checkInDate.addEventListener('change', updateSecondDate);

});

function updateSecondDate() {
    const secondDate = document.getElementById('checkOut');
    const firstDateObj = new Date(document.getElementById('checkIn').value);

    // Add one day to the first date
    firstDateObj.setDate(firstDateObj.getDate() + 1);
    
    // Set the minimum and value of the second date input
    secondDate.min = firstDateObj.toISOString().split('T')[0]; // Format as YYYY-MM-DD
    secondDate.value = firstDateObj.toISOString().split('T')[0]; // Format as YYYY-MM-DD
}

function closeValidationModal() {
    // Remove the modal from the document body
    const modal = document.querySelector('.modal');
    modal.style.display = 'none';
}

function generateSuggestions(customers) {
    const customerDropdown = document.getElementById('customerDropdown');
    const hiddenForCustomer = document.getElementById('hiddenForCustomer');
    const suggestionsList = document.getElementById('suggestions');
    const noMatchMessage = document.getElementById('noMatchMessage');

    // Add input event listener to the customer dropdown
    customerDropdown.addEventListener('input', function () {
        const input = this.value.trim().toLowerCase(); // Trim whitespace and convert to lowercase

        const filteredCustomers = customers.filter(customer => customer.text.toLowerCase().includes(input));

        suggestionsList.innerHTML = ''; // Clear previous suggestions
        noMatchMessage.style.display = 'none'; // Hide the no match message initially

        filteredCustomers.forEach(customer => {
            const option = document.createElement('option');
            option.value = customer.text;
            suggestionsList.appendChild(option);
        });

        if (filteredCustomers.length === 1 && filteredCustomers[0].text.toLowerCase() === input) {
            // If there's only one suggestion and it matches the input exactly
            customerDropdown.value = filteredCustomers[0].text;
            hiddenForCustomer.value = filteredCustomers[0].value;
        } else {
            hiddenForCustomer.value = ''; // Clear the hidden field if the input doesn't exactly match a suggestion
            if (input !== '' && filteredCustomers.length === 0) {
                noMatchMessage.style.display = 'block'; // Show the no match message
            }
        }
    });

    // Add tab and backspace keydown event listeners
    customerDropdown.addEventListener('keydown', function (event) {
        if (event.key === 'Tab') {
            const selectedCustomer = customers.find(customer => customer.text.toLowerCase() === this.value.trim().toLowerCase());
            if (selectedCustomer) {
                hiddenForCustomer.value = selectedCustomer.value;
            } else {
                hiddenForCustomer.value = '';
            }
        } else if (event.key === 'Backspace' && this.selectionStart === 0 && this.selectionEnd === 0) {
            hiddenForCustomer.value = '';
        }
    });

    // Add blur event listener
    customerDropdown.addEventListener('blur', function () {
        setTimeout(() => {
            suggestionsList.innerHTML = ''; // Clear suggestions on blur after a short delay
            noMatchMessage.style.display = 'none'; // Hide the message on blur
        }, 200);
    });

    // Handle changes after selecting a suggestion
    customerDropdown.addEventListener('change', function () {
        const selectedCustomer = customers.find(customer => customer.text.toLowerCase() === this.value.trim().toLowerCase());
        if (selectedCustomer) {
            hiddenForCustomer.value = selectedCustomer.value;
        } else {
            hiddenForCustomer.value = '';
            noMatchMessage.style.display = 'block'; // Show the no match message
        }
    });
}


