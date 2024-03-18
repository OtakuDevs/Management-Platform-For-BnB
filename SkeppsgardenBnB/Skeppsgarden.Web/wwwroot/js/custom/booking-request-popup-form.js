function validateForm() {
    let x = Number(document.querySelector(".number-people-input").value);
    if (x === 0) {
        alert("Please enter a valid number of people");
        console.log("Please enter a valid number of people");
    }
}


function openFormRequest(button, numberOfPeople, roomCapacity, roomNumber, price) {
    document.getElementById("id").value = $(button).attr('id');
    const modal = document.getElementById("requestModal");
    const roomNum = document.getElementById("roomNumber");
    const roomPrice = document.getElementById("totalPrice");
    
    roomNum.value = roomNumber;
    roomPrice.value = price;
    
    modal.style.display = "block";
    
    // hide the datepicker elements
    $('.qs-datepicker-container').css("visibility", "hidden");

    const numberOfPeopleInput = document.querySelector("#numberOfPeople");
    
    numberOfPeopleInput.innerHTML = '';
    
    for(let i = 1; i <= roomCapacity; i++) {
        const option = document.createElement('option');
        option.value = i.toString();
        option.text = i.toString();
        numberOfPeopleInput.appendChild(option);
    }
    
    numberOfPeopleInput.selectedIndex = numberOfPeople - 1;

    setTimePicker();

    window.onclick = function (event) {
        if (event.target === modal) {
            modal.style.display = "none";
        }
    }

}

function closeFormRequest() {
    document.getElementById("requestModal").style.display = "none";
    // show the datepicker elements
    $('.qs-datepicker-container').css("visibility", "visible");
}

function setTimePicker() {
    const checkInTimeInput = document.getElementById('checkInTime');
    const temp = '';
    
    checkInTimeInput.addEventListener('focus', function() {
        checkInTimeInput.value = '00:00:00';
    });
    
    
}

   
