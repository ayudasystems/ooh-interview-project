function loadCampaigns () {
    let request = new XMLHttpRequest();
    request.open('GET', 'https://localhost:6001/api/v1/campaigns', true);

    request.onload = function() {
        if (request.status >= 200 && request.status < 400) {
            let data = JSON.parse(this.response);
            data.items.forEach(campaign => {
                const campaignElement = document.createElement('div');
                campaignElement.textContent = campaign.name;

                const campaignsContainer = document.getElementById('campaigns-container');
                campaignsContainer.appendChild(campaignElement);
            })
        }
    };

    request.send();
}

window.addEventListener('load', loadCampaigns, false);