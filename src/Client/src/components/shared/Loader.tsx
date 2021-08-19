import React from 'react';

const Loader = (): JSX.Element => {
  return (
    <div className="preloader">
      <div className="spinner">
        <span className="spinner-rotate"></span>
      </div>
    </div>
  );
};

export default Loader;
