import React from "react";

import logo from "../../assets/images/logo.png";

const Header = (): JSX.Element => {

    return (
        <>
            <header className="header-area gradient-bg">
                <nav className="navbar navbar-expand-lg main-menu">
                    <div className="container-fluid">

                        <a className="navbar-brand" href="index.html">
                            <img src={logo} className="d-inline-block align-top" alt="Logo" />
                        </a>

                        <button className="navbar-toggler" type="button" data-toggle="collapse" data-target="#navbarSupportedContent" aria-controls="navbarSupportedContent" aria-expanded="false" aria-label="Toggle navigation">
                            <span className="menu-toggle"></span>
                        </button>

                        <div className="collapse navbar-collapse" id="navbarSupportedContent">
                            <ul className="navbar-nav m-auto">
                                <li className="nav-item"><a className="nav-link" href="index.html">Home</a></li>
                                <li className="nav-item"><a className="nav-link" href="about.html">About us</a></li>
                                <li className="nav-item"><a className="nav-link" href="inplay.html">Inplay</a></li>
                                <li className="nav-item"><a className="nav-link" href="winlist.html">Winlist</a></li>
                                <li className="nav-item dropdown">
                                    <a className="nav-link dropdown-toggle" href="#" role="button" data-toggle="dropdown" aria-haspopup="true" aria-expanded="false">Pages</a>
                                    <ul className="dropdown-menu">
                                        <li><a className="dropdown-item" href="upcomming.html">Upcomming Match</a></li>
                                        <li><a className="dropdown-item" href="winlist.html">Winlist</a></li>
                                        <li><a className="dropdown-item" href="promotion.html">Promotion</a></li>
                                        <li><a className="dropdown-item" href="login.html">Login</a></li>
                                        <li><a className="dropdown-item" href="register.html">Registration</a></li>
                                        <li><a className="dropdown-item" href="faq.html">Faq</a></li>
                                        <li><a className="dropdown-item" href="404.html">Error</a></li>
                                        <li><a className="dropdown-item" href="privacy.html">Privacy</a></li>
                                        <li><a className="dropdown-item" href="tos.html">Terms and Condition</a></li>
                                    </ul>
                                </li>
                                <li className="nav-item"><a className="nav-link" href="contact.html">Contact</a></li>
                            </ul>
                            <div className="header-btn justify-content-end">
                                <a href="#" className="bttn-small btn-fill"><i className="fa fa-key"></i>Register</a>
                                <a href="#" className="bttn-small btn-fill ml-2"><i className="fa fa-lock"></i>Login</a>
                            </div>
                        </div>
                    </div>
                </nav>
            </header>
        </>
    )
};

export default Header;