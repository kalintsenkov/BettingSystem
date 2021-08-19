import React from 'react';
import { Link } from 'react-router-dom';

const Login = (): JSX.Element => {
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
                    <form action="#">
                      <div className="row">
                        <div className="col-xl-12">
                          <p>Or with your username and password</p>
                        </div>
                        <div className="col-xl-12">
                          <input type="text" placeholder="Username" />
                        </div>
                        <div className="col-xl-12">
                          <input type="password" placeholder="Password" />
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
