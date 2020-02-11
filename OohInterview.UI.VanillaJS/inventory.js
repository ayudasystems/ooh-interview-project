function loadInitialUI() {
    loadFaces();
    setBookingDates();
}

function loadFaces () {
    let request = new XMLHttpRequest();
    request.open('GET', 'https://localhost:6001/api/v1/faces', true);

    request.onload = function() {
        if (request.status >= 200 && request.status < 400) {
            let data = JSON.parse(this.response);
            
            if (data.items.length > 0) {
                createFaceGrid();
                data.items.forEach(face => {
                    addFaceToGrid(face);
                });
            } else {
                showNoFacesMessage();
            }
        }
    };

    request.send();
}

function createFaceGrid() {
    const gridElement = document.createElement('table');
    gridElement.id = "faces-grid";
    
    let headerElement = createHeader();
    gridElement.appendChild(headerElement);
    
    let bodyElement = createBody();
    gridElement.appendChild(bodyElement);
    
    addElementToFaceContainer(gridElement);
}

function createHeader() {
    const headElement = document.createElement('thead');

    let headerRow = createHeaderRow();
    headElement.appendChild(headerRow);
    
    return headElement;
}

function createHeaderRow() {
    const headRowElement = document.createElement('tr');

    let faceNameHeader = createHeaderCell("Face Name");
    headRowElement.appendChild(faceNameHeader);

    let availabilityHeader = createHeaderCell("Availability");
    headRowElement.appendChild(availabilityHeader);
    
    return headRowElement;
}

function createHeaderCell(text) {
    const headerCellElement = document.createElement('th');
    headerCellElement.textContent = text;
    
    return headerCellElement;
}

function createBody() {
    const bodyElement = document.createElement('tbody');
    bodyElement.id = "faces-grid-body";
    
    return bodyElement;
}

function showNoFacesMessage() {
    let noFacesMessageElement = createNoFacesMessage();
    addElementToFaceContainer(noFacesMessageElement);
}

function createNoFacesMessage() {
    const noFacesMessageElement = document.createElement('div');
    noFacesMessageElement.className = "no-faces-message";
    noFacesMessageElement.textContent = "No faces found";

    return noFacesMessageElement;
}

function addFaceToGrid(face) {
    let faceRowElement = createFaceRow(face);
    
    const facesGridBody = document.getElementById('faces-grid-body');
    facesGridBody.appendChild(faceRowElement);
}

function createFaceRow(face) {
    const faceRowElement = document.createElement('tr');

    let faceNameCell = createFaceCell(face.name);
    faceRowElement.appendChild(faceNameCell);

    let availabilityCell = createFaceCell("Not implemented yet");
    faceRowElement.appendChild(availabilityCell);
    
    return faceRowElement;
}

function createFaceCell(text) {
    const faceCellElement = document.createElement('td');
    faceCellElement.textContent = text;

    return faceCellElement;
}

function addElementToFaceContainer(element) {
    const facesContainer = document.getElementById('faces-container');
    facesContainer.appendChild(element);
}

function setBookingDates() {
    let today = new Date();
    let todayString = getDateString(
        today.getDate(),
        today.getMonth() + 1,
        today.getFullYear()
    );
    
    document.getElementById('start-date').value = todayString;
    document.getElementById('end-date').value = todayString;
}

function getDateString(day, month, year) {
    if (month < 10) month = "0" + month;
    if (day < 10) day = "0" + day;

    return year + "-" + month + "-" + day;
}

window.addEventListener('load', loadInitialUI, false);