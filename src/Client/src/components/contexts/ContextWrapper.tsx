import React, { createContext, useState } from 'react';

import IContextWrapperProps from './IContextWrapperProps';

export const AuthContext = createContext({
  isAuthenticated: false,
  authenticate: (isAuth: boolean) => {}
});

const ContextWrapper = ({ children }: IContextWrapperProps): JSX.Element => {
  const [isAuthenticated, setAuth] = useState<boolean>(false);

  return (
    <AuthContext.Provider
      value={{
        isAuthenticated,
        authenticate: (isAuthenticated: boolean) => {
          setAuth(isAuthenticated);
        }
      }}
    >
      {children}
    </AuthContext.Provider>
  );
};

export default ContextWrapper;
