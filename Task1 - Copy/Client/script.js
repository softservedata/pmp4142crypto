document.querySelectorAll('form')
    .forEach(f => f.addEventListener('submit', (e) => e.preventDefault()));

function ajaxRequest(endpoint) {
    const req = new XMLHttpRequest();
    const a = document.getElementById('a').value;
    const b = document.getElementById('b').value;
    // debugger;
    req.onreadystatechange = function() {
        if (this.readyState === 4 && this.status === 200) {
            document.getElementById('text').innerText = this.responseText;
        }
    };

    endpoint = `${endpoint}/${a}/${b}`;
    req.open('GET', `https://localhost:44320/api/${endpoint}`, true);
    req.send();
}
