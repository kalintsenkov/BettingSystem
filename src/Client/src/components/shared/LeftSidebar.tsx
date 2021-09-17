import logo from '../../assets/images/icons/leagues/1.png';

const LeftSidebar = (): JSX.Element => {
  return (
    <div className="col-xl-2 col-lg-2 col-md-3 col-sm-6">
      <aside className="content-sidebar">
        <h3>Leagues</h3>
        <ul>
          <li>
            <a href="">
              <img src={logo} alt="" /> Premier League
            </a>
          </li>
          <li>
            <a href="">
              <img src={logo} alt="" /> LaLiga
            </a>
          </li>
          <li>
            <a href="">
              <img src={logo} alt="" /> UEFA Champions League
            </a>
          </li>
          <li>
            <a href="">
              <img src={logo} alt="" /> Premier League
            </a>
          </li>
        </ul>
      </aside>
      <aside className="content-sidebar">
        <h3>Countries</h3>
        <ul>
          <li>
            <a href="">
              <img src={logo} alt="" /> England
            </a>
          </li>
          <li>
            <a href="">
              <img src={logo} alt="" /> Spain
            </a>
          </li>
          <li>
            <a href="">
              <img src={logo} alt="" /> Germany
            </a>
          </li>
          <li>
            <a href="">
              <img src={logo} alt="" /> Italy
            </a>
          </li>
          <li>
            <a href="">
              <img src={logo} alt="" /> France
            </a>
          </li>
        </ul>
      </aside>
    </div>
  );
};

export default LeftSidebar;
