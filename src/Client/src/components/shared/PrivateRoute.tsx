import React, { useContext } from 'react';
import { Redirect, Route } from 'react-router-dom';

import IPrivateRouteProps from './IPrivateRouteProps';
import { AuthenticationContext } from '../contexts/ContextWrapper';
import usersService from '../../services/users.service';

const PrivateRoute = ({
  roles,
  component: Component,
  ...rest
}: IPrivateRouteProps): JSX.Element => {
  const { isAuthenticated, setIsAuthenticated } = useContext(AuthenticationContext);

  return (
    <Route
      {...rest}
      render={props => {
        if (!isAuthenticated) {
          return <Redirect to={{ pathname: '/login', state: { from: props.location } }} />;
        }

        if (roles && !roles.includes(usersService.getRole())) {
          return <Redirect to={{ pathname: '/' }} />;
        }

        //@ts-ignore
        return <Component {...props} />;
      }}
    />
  );
};

export default PrivateRoute;
