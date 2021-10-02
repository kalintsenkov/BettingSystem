import { useEffect, useState } from 'react';
import { useParams } from 'react-router';

import ILeagueStandings from '../../models/leagueStandings';
import errorsService from '../../services/errorsService';
import leaguesService from '../../services/leaguesService';

const Standings = (): JSX.Element => {
  const { id, league } = useParams<{ id: string; league: string }>();

  const [standings, setStandings] = useState<ILeagueStandings[]>([]);

  useEffect(() => {
    leaguesService.getStandings(Number(id)).subscribe({
      next: res => setStandings(res.data),
      error: errorsService.handle
    });
  }, [id]);

  return (
    <div
      className="col-xl-8 col-lg-8 col-md-6 col-sm-6"
      style={{ marginTop: 40, marginBottom: 40 }}
    >
      <div className="game-box">
        <div className="card">
          <div className="card-header">
            <h3>{league.replace('-', ' ')}</h3>
          </div>
          <div className="card-body">
            <ul className="nav nav-tabs" id="myTab" role="tablist">
              <li className="nav-item">
                <a
                  className="nav-link"
                  id="home"
                  data-toggle="tab"
                  href="#"
                  role="tab"
                  aria-selected="false"
                >
                  Standings
                </a>
              </li>
            </ul>
            <div className="tab-content" id="myTabContent">
              <div
                className="tab-pane fade show active"
                id="home"
                role="tabpanel"
                aria-labelledby="home-tab"
              >
                <table className="table table-hover table-borderless table-striped">
                  <thead>
                    <tr>
                      <th scope="col">Position</th>
                      <th scope="col">Team</th>
                      <th scope="col">Points</th>
                    </tr>
                  </thead>
                  <tbody>
                    {standings.map((team, index) => (
                      <tr>
                        <td>{index + 1}</td>
                        <td>{team.name}</td>
                        <td>{team.points}</td>
                      </tr>
                    ))}
                  </tbody>
                </table>
              </div>
            </div>
          </div>
        </div>
      </div>
    </div>
  );
};

export default Standings;
