import ads from '../../assets/images/ads.jpg';

const AdsSidebar = (): JSX.Element => {
  return (
    <div className="col-xl-2 col-lg-2 col-md-3 col-sm-6">
      <div className="web-sidebar-widget">
        <div className="widget-head">
          <h3>Gambler info</h3>
        </div>
        <div className="widget-body">
          <p>
            <strong>Register:</strong> SMS 'JOIN' to 26587
          </p>
          <p>
            <strong>Customer care:</strong> 987654123
          </p>
          <p>
            <strong>Customer care 2:</strong> 987654123
          </p>
          <p>
            <strong>Email:</strong> info@betsb.com
          </p>
        </div>
      </div>
      <div className="web-sidebar-widget">
        <div className="widget-head">
          <h3>Betting system ads</h3>
        </div>
        <div className="widget-body p-0">
          <a href="">
            <img className="w-100" src={ads} alt="" />
          </a>
        </div>
      </div>
    </div>
  );
};

export default AdsSidebar;
