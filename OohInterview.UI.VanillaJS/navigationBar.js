function loadNavigationBar () {
    document.getElementById('nav').innerHTML =
        '<ul>\
            <li>\
                <a class="navigation-link" href="./index.html">Home</a>\
            </li>\
            <li>\
                <a class="navigation-link" href="./inventory.html">Inventory</a>\
            </li>\
            <li>\
                <a class="navigation-link" href="./campaigns.html">Campaigns</a>\
            </li>\
        </ul>';
}

window.addEventListener('load', loadNavigationBar, false);