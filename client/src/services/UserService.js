import { getHeaders } from "./Common";

export const login = (email, password) => {
    return fetch('https://localhost:44319/api/login', {
        method: "POST",
        headers: getHeaders(),
        body: JSON.stringify({ email, password })
    })
        .then(res => res.json())
        .catch(error => error);
}

export const register = (userType, firstName, lastName, email, password) => {
    return fetch('https://localhost:44319/api/register', {
        method: "POST",
        headers: getHeaders(),
        body: JSON.stringify({ userType, firstName, lastName, email, password })
    })
        .then(res => res.json())
        .catch(error => error);
}