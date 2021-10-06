import React, { createContext, useState } from 'react';

import IContextWrapperProps from './IContextWrapperProps';
import usersService from '../../services/usersService';
import gamblerService from '../../services/gamblerService';

export const AuthenticationContext = createContext({
  isAuthenticated: usersService.isAuthenticated(),
  setIsAuthenticated: (isAuthenticated: boolean) => {},
  gamblerId: 0,
  setGamblerId: (gamblerId: number) => {}
});

const ContextWrapper = ({ children }: IContextWrapperProps): JSX.Element => {
  const [isAuthenticated, setIsAuthenticated] = useState<boolean>(usersService.isAuthenticated());
  const [gamblerId, setGamblerId] = useState<number>(
    gamblerService.getIdFromLocalStorage() ? Number(gamblerService.getIdFromLocalStorage()) : 0
  );

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
