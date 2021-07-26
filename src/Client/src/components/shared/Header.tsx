import React from "react";
import { Link } from "react-router-dom";

import logo from "../../assets/images/logo.png";

const Header = (): JSX.Element => {

    return (
        <header className="header-area gradient-bg">
            <nav className="navbar navbar-expand-lg main-menu">
                <div className="container-fluid">

                    <Link className="navbar-brand" to="/">
                        <img src={logo} className="d-inline-block align-top" alt="Logo" />
                    </Link>

                    <button className="navbar-toggler" type="button" data-toggle="collapse" data-target="#navbarSupportedContent" aria-controls="navbarSupportedContent" aria-expanded="false" aria-label="Toggle navigation">
                        <span className="menu-toggle"></span>
                    </button>

                    <div className="collapse navbar-collapse" id="navbarSupportedContent">
                        <ul className="navbar-nav m-auto">
                            <li className="nav-item"><a className="nav-link" href="#">Home</a></li>
                            <li className="nav-item"><a className="nav-link" href="#">About us</a></li>
                            <li className="nav-item"><a className="nav-link" href="#">Inplay</a></li>
                            <li className="nav-item"><a className="nav-link" href="#">Winlist</a></li>
                            <li className="nav-item dropdown">
                                <a className="nav-link dropdown-toggle" href="#" role="button" data-toggle="dropdown" aria-haspopup="true" aria-expanded="false">Pages</a>
                                <ul className="dropdown-menu">
                                    <li><a className="dropdown-item" href="#">Upcomming Match</a></li>
                                    <li><a className="dropdown-item" href="#">Winlist</a></li>
                                    <li><a className="dropdown-item" href="#">Promotion</a></li>
                                    <li><a className="dropdown-item" href="#">Login</a></li>
                                    <li><a className="dropdown-item" href="#">Registration</a></li>
                                    <li><a className="dropdown-item" href="#">Faq</a></li>
                                    <li><a className="dropdown-item" href="#">Error</a></li>
                                    <li><a className="dropdown-item" href="#">Privacy</a></li>
                                    <li><a className="dropdown-item" href="#">Terms and Condition</a></li>
                                </ul>
                            </li>
                            <li className="nav-item"><a className="nav-link" href="#">Contact</a></li>
                        </ul>
                        <div className="header-btn justify-content-end">
                            <Link to="/register" className="bttn-small btn-fill"><i className="fa fa-key"></i>Register</Link>
                            <Link to="/login" className="bttn-small btn-fill ml-2"><i className="fa fa-lock"></i>Login</Link>
                        </div>
                    </div>
                </div>
            </nav>
        </header>
    )
};

export default Header;