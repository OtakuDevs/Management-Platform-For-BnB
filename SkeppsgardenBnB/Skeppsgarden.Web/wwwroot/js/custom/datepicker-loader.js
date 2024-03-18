// Get the width of the input element
const checkInDateWidth = document.querySelector('#check-in-date').offsetWidth;

// Get the current date
const today = new Date();
const tomorrow = new Date(today.getTime() + 24 * 60 * 60 * 1000);

// Set the initial value of the input element
const checkInDate = document.querySelector('#check-in-date');
const checkOutDate = document.querySelector('#check-out-date');
checkInDate.value = today.toLocaleDateString();
checkOutDate.value = tomorrow.toLocaleDateString();

// Initialize the datepicker on the input element
const picker = datepicker('#check-in-date',
    {

        id:1,
        //this makes the datepicker container to be appended to the input container so that it can be positioned relative to the input element
        container: document.querySelector('.datepicker-input-container'),
        position : 'bl',
        startDay: 1,
        minDate: new Date(today),
        onSelect: (instance, date ) => {
            instance.el.value = date.toLocaleDateString();
            checkOutDate.value = new Date(date.getTime() + 24 * 60 * 60 * 1000).toLocaleDateString();
        }
    });
const picker2 = datepicker('#check-out-date',
    {
        id:1,
        container: document.querySelector('.datepicker-input-container'),
        position : 'bl',
        startDay: 1,
        onSelect: (instance, date ) => {
            instance.el.value = date.toLocaleDateString();
        }
    });


// Set the width and height of the calendar container to match the width of the input
picker.calendarContainer.style.setProperty('width', checkInDateWidth * 1.5 + 'px');
picker.calendarContainer.style.setProperty('height', 'auto');
picker2.calendarContainer.style.setProperty('width', checkInDateWidth * 1.5 + 'px');
picker2.calendarContainer.style.setProperty('height', 'auto');
    