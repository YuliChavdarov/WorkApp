import { getHeaders } from "./Common";

export const login = (email: string, password: string) => {
    return fetch('https://localhost:44319/api/login', {
        method: "POST",
        headers: getHeaders(),
        body: JSON.stringify({ email, password })
    })
        .then(res => res.json())
        .catch(error => console.log(error));
}

export const register = (userType: "Worker" | "Client", firstName: string, lastName: string, email: string, password: string) => {
    return fetch('https://localhost:44319/api/register', {
        method: "POST",
        headers: getHeaders(),
        body: JSON.stringify({ userType, firstName, lastName, email, password })
    })
        .then(res => res.json())
        .catch(error => console.log(error));
}