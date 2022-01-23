import React from "react"

const useLocalStorage = <T>(key: string, initialValue: any): [getLocalStorage: () => T, setLocalStorage: (newValue: T) => void] => {
    const getLocalStorage = (): T => {
        try {
            let item = localStorage.getItem(key);
            return item ? JSON.parse(item) as T : initialValue;
        }
        catch (err) {
            console.log(err);
            return initialValue;
        }
    }

    const setLocalStorage = (newValue: T) => {
        try {
            localStorage.setItem(key, JSON.stringify(newValue));
        }
        catch (err) {
            console.log(err);
        }
    }

    return [getLocalStorage, setLocalStorage];
}

export default useLocalStorage;