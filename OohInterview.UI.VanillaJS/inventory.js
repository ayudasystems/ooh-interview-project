function loadInitialUI(){
    loadFaces();
    setBookingDates();
}

function loadFaces () {
    let request = new XMLHttpRequest();
    request.open('GET', 'https://localhost:6001/api/v1/faces', true);

    request.onload = function() {
        if (request.status >= 200 && request.status < 400) {
            let data = JSON.parse(this.response);
            
            if(data.items.length > 0){
                data.items.forEach(face => {
                    addFaceToUI(face);
                });
            }
        }
    };

    request.send();
}

function addFaceToUI(face){
    let faceElement = createFaceElement(face);

    addFaceElementToUI(faceElement);
}

function createFaceElement(face){
    const faceElement = document.createElement('div');
    faceElement.textContent = face.name;

    return faceElement;
}

function addFaceElementToUI(faceElement){
    const facesContainer = document.getElementById('faces-container');
    facesContainer.appendChild(faceElement);
}

function setBookingDates(){
    let today = new Date();
    let todayString = getDateString(
        today.getDate(),
        today.getMonth() + 1,
        today.getFullYear()
    );
    
    document.getElementById('start-date').value = todayString;
    document.getElementById('end-date').value = todayString;
}

function getDateString(day, month, year){
    if (month < 10) month = "0" + month;
    if (day < 10) day = "0" + day;

    return year + "-" + month + "-" + day;
}

window.addEventListener('load', loadInitialUI, false);