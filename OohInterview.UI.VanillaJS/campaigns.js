function loadCampaigns () {
    let request = new XMLHttpRequest();
    request.open('GET', 'https://localhost:6001/api/v1/campaigns', true);

    request.onload = function() {
        if (request.status >= 200 && request.status < 400) {
            let data = JSON.parse(this.response);

            if (data.items.length > 0) {
                createCampaignGrid();
                data.items.forEach(campaign => {
                    addCampaignToGrid(campaign);
                });
            } else {
                showNoCampaignsMessage();
            }
        }
    };

    request.send();
}

function createCampaignGrid() {
    const gridElement = document.createElement('table');
    gridElement.id = "campaigns-grid";

    let headerElement = createHeader();
    gridElement.appendChild(headerElement);

    let bodyElement = createBody();
    gridElement.appendChild(bodyElement);

    addElementToCampaignContainer(gridElement);
}

function createHeader() {
    const headElement = document.createElement('thead');

    let headerRow = createHeaderRow();
    headElement.appendChild(headerRow);

    return headElement;
}

function createHeaderRow() {
    const headRowElement = document.createElement('tr');

    let campaignNameHeader = createHeaderCell("Campaign Name");
    headRowElement.appendChild(campaignNameHeader);

    let startDateHeader = createHeaderCell("Start Date");
    headRowElement.appendChild(startDateHeader);

    let endDateHeader = createHeaderCell("End Date");
    headRowElement.appendChild(endDateHeader);

    return headRowElement;
}

function createHeaderCell(text) {
    const headerCellElement = document.createElement('th');
    headerCellElement.textContent = text;

    return headerCellElement;
}

function createBody() {
    const bodyElement = document.createElement('tbody');
    bodyElement.id = "campaigns-grid-body";

    return bodyElement;
}

function showNoCampaignsMessage() {
    let noCampaignsMessageElement = createNoCampaignsMessage();
    addElementToCampaignContainer(noCampaignsMessageElement);
}

function createNoCampaignsMessage() {
    const noCampaignsMessageElement = document.createElement('div');
    noCampaignsMessageElement.className = "no-campaigns-message";
    noCampaignsMessageElement.textContent = "No campaigns found";

    return noCampaignsMessageElement;
}

function addCampaignToGrid(campaign) {
    let campaignRowElement = createCampaignRow(campaign);

    const campaignsGridBody = document.getElementById('campaigns-grid-body');
    campaignsGridBody.appendChild(campaignRowElement);
}

function createCampaignRow(campaign) {
    const campaignRowElement = document.createElement('tr');

    let campaignNameCell = createCampaignCell(campaign.name);
    campaignRowElement.appendChild(campaignNameCell);

    let startDateCell = createCampaignCell(campaign.startDate);
    campaignRowElement.appendChild(startDateCell);

    let endDateCell = createCampaignCell(campaign.endDate);
    campaignRowElement.appendChild(endDateCell);

    return campaignRowElement;
}

function createCampaignCell(text) {
    const campaignCellElement = document.createElement('td');
    campaignCellElement.textContent = text;

    return campaignCellElement;
}

function addElementToCampaignContainer(element) {
    const campaignsContainer = document.getElementById('campaigns-container');
    campaignsContainer.appendChild(element);
}
window.addEventListener('load', loadCampaigns, false);