document.addEventListener('DOMContentLoaded', function () {
    loadPagination();
    
    if (window.location.pathname === '/Admin/AdminPanel') {
        document.getElementById('btnRequests').classList.add('active');
        loadPartialViewOnClick(getUrlAction("RequestedRooms", "AdminPanel", "Admin"));
    }

    const adminButtons = document.querySelectorAll('.admin-button');
    adminButtons.forEach(function (button) {
        button.addEventListener('click', function () {

            // Remove the 'active' class from all buttons
            adminButtons.forEach(function (btn) {
                btn.classList.remove('active');
            });

            // Add the 'active' class to the clicked button
            this.classList.add('active');

            // Load partial view based on the clicked button
            if (this.id === 'btnEasyAdmin') {
                // Use 'redirect:' keyword to indicate a redirect
                loadPartialViewOnClick('redirect:' + getUrlAction("Index", "EasyAdmin", "easydata"));
            } else if (this.id === 'btnCalendar') {
                // Use 'redirect:' keyword to indicate a redirect
                loadPartialViewOnClick('redirect:' + getUrlAction("Index", "CalendarAdmin", "Admin"));
            }
        });
    });

    setTimeout(function () {
        const statusMessage = document.getElementById('statusMessage');
        if (statusMessage) {
            statusMessage.style.transition = 'opacity 1s';
            statusMessage.style.opacity = '0';
            setTimeout(function () {
                statusMessage.remove();
            }, 1000);
        }
    }, 6000); // 6000 milliseconds = 6 seconds
});

// Load partial view on pagination click
function loadPagination() {
    document.addEventListener('click', function (event) {
        if (event.target && event.target.matches('.pagination a')) {
            event.preventDefault();
            const container = event.target.closest('[data-url]');
            const url = container.dataset.url;
            const page = event.target.getAttribute('href').split('page=')[1];

            loadPartialViewOnClick(url + (page ? '?page=' + page : ''));
        }
    });
}

// Load partial view on button click
function loadPartialViewOnClick(url) {
    
    const partialViewContainer = document.getElementById('partialViewContainer');
    
    // Hide the container while loading
    partialViewContainer.style.display = 'none';
    
    // Check if the URL contains a keyword indicating it's a redirect
    if (url.includes('redirect:')) {
        // Extract the actual redirect URL
        // Redirect and halt further execution
        window.location.href = url.replace('redirect:', '');
        return;
    }

    // Perform the AJAX request for loading partial view
    const xhr = new XMLHttpRequest();
    xhr.open('GET', url, true);
    xhr.onreadystatechange = function () {
        if (xhr.readyState === 4) {
            if (xhr.status === 200) {
                // Get calendar or EasyData container and remove it if it has been loaded
                const calendar = document.getElementById('calendar-container');
                if (calendar) {
                    calendar.remove();
                }
                const easyData = document.getElementById('EasyDataContainer');
                if (easyData) {
                    easyData.remove();
                }
                
                // Load the partial view into the container
                partialViewContainer.innerHTML = xhr.responseText;
                
            } else {
                // Handle errors if needed
            }
        }
    };
    // Send the request
    xhr.send();
    
    // Show the container after some timeout (to prevent flickering)
    setTimeout(function () {
        addTooltip(partialViewContainer);

        partialViewContainer.style.display = 'block';
    }, 200);
    
}

function addTooltip(partialViewContainer) {
    if(window.innerWidth < 768) {
        //Append at the beginning of the container a message to inform the user to scroll right
        console.log('scroll right');
        const message = document.createElement('div');
        message.classList.add('scroll-right-message');
        message.innerHTML = "<p>Scroll table right to see more details</p>";

        //Insert the message above the table
        partialViewContainer.insertBefore(message, partialViewContainer.firstChild);
    }
}

// Helper function to generate URL action
function getUrlAction(action, controller, area) {
    let url = "";

    if (controller === "EasyAdmin") {
        return url = '/' + area;
    } else {
        url = '/' + area + '/' + controller + '/' + action + '?';
    }

    return url.slice(0, -1); // Remove the trailing '&'
}


function showReservationDetails(element) {
    const pagination = document.querySelector('span.page-link');
    pagination.style.display = 'none';
    
    const cells = element.querySelectorAll('.admin-reservation-table-cell');
    const elements = Array.from(cells).map(cell => cell.textContent.trim());
    
    
    // Create a simple modal dialog
    const modal = document.createElement('div');
    modal.classList.add('modal');
    modal.innerHTML = `
        <div class="modal-content">
            <div class="modal-text">
                <div class="modal-details-header">
                    <h2>Reservation Details</h2>
                    <span class="close" onclick="closeModal()">&times;</span>
                </div>
                    <div class="modal-details-top">
                        <div class="modal-details-left">
                            <div class="modal-details-element">
                                <p>Reservation Number:</p> 
                                 <span>${elements[0]}</span>
                            </div>
                            <div class="modal-details-element">
                                <p>Customer Name:</p> 
                                <span>${elements[1]}</span>
                            </div>
                            <div class="modal-details-element">
                                <p>Customer Email:</p>
                                <span>${elements[2]}</span>
                            </div>
                            <div class="modal-details-element">
                                <p>Room Number:</p>
                                <span>${elements[3]}</span>
                            </div>
                            <div class="modal-details-element">
                                <p>Number of Guests:</p>
                                <span>${elements[4]}</span>
                            </div>
                        </div>
                        <div class="modal-details-right">
                            <div class="modal-details-element">
                                <p>Number of Nights:</p> 
                                <span>${elements[5]}</span>
                            </div>
                            <div class="modal-details-element">
                                <p>Total Price:</p>
                                <span>${elements[6]}</span>
                            </div>
                            <div class="modal-details-element">
                                <p>Check In Date:</p>
                                <span>${elements[7]}</span>
                            </div>
                            <div class="modal-details-element">
                                <p>Check Out Date:</p> 
                                <span>${elements[8]}</span>
                            </div>
                            <div class="modal-details-element">
                                <p>Check In Time:</p> 
                                <span>${elements[9]}</span>
                            </div>
                        </div>
                    </div>
                <div class="modal-details-bottom">
                    <div class="modal-details-bottom-element">
                        <p>Notes From Guests:</p>
                        <textarea readonly>${elements[10]}</textarea>
                    </div>
                    <div class="modal-details-bottom-element">
                        <p>Notes From Owners:</p>
                        <textarea readonly>${elements[11]}</textarea>
                        </div>
                    </div>
                </div>
            </div>
    `;

    // Append the modal to the document body
    document.body.appendChild(modal);

    window.onclick = function (event) {
        if (event.target === modal) {
            modal.style.display = "none";
            pagination.style.display = 'block';
        }
    }
}

function showRequestDetails(element) {
    const pagination = document.querySelector('span.page-link');
    pagination.style.display = 'none';
    
    const id = element.querySelector('input[type="hidden"]');
    const cells = element.querySelectorAll('.admin-requests-table-cell');
    const elements = Array.from(cells).map(cell => cell.textContent.trim());
    const token = document.querySelector('input[name="__RequestVerificationToken"]').value;
    const reqId = id.value;
    
    // Create a simple modal dialog
    const modal = document.createElement('div');
    modal.classList.add('modal');
    
    modal.innerHTML = `
        <div class="modal-content">
            <div class="modal-text">
                <div class="modal-details-header">
                    <h2>Reservation Details</h2>
                    <span class="close" onclick="closeModal()">&times;</span>
                </div>
                <div class="modal-details-buttons">
                    <!-- Confirm reservation form -->
                    <form id="reservationConfirm" action="${getUrlAction("ConfirmReservation", "AdminPanel", "Admin")}" method="post">
                        <input type="hidden" name="id" value="${reqId}" />
                        <input type="hidden" name="__RequestVerificationToken" value="${token}" />
                        <input type="number" name="discountedPrice" id="discountedPrice" placeholder="Price After Discount:" title="Enter the new total price after applying discount"/>
                        <button class="btn btn-success">Confirm</button>
                    </form>
                    <!-- Reject reservation form -->
                    <form id="reservationReject" action="${getUrlAction("RejectReservation", "AdminPanel", "Admin")}" method="post">
                        <input type="hidden" name="id" value="${reqId}" />
                        <input type="hidden" name="ownerNotes" id="rejectNotes">
                        <input type="hidden" name="__RequestVerificationToken" value="${token}" />
                        <input type="text" name="reason" id="reason" placeholder="Reason:" title="Enter the reason for rejecting the reservation"/>
                        <button class="btn btn-danger" onclick="getRejectNotes()">Reject</button>
                    </form>
                </div>
                <div class="modal-details-top">
                    <div class="modal-details-left">
                        <div class="modal-details-element">
                            <p>Reservation Number:</p> 
                            <span>${elements[0]}</span>
                        </div>
                        <div class="modal-details-element">
                            <p>Customer Name:</p> 
                            <span>${elements[1]}</span>
                        </div>
                        <div class="modal-details-element">
                            <p>Customer Email:</p>
                            <span>${elements[2]}</span>
                        </div>
                        <div class="modal-details-element">
                            <p>Room Number:</p>
                            <span>${elements[3]}</span>
                        </div>
                        <div class="modal-details-element">
                            <p>Number of Guests:</p>
                            <span>${elements[4]}</span>
                        </div>
                    </div>
                    <div class="modal-details-right">
                        <div class="modal-details-element">
                            <p>Number of Nights:</p> 
                            <span>${elements[5]}</span>
                        </div>
                        <div class="modal-details-element">
                            <p>Total Price:</p>
                            <span>${elements[6]}</span>
                        </div>
                        <div class="modal-details-element">
                            <p>Check In Date:</p>
                            <span>${elements[7]}</span>
                        </div>
                        <div class="modal-details-element">
                            <p>Check Out Date:</p> 
                            <span>${elements[8]}</span>
                        </div>
                        <div class="modal-details-element">
                            <p>Check In Time:</p> 
                            <span>${elements[9]}</span>
                        </div>
                    </div>
                </div>
                <div class="modal-details-bottom">
                    <div class="modal-details-bottom-element">
                        <p>Notes From Guests:</p>
                        <textarea readonly>${elements[10]}</textarea>
                    </div>
                    <div class="modal-details-bottom-element">
                        <p>Notes From Owners:</p>
                        <textarea class="owner-notes" name="ownerNotes" form="reservationConfirm"></textarea>
                    </div>
                    </div>
                </div>
            </div>
        </div>

`
    
    // Append the modal to the document body
    document.body.appendChild(modal);

    const notes = document.querySelector('.owner-notes');
    notes.placeholder = "Enter notes here...\nThese notes can be used for additional confirmation information.\nThey can also be used for more reservation deny details.";


    window.onclick = function (event) {
        if (event.target === modal) {
            modal.style.display = "none";
            pagination.style.display = 'block';
        }
    }
}

function getRejectNotes() {
    const notes = document.querySelector('.owner-notes');
    const hidden = document.getElementById('rejectNotes');
    hidden.value = notes.value;
}
function closeModal() {
    // Remove the modal from the document body
    const modal = document.querySelector('.modal');
    modal.parentNode.removeChild(modal);
    
    const pagination = document.querySelector('span.page-link');
    pagination.style.display = 'block';

}
function boxChecked(parent) {
    const checkbox = parent.querySelector('.excel-checkbox-element');
    checkbox.checked = !checkbox.checked;
    if(checkbox.checked === true) {
        parent.classList.add('checkbox-is-checked')
    }
    else {
        parent.classList.remove('checkbox-is-checked')
    }
    
}
function selectAllCheckboxes() {
    const checkboxes = document.querySelectorAll('.excel-checkbox-element');
    checkboxes.forEach(function (checkbox) {
        const parent = checkbox.parentNode;
        checkbox.checked = true;
        parent.classList.add('checkbox-is-checked')
    });
}
function deselectAllCheckboxes() {
    const checkboxes = document.querySelectorAll('.excel-checkbox-element');
    checkboxes.forEach(function (checkbox) {
        const parent = checkbox.parentNode;
        checkbox.checked = false;
        parent.classList.remove('checkbox-is-checked')
    });
}
