import { getHeaders } from "./Common";

export const createProfile = (token, data) => {
    return fetch('https://localhost:44319/api/profile/create',
        {
            method: "POST",
            headers: getHeaders(token),
            body: JSON.stringify(data)
        })
        .then(res => res.json())
        .catch(error => error);
}