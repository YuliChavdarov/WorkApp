import { createContext } from "react";
import useLocalStorage from "../hooks/useLocalStorage";

const AuthContext = createContext();

export default AuthContext;

const initialState = { jwtToken: null };

export const AuthProvider = ({ children }) => {
    const [authState, setAuthState] = useLocalStorage('authState', initialState);
    
    const login = (jwtToken) => {
        const obj = { ...authState, jwtToken };
        setAuthState(obj);
    }

    const logout = () => {
        setAuthState({});
    }

    return (
        <AuthContext.Provider value={ {authState, login, logout } }>
            {children}
        </AuthContext.Provider>
    );
}