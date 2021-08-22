import React, { useState, useContext } from 'react';
import { useEffect } from 'react';
import { Link, useHistory } from 'react-router-dom';

import { toast } from 'react-toastify';

import { AuthenticationContext } from '../contexts/ContextWrapper';
import ICredentials from '../models/credentials.model';
import jwtService from '../../services/jwt.service';
import usersService from '../../services/users.service';

const Login = (): JSX.Element => {
  const history = useHistory();
  const { isAuthenticated, setIsAuthenticated } = useContext(AuthenticationContext);

  const [credentials, setCredentials] = useState<ICredentials>({
    email: '',
    password: ''
  });

  useEffect(() => {
    if (isAuthenticated) {
      history.push('/');
    }
  }, [isAuthenticated]);

  const handleChange = (event: React.ChangeEvent<HTMLInputElement>) => {
    setCredentials({
      ...credentials,
      [event.target.name]: event.target.value
    });
  };

  const login = (event: React.FormEvent<HTMLFormElement>) => {
    event.preventDefault();

    usersService.login(credentials).subscribe({
      next: res => {
        jwtService.saveToken(res.data.token);
        setIsAuthenticated(true);
        history.push('/');
      },
      error: err => {
        const errors: string[] = err.response.data;
        errors.map(e => toast.error(e));
      }
    });
  };

  return (
    <section>
      <div className="container-fluid">
        <div className="row">
          <div className="col-xl-2 col-lg-2 col-md-3 col-sm-6"></div>
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
          <div className="col-xl-2 col-lg-2 col-md-3 col-sm-6"></div>
        </div>
      </div>
    </section>
  );
};

export default Login;
