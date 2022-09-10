const host = "https://localhost:7253";

function login(data) {
    $.ajax({
        url: host + '/api/Auth/Login',
        method: 'POST',
        async: false,
        data: data,
    }).done((response) => {
        window.location.href = "/Profile";
    }).fail((error) => {
        console.log(error);
    });
}

function registration(data) {
    $.ajax({
        url: host + '/api/Auth/Registration',
        method: 'POST',
        data: data,
        async: false
    }).done((response) => {
        window.location.href = "/Authiticate";
    }).fail((error) => {
        console.log(error);
    });
}

function logout() {
    $.ajax({
        url: host + '/api/Auth/Logout',
        method: 'POST',
        async: false
    }).done((response) => {
        window.location.href = "/Authiticate";
    }).fail((error) => {
        console.error(error);
    });
}