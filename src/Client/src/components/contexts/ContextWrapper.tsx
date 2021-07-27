import React, { createContext, useState } from "react";

import IContextWrapperProps from "./IContextWrapperProps";

export const AuthContext = createContext({
    auth: false,
    updateAuth: (isAuth: boolean) => { }
});

const ContextWrapper = (props: IContextWrapperProps): JSX.Element => {
    const [auth, setAuth] = useState<boolean>(false);

    return (
        <AuthContext.Provider
            value={{
                auth,
                updateAuth: (isAuth: boolean) => {
                    setAuth(isAuth);
                }
            }}
        >
            {props.children}
        </AuthContext.Provider>
    );
};

export default ContextWrapper;