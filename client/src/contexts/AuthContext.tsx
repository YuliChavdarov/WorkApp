import { createContext } from "react";
import Storage from "../helpers/LocalStorageWrapper";

enum AuthLocals {
    JWT_TOKEN = 'jwt_token',
}

class Tokens extends Storage<AuthLocals> {

    private static instance?: Tokens;

    public static getInstance() {
        if (!this.instance) {
            this.instance = new Tokens();
        }

        return this.instance;
    }

    constructor() {
        super();
    }

    public getJwtToken() {
        return this.get(AuthLocals.JWT_TOKEN);
    }

    public setJwtToken(accessToken: string) {
        this.set(AuthLocals.JWT_TOKEN, accessToken);
    }

    public clear() {
        this.clearItems([AuthLocals.JWT_TOKEN]);
    }
}

interface IAuthContext {
    getJwtToken: () => string | null;
    login: (jwtToken: string) => void;
    logout: () => void;
}

const tokens = Tokens.getInstance();

const authState: IAuthContext = {
    getJwtToken: () => tokens.getJwtToken(),
    login: (str) => tokens.setJwtToken(str),
    logout: () => tokens.clear()
};

const AuthContext = createContext(authState);

export default AuthContext;

interface IProps {
    children: React.ReactNode
}

export const AuthProvider: React.FC<IProps> = ({ children }) => {
    return (
        <AuthContext.Provider value={ authState }>
            {children}
        </AuthContext.Provider>
    );
}