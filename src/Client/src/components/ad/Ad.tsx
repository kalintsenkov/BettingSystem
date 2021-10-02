import ads from '../../assets/images/ads.jpg';

const Ad = (): JSX.Element => {
  return (
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
  );
};

export default Ad;
