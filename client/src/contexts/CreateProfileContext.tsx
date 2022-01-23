import { createContext, useState } from "react";

const CreateProfileContext = createContext<any>({});

export default CreateProfileContext;

const initialState = { hourlyRate: 0 };

export const CreateProfileProvider: React.FC<{children: React.ReactNode}> = ({ children }) => {
    const [infoState, setState] = useState(initialState);

    const addToState = (propName: any, propValue: any) => {
        const newState = {...infoState, [`${propName}`]: propValue };
        setState(newState);
    }

    return (
        <CreateProfileContext.Provider value={ {infoState, addToState} }>
            {children}
        </CreateProfileContext.Provider>
    );
}