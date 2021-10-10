import React, { useState, useContext } from 'react';
import { useEffect } from 'react';
import { Link, useHistory } from 'react-router-dom';

import { map, mergeMap } from 'rxjs';

import { AuthenticationContext } from '../../components/contexts/ContextWrapper';
import ICredentials from '../../models/credentials';
import errorsService from '../../services/errorsService';
import gamblerService from '../../services/gamblerService';
import jwtService from '../../services/jwtService';
import usersService from '../../services/usersService';

const Login = (): JSX.Element => {
  const history = useHistory();
  const { isAuthenticated, setIsAuthenticated, setGamblerId } = useContext(AuthenticationContext);

  const [credentials, setCredentials] = useState<ICredentials>({
    email: '',
    password: ''
  });

  useEffect(() => {
    if (isAuthenticated) {
      history.push('/');
    }
  }, []);

  const handleChange = (event: React.ChangeEvent<HTMLInputElement>) => {
    setCredentials({
      ...credentials,
      [event.target.name]: event.target.value
    });
  };

  const login = (event: React.FormEvent<HTMLFormElement>) => {
    event.preventDefault();

    usersService
      .login(credentials)
      .pipe(
        map(res => {
          jwtService.saveToken(res.data.token);
          setIsAuthenticated(true);
        }),
        mergeMap(_ =>
          gamblerService.getId().pipe(
            map(res => {
              setGamblerId(res.data.id);
              gamblerService.setIdInLocalStorage(res.data.id);
            })
          )
        )
      )
      .subscribe({
        next: _ => history.push('/'),
        error: errorsService.handle
      });
  };

  return (
    <div className="col-xl-8 col-lg-8 col-md-6 col-sm-6 mt-40">
      <div className="content-center cl-white">
        <div className="row justify-content-center">
          <div className="col-4">
            <div className="account-form">
              <div className="title">
                <h3>Login to your account</h3>
              </div>
              <div className="via-login">
                <a href="" className="facebook-bg">
                  <i className="fa fa-facebook"></i>Login with Facebook
                </a>
                <a href="" className="google-plus-bg">
                  <i className="fa fa-google"></i>Login with Google
                </a>
              </div>
              <form action="POST" onSubmit={login}>
                <div className="row">
                  <div className="col-xl-12">
                    <p>Or with your email and password</p>
                  </div>
                  <div className="col-xl-12">
                    <input
                      type="email"
                      name="email"
                      value={credentials.email}
                      onChange={handleChange}
                      placeholder="Email"
                    />
                  </div>
                  <div className="col-xl-12">
                    <input
                      type="password"
                      name="password"
                      value={credentials.password}
                      onChange={handleChange}
                      placeholder="Password"
                    />
                  </div>

                  <div className="col-xl-12">
                    <button type="submit" className="bttn-small btn-fill w-100">
                      Login Account
                    </button>
                  </div>
                  <div className="col-xl-12">
                    <p>Don't you have an account?</p>
                  </div>
                  <div className="col-xl-12 centered">
                    <Link to="/register" className="bttn-small btn-wht w-100">
                      Create a new account
                    </Link>
                  </div>
                </div>
              </form>
            </div>
          </div>
        </div>
      </div>
    </div>
  );
};

export default Login;
