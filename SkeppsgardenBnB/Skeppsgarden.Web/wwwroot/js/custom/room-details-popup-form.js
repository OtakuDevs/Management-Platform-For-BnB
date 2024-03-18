const form = document.getElementById("myFormRoomDetails");

function openForm(button) {
    const roomId = $(button).attr('id');
    document.getElementById("id").value = roomId;
    $.ajax({
        url: "/Rooms/GetRoomDetails",
        type: "GET",
        data: {id: roomId},
        dataType: "json",
        success: function (data) {
            for (let i = 0; i < data.image.length; i++) {
                // Get the image element by id
                let image = document.getElementById(`image0${i + 1}`);
                // Set the source attribute to the corresponding image in the data array
                if (image != null) {
                    image.src = `/images/local/${data.image[i]}.jpg`;

                    let thumbnailImage = document.getElementById(`thumbnail-image-0${i + 1}`);
                    thumbnailImage.src = `/images/local/${data.image[i]}.jpg`;
                }
            }
            if (data.image.length < 6) {
                let emptyElements = data.image.length + 1;
                for (let j = emptyElements; j <= 6; j++) {
                    let thumbnailImage = document.getElementById(`thumbnail-image-0${j}`);
                    thumbnailImage.src = `/images/local/room-placeholder.jpg`;
                }
            }
            if (data.image.length < 10) {
                let emptyElements = data.image.length + 1;
                for (let j = emptyElements; j <= 10; j++) {
                    let image = document.getElementById(`image0${j}`);
                    image.src = `/images/local/room-placeholder.jpg`;
                }
            }

            document.getElementById("floorLevel").value = data.level;
            document.getElementById("view").value = data.view;
            document.getElementById("roomType").value = `${data.roomType} room`;
            document.getElementById("roomAreas").value = data.areas;
            document.getElementById("bedTypes").value = `${data.bedTypes} bed`;
            document.getElementById("roomCapacity").value = `${data.capacity} people`;
            document.getElementById("rate").value = `${data.rate} SEK per night`;
        }
    });
    form.style.display = "block";
    
    // document.querySelector('body').style.overflow = 'hidden';
    
    window.onclick = function (event) {
        if (event.target === form) {
            form.style.display = "none";
        }
    }
}

function closeForm() {
    form.style.display = "none";
}