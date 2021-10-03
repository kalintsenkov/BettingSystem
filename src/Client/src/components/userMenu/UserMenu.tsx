import React, { createRef, useEffect, useMemo, useRef, useState } from 'react';

import styles from './UserMenu.module.scss';

const UserMenu = (): JSX.Element => {
  const [isOpen, setIsOpen] = useState<boolean>(false);

  const spanArrowRef = useRef<HTMLSpanElement>(null);
  const userMenuRef = useRef<HTMLDivElement>(null);

  useMemo(() => {
    if (isOpen) {
      if (userMenuRef.current) {
        userMenuRef.current.style.display = 'inline-block';
      }
      spanArrowRef.current?.classList.remove('fa-chevron-up');
      spanArrowRef.current?.classList.add('fa-chevron-down');
    } else {
      if (userMenuRef.current) {
        userMenuRef.current.style.display = 'none';
      }
      spanArrowRef.current?.classList.remove('fa-chevron-down');
      spanArrowRef.current?.classList.add('fa-chevron-up');
    }
  }, [isOpen]);

  const toggleMenu = (): void => {
    setIsOpen(!isOpen);
  };

  return (
    <div className={styles.userUi}>
      <div className={styles.userMenuToggle} onClick={toggleMenu}>
        <div
          className={styles.profileImg}
          style={{
            backgroundImage: `url('https://perfecto-web.com/uploads/uifaces/ui-9.jpg')`
          }}
        ></div>
        <span className={`${styles.simpleArrow} fa fa-chevron-down`} ref={spanArrowRef}></span>
      </div>

      <div className={styles.userMenu} ref={userMenuRef}>
        <div className={styles.userInfo}>
          <div
            className={styles.profileImg}
            style={{
              backgroundImage: `url('https://perfecto-web.com/uploads/uifaces/ui-9.jpg')`
            }}
          ></div>
          <h3 className="name">Hugo Fonseca</h3>
        </div>

        <div className={styles.menuNav}>
          <li>
            <span className="fa fa-cogs"></span>Settings
          </li>
          <li>
            <span className="fa fa-question"></span>Help
          </li>
          <li>
            <span className="fa fa-power-off"></span>Logout
          </li>
        </div>
      </div>
    </div>
  );
};

export default UserMenu;
