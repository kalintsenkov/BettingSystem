import React, { createContext, useState } from 'react';

import IContextWrapperProps from './IContextWrapperProps';

export const AuthenticationContext = createContext({
  isAuthenticated: false,
  setIsAuthenticated: (isAuthenticated: boolean) => {},
  gamblerId: 0,
  setGamblerId: (gamblerId: number) => {}
});

const ContextWrapper = ({ children }: IContextWrapperProps): JSX.Element => {
  const [isAuthenticated, setIsAuthenticated] = useState<boolean>(false);
  const [gamblerId, setGamblerId] = useState<number>(0);

  return (
    <AuthenticationContext.Provider
      value={{
        isAuthenticated,
        setIsAuthenticated,
        gamblerId,
        setGamblerId
      }}
    >
      {children}
    </AuthenticationContext.Provider>
  );
};

export default ContextWrapper;
