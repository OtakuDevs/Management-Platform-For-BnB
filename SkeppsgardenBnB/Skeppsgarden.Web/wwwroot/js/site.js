// Please see documentation at https://docs.microsoft.com/aspnet/core/client-side/bundling-and-minification
// for details on configuring this project to bundle and minify static web assets.

// Write your JavaScript code.
const notificationContainer = document.querySelector('#notification-container');

const requestsCount = document.querySelector('#requestsCount');
const notificationIcon = document.querySelector('#notification-icon');

document.body.addEventListener('click', function (event) {
    // Check if the click event target is not within the notification container
    if (!notificationContainer.contains(event.target) && event.target !== notificationIcon) {
        // Close the notification container
        notificationContainer.style.display = 'none';
    }
});


if (Number(requestsCount.textContent) > 0) {
    notificationIcon.classList.add('animate-notification-icon')
} else {
    notificationIcon.classList.remove('animate-notification-icon')
}

function openNotification() {
    notificationContainer.style.display = "block";
}

function closeNotification() {
    notificationContainer.style.display = "none";
}

// Cat random position and random image
const cat = document.querySelector('.cat');
const catShadow = document.querySelector('.cat-shadow');

const randomMarginLeft = Math.floor(Math.random() * (document.body.clientWidth - cat.offsetWidth - 50));

cat.style.marginLeft = randomMarginLeft + 'px';
catShadow.style.marginLeft = randomMarginLeft + 'px';

const randomCatIndex = Math.floor(Math.random() * 14) + 1;
const catImage = `/images/squirrels/${randomCatIndex}.png`;
cat.src = catImage;


// Function to handle mobile view
function handleMobileView() {
    handleContactDropdown();
    handleBookingRoomsTable();
}

function handleContactDropdown() {
    let contactDropdown = document.querySelector('.navbar-dropdown-content');
    if (!contactDropdown) {
        contactDropdown = document.querySelector('.mobile-dropdown');
    }
    const contactDropdownButton = document.querySelector('.navbar-dropdown-button');

    if (window.innerWidth < 768) { // Use innerWidth for consistent behavior
        contactDropdownButton.style.display = 'none';
        if (contactDropdown.classList.contains('navbar-dropdown-content')) {
            contactDropdown.classList.remove('navbar-dropdown-content');
        }
        if (!contactDropdown.classList.contains('mobile-dropdown')) {
            contactDropdown.classList.add('mobile-dropdown');
        }
    } else if (window.innerWidth >= 768) {
        contactDropdownButton.style.display = 'block';
        if (contactDropdown.classList.contains('mobile-dropdown')) {
            contactDropdown.classList.remove('mobile-dropdown');
        }
        if (!contactDropdown.classList.contains('navbar-dropdown-content')) {
            contactDropdown.classList.add('navbar-dropdown-content');
        }
    }
}

function handleBookingRoomsTable() {
    const tableRows = document.querySelectorAll('.room-listing-row-element');
    if (window.innerWidth < 768) {
        tableRows.forEach((row, index) => {
            const tds = row.querySelectorAll('td');
            tds[1].textContent = `Room ` + tds[1].textContent;
            tds[4].textContent = `Capacity - ` + tds[4].textContent;
            const price = tds[6];
            const priceContent = price.textContent.trim();
            const discount = price.querySelector('span');
            
            if (discount) {
                const priceText = priceContent.substring(discount.textContent.length, priceContent.length);
                tds[6].innerHTML = `Price ~ <span id="price-discount">` + discount.textContent + `</span>` + priceText + `[SEK]`;
            } else {
                tds[6].textContent = `Price ~ ` + tds[6].textContent + ' [SEK]';
            }
        });
    }
}

// Initial check
handleMobileView();

// Listen for resize events
window.addEventListener('resize', function () {
    handleMobileView(); // Recheck when window is resized
});

