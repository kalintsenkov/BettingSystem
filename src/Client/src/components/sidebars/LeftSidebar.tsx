import { useEffect, useState } from 'react';
import { Link } from 'react-router-dom';

import logo from '../../assets/images/icons/leagues/1.png';
import ICountry from '../../models/country';
import ILeague from '../../models/league';
import errorsService from '../../services/errorsService';
import leaguesService from '../../services/leaguesService';

const LeftSidebar = (): JSX.Element => {
  const [leagues, setLeagues] = useState<ILeague[]>([]);
  const [countries, setCountries] = useState<ICountry[]>([]);

  useEffect(() => {
    leaguesService.getAll().subscribe({
      next: res => setLeagues(res.data),
      error: errorsService.handle
    });

    leaguesService.getCountries().subscribe({
      next: res => setCountries(res.data),
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
          {countries &&
            countries.map(country => (
              <li>
                <Link to={''}>
                  <img src={logo} alt="logo" /> {country.name}
                </Link>
              </li>
            ))}
        </ul>
      </aside>
    </div>
  );
};

export default LeftSidebar;
