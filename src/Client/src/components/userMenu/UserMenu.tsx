import React, { useContext, useEffect, useMemo, useRef, useState } from 'react';
import { useHistory } from 'react-router-dom';

import styles from './UserMenu.module.scss';
import profileImage from '../../assets/images/profile.jpg';
import { AuthenticationContext } from '../contexts/ContextWrapper';
import IGamblerDetails from '../../models/gamblerDetails';
import jwtService from '../../services/jwtService';
import gamblerService from '../../services/gamblerService';
import errorsService from '../../services/errorsService';

const UserMenu = (): JSX.Element => {
  const history = useHistory();
  const { gamblerId, isAuthenticated, setIsAuthenticated } = useContext(AuthenticationContext);

  const [isOpen, setIsOpen] = useState<boolean>(false);
  const [gamblerDetails, setGamblerDetails] = useState<IGamblerDetails>();

  const spanArrowRef = useRef<HTMLSpanElement>(null);
  const userMenuRef = useRef<HTMLDivElement>(null);

  useEffect(() => {}, [isAuthenticated]);

  useEffect(() => {
    if (gamblerId) {
      gamblerService.details(gamblerId).subscribe({
        next: res => setGamblerDetails(res.data),
        error: errorsService.handle
      });
    }
  }, [gamblerId]);

  useMemo(() => {
    if (isOpen) {
      if (userMenuRef.current) {
        userMenuRef.current.style.display = 'inline-block';
      }
      spanArrowRef.current?.classList.toggle('fa-chevron-down');
      spanArrowRef.current?.classList.toggle('fa-chevron-up');
    } else {
      if (userMenuRef.current) {
        userMenuRef.current.style.display = 'none';
      }
      spanArrowRef.current?.classList.toggle('fa-chevron-up');
      spanArrowRef.current?.classList.toggle('fa-chevron-down');
    }
  }, [isOpen]);

  const toggleMenu = (): void => {
    setIsOpen(!isOpen);
  };

  const logout = (): void => {
    jwtService.removeToken();
    setIsAuthenticated(false);
    history.push('/');
  };

  return (
    <div className={styles.userUi}>
      <div className={styles.userMenuToggle} onClick={toggleMenu}>
        <div
          className={styles.profileImg}
          style={{
            backgroundImage: `url(${profileImage})`
          }}
        ></div>
        <span className={`${styles.simpleArrow} fa fa-chevron-down`} ref={spanArrowRef}></span>
      </div>

      <div className={styles.userMenu} ref={userMenuRef}>
        <div className={styles.userInfo}>
          <h3>{gamblerDetails?.name}</h3>
          <h3>
            Balance: <strong>{gamblerDetails?.balance.toFixed()}</strong>
          </h3>
        </div>

        <div className={styles.menuNav}>
          <li>
            <span className="fa fa-cogs"></span>Settings
          </li>
          <li>
            <span className="fa fa-arrow-down"></span>Deposit
          </li>
          <li>
            <span className="fa fa-arrow-up"></span>Withdraw
          </li>
          <li onClick={logout}>
            <span className="fa fa-power-off"></span>Logout
          </li>
        </div>
      </div>
    </div>
  );
};

export default UserMenu;
