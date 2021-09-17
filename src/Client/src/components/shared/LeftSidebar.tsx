import { useEffect, useState } from 'react';
import { Link } from 'react-router-dom';

import logo from '../../assets/images/icons/leagues/1.png';
import ILeague from '../../models/league.model';
import errorsService from '../../services/errors.service';
import leaguesService from '../../services/leagues.service';

const LeftSidebar = (): JSX.Element => {
  const [leagues, setLeagues] = useState<ILeague[]>([]);

  useEffect(() => {
    leaguesService.getAll().subscribe({
      next: res => setLeagues(res.data),
      error: errorsService.handle
    });
  }, []);

  return (
    <div className="col-xl-2 col-lg-2 col-md-3 col-sm-6">
      <aside className="content-sidebar">
        <h3>Leagues</h3>
        <ul>
          {leagues &&
            leagues.map(league => (
              <li>
                <Link to={`/standings/${league.name.replace(' ', '-')}/${league.id}`}>
                  <img src={logo} alt="logo" /> {league.name}
                </Link>
              </li>
            ))}
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
