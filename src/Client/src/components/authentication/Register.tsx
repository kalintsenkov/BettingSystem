import React from "react";
import { Link } from "react-router-dom";

const Register = (): JSX.Element => {
  return (
    <section>
      <div className="container-fluid">
        <div className="row">
          <div className="col-xl-2 col-lg-2 col-md-3 col-sm-6"></div>
          <div className="col-xl-8 col-lg-8 col-md-6 col-sm-6 mt-40">
            <div className="content-center cl-white">
              <div className="row justify-content-center">
                <div className="col-6">
                  <div className="account-form">
                    <div className="title">
                      <h3>Create your account</h3>
                    </div>
                    <div className="via-login">
                      <a href="" className="facebook-bg"><i className="fa fa-facebook"></i>Signup with Facebook</a>
                      <a href="" className="google-plus-bg"><i className="fa fa-google"></i>Signup with Google</a>
                    </div>
                    <form action="#">
                      <div className="row">
                        <div className="col-xl-6">
                          <input type="text" placeholder="First Name" />
                        </div>
                        <div className="col-xl-6">
                          <input type="text" placeholder="Last Name" />
                        </div>
                        <div className="col-xl-12">
                          <input type="email" placeholder="Email" />
                        </div>
                        <div className="col-xl-12">
                          <input type="password" placeholder="Password" />
                        </div>
                        <div className="col-xl-12">
                          <p>By signing up to betsb you confirm that you agree with the <a href="">member terms and conditions</a></p>
                        </div>
                        <div className="col-xl-12">
                          <button type="submit" className="bttn-small btn-fill w-100">Create my account</button>
                        </div>
                        <div className="col-xl-12">
                          <p><Link to="/login">Do you already have an account?</Link></p>
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

export default Register;
