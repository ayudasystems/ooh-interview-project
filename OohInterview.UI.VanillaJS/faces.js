function loadFaces () {
    let request = new XMLHttpRequest();
    request.open('GET', 'https://localhost:6001/api/v1/faces', true);

    request.onload = function() {
        if (request.status >= 200 && request.status < 400) {
            let data = JSON.parse(this.response);
            data.items.forEach(face => {
                const faceElement = document.createElement('div');
                faceElement.textContent = face.name;
                
                const facesContainer = document.getElementById('faces-container');
                facesContainer.appendChild(faceElement);
            })
        }
    };
    
    request.send();
}

window.addEventListener('load', loadFaces, false);