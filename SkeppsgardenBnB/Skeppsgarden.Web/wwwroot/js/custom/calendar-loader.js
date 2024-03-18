function getEventColor(roomName) {
    switch (roomName) {
        case 'Room num: 1':
            return 'darkseagreen';
        case 'Room num: 2':
            return 'bisque';
        case 'Room num: 3':
            return 'khaki';
        case 'Room num: 4':
            return 'indianred';
        case 'Room num: 5':
            return 'lightblue';
        case 'Room num: 6':
            return 'darkgreen';
        case 'Room num: 7':
            return 'darkred';
        case 'Room num: 8':
            return 'gold';
        case 'Room num: 9':
            return 'orange';
        case 'Room num: 10':
            return 'purple';
        default:
            return 'gray'; // Default color
    }
}

function setInitialView() {
    if (window.innerWidth < 768) {
        return 'timeGridDay';
    }
    return 'dayGridMonth';
}

document.addEventListener('DOMContentLoaded', function () {
    const calendarEl = document.getElementById('calendar');
    const calendar = new FullCalendar.Calendar(calendarEl, {
        initialView: setInitialView(),
        headerToolbar: {
            left: 'prev,next today addEventButton',
            center: 'title',
            right: 'dayGridMonth,timeGridWeek,timeGridDay'
        },
        buttonText: {
            today: 'today',
            month: 'month',
            week: 'week',
            day: 'day',
        },
        customButtons: {
            addEventButton: {
                text: 'Add Event',
                click: function () {
                    // Display a modal for adding events
                    $('#addEventModal').modal('show');
                }
            }
        },
        editable: false,
        dayMaxEvents: true, // allow "more" link when too many events
        /* Add a 12-hour threshold for displaying the next day */
        /* If we have a reservation 27th - 29th, it will be displayed as 27th - 28th */
        /* Cause the 29th is the check-out day */
        nextDayThreshold: '12:00:00',
        events: function (fetchInfo, successCallback, failureCallback) {
            $.ajax({
                url: '/Admin/CalendarAdmin/Calendar/',
                type: "GET",
                dataType: "JSON",
                success: function (result) {
                    
                    var events = [];
                    
                    $.each(result, function (i, data) {
                        
                        events.push({
                            id: data.id,
                            title: data.roomName,
                            start: data.startDate,
                            end: data.endDate,
                            color: getEventColor(data.roomName),
                            textColor: 'black',
                            extendedProps: {
                                customerName: data.customerName,
                                customerEmail: data.customerEmail,
                                customerPhone: data.customerPhoneNumber
                            }
                        });
                    }
                    );
                    successCallback(events);
                }
            });
        },
        eventContent: function (arg) {
            const eventEl = document.createElement('div');
            eventEl.innerText = arg.event.title;

            // Add custom styles for start and end of the event
            if (arg.isStart) {
                eventEl.classList.add('event-start');
            }
            if (arg.isEnd) {
                eventEl.classList.add('event-end');
            }

            return { domNodes: [eventEl] };
        },
        eventColor: 'green',
        eventDisplay: 'block',
        eventTextColor: 'black',
        eventClick: function (info) {
            // Display additional information in a Bootstrap modal
            
            const modal = document.getElementById('eventModal');
            
            
            modal.innerHTML = `
            <div class="modal-content">
            <div class="modal-header">
                <h5 class="modal-title" id="eventModalLabel">Reservation Details</h5>
                <button type="button" class="close btn btn-secondary" aria-label="Close" onclick="closeEventModal()">
                    <span aria-hidden="true">&times;</span>
                </button>
            </div>
            <div class="modal-body">
                <h6 id="reservationId"></h6>
                <h6 id="customerName"></h6>
                <p id="customerEmail"></p>
                <p id="customerPhone"></p>
            </div>
            <div class="modal-footer">
                <button type="button" class="btn btn-secondary" onclick="closeEventModal()">Close</button>
            </div>
        </div>`;
            
            // Show modal
            $('#reservationId').text('Reservation ID: ' + info.event.id);
            $('#eventModalTitle').text(info.event.title);
            $('#customerName').text('Customer Name: ' + info.event.extendedProps.customerName);
            $('#customerEmail').text('Customer Email: ' + info.event.extendedProps.customerEmail);
            $('#customerPhone').text('Customer Phone: ' + info.event.extendedProps.customerPhone);
            
            modal.style.display = 'block';
        }
    
});
    calendar.render();
});

function closeEventModal() {
    const modal = document.getElementById('eventModal');
    modal.style.display = 'none';
}


const modal = document.getElementById('eventModal');
window.onclick = function (event) {
    if (event.target === modal) {
        modal.style.display = 'none';
    }
}





