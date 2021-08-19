import React from 'react';
import { Link } from 'react-router-dom';

const Footer = (): JSX.Element => {
  return (
    <footer>
      <div className="copyright">
        <div className="container">
          <div className="row">
            <div className="col-xl-12 col-lg-12 col-md-12 col-sm-6">
              <ul>
                <li>
                  <Link to="">Faq</Link>
                </li>
                <li>
                  <Link to="">Privacy</Link>
                </li>
                <li>
                  <Link to="">Game Rules</Link>
                </li>
                <li>
                  <Link to="">Terms and Service</Link>
                </li>
                <li>
                  <Link to="">Support contact</Link>
                </li>
                <li>
                  <Link to="">Cookie policy</Link>
                </li>
                <li>
                  <Link to="">Responsible Gaming</Link>
                </li>
              </ul>
            </div>
          </div>
        </div>
      </div>
    </footer>
  );
};

export default Footer;
