import React from "react"

const useLocalStorage = (key, initialValue) => {
    const [state, setState] = React.useState(() => {
        try {
            let item = localStorage.getItem(key);
            return item ? JSON.parse(item) : initialValue;
        }
        catch (err) {
            console.log(err);
            return initialValue;
        }
    });

    const setLocalStorage = (newValue) => {
        try {
            localStorage.setItem(key, JSON.stringify(newValue));
            setState(newValue);
        }
        catch (err) {
            console.log(err);
        }
    }

    return [state, setLocalStorage];
}

export default useLocalStorage;