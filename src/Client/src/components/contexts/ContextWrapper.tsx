import React, { createContext, useState } from 'react';

import IContextWrapperProps from './IContextWrapperProps';

export const AuthenticationContext = createContext({
  isAuthenticated: false,
  setIsAuthenticated: (isAuthenticated: boolean) => {}
});

const ContextWrapper = ({ children }: IContextWrapperProps): JSX.Element => {
  const [isAuthenticated, setIsAuthenticated] = useState<boolean>(false);

  return (
    <AuthenticationContext.Provider
      value={{
        isAuthenticated,
        setIsAuthenticated
      }}
    >
      {children}
    </AuthenticationContext.Provider>
  );
};

export default ContextWrapper;
