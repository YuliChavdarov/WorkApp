import { createContext, useState } from "react";

const CreateProfileContext = createContext();

export default CreateProfileContext;

const initialState = { hourlyRate: 0 };

export const CreateProfileProvider = ({ children }) => {
    const [infoState, setState] = useState(initialState);

    const addToState = (propName, propValue) => {
        const newState = {...infoState, [`${propName}`]: propValue };
        setState(newState);
    }

    return (
        <CreateProfileContext.Provider value={ {infoState, addToState} }>
            {children}
        </CreateProfileContext.Provider>
    );
}