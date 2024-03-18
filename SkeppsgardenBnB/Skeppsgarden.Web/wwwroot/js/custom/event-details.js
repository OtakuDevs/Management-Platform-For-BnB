document.addEventListener('DOMContentLoaded', function() {
    const eventDetails = document.querySelectorAll('.event-row-element');
    console.log(eventDetails);
    eventDetails.forEach(element => {
        const isInPast = element.querySelector('#is-in-past');
        isEventExpired(isInPast.value, element);
    });
});


function openEventModal(element) {
    
    const pElements = Array.from(element.querySelectorAll('p'));
    const inputImage = element.querySelector('#input-image');
    const inputElement = element.querySelector('#input-description');
    
    const img = inputImage.value;
    const title = pElements[0].innerText;
    const location = pElements[1].innerText;
    const start = pElements[2].innerText;
    const end = pElements[3].innerText;
    const description = inputElement.value;

    console.log(img);
    
    document.querySelector('.event-modal-img').src = img.substring(1);
    document.getElementById('event-title').innerText = title;
    document.getElementById('event-location').innerText = location;
    document.getElementById('event-start').innerText = start;
    document.getElementById('event-end').innerText = end;
    document.getElementById('event-description').innerText = description;

    document.getElementById('event-modal').style.display = 'block';
    
    window.onclick = function(event) {
        if (event.target === document.getElementById('event-modal')) {
            document.getElementById('event-modal').style.display = 'none';
        }
    }
}

function closeEventModal() {
    document.getElementById('event-modal').style.display = 'none';
}


function isEventExpired(state, element) {
    console.log(state)
    if (state === 'True') {
        element.querySelector('.event-image img').style.filter = 'grayscale(100%)';
    }
}