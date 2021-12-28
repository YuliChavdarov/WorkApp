export const login = (email, password) => {
    return fetch('https://localhost:44319/api/login', {
        method: "POST",
        headers: { "Content-type": "application/json" },
        body: JSON.stringify({email, password})
        })
        .then(res => res.json())
        .catch(error => error);
}

export const register = (userType, firstName, lastName, email, password) => {
    return fetch('https://localhost:44319/api/register', {
        method: "POST",
        headers: { "Content-type": "application/json" },
        body: JSON.stringify({userType, firstName, lastName, email, password})
        })
        .then(res => res.status == 200 ? null : res.json())
        .catch(error => error);
}

    //fetch('https://localhost:44319/api/login/clients', { method: "GET", headers: { "Authorization": `Bearer ${data.token}` } }).then(res => console.log(res));
