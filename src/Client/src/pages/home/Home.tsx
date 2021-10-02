import React, { useEffect, useState } from 'react';

import DatePicker from 'react-datepicker';
import 'react-datepicker/dist/react-datepicker.css';

import styles from './Home.module.css';
import defaultLogo from './../../assets/images/icons/teams/1.png';
import matchesService from '../../services/matchesService';
import errorsService from '../../services/errorsService';
import IMatch from '../../models/match';
import { IMAGE_DATA } from '../../common/constants';

const Home = (): JSX.Element => {
  const [matches, setMatches] = useState<IMatch[]>([]);
  const [startDate, setStartDate] = useState<Date>();
  const [isDatePickerOpen, setIsDatePickerOpen] = useState<boolean>(false);

  useEffect(() => {
    matchesService.search().subscribe({
      next: res => setMatches(res.data.matches),
      error: errorsService.handle
    });
  }, []);

  useEffect(() => {
    const startDateAsString = startDate?.toDateString();
    if (startDateAsString) {
      matchesService.search(startDateAsString).subscribe({
        next: res => setMatches(res.data.matches),
        error: errorsService.handle
      });
    }
  }, [startDate]);

  const handleDatePickerChange = (date: Date) => {
    setStartDate(date);
  };

  const toggleDatePicker = () => {
    setIsDatePickerOpen(!isDatePickerOpen);
  };

  return (
    <div
      className="col-xl-8 col-lg-8 col-md-6 col-sm-6"
      style={{ marginTop: 40, marginBottom: 40 }}
    >
      <div className="game-box">
        <div className="card">
          <div className="card-header">
            <h3>Football Games</h3>
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
                  All Matches
                </a>
              </li>
              <li className={`search-game ` + styles.searchGame}>
                <input type="text" placeholder="Search" />
                <DatePicker
                  selected={startDate}
                  showTimeInput={false}
                  open={isDatePickerOpen}
                  onChange={handleDatePickerChange}
                  onClickOutside={toggleDatePicker}
                />
                <i className="fa fa-calendar" onClick={toggleDatePicker}></i>
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
                      <th scope="col">Date</th>
                      <th scope="col">Logo</th>
                      <th scope="col">Result</th>
                      <th scope="col">Teams</th>
                      <th scope="col">1</th>
                      <th scope="col">
                        3 Way <br />X
                      </th>
                      <th scope="col">2</th>
                    </tr>
                  </thead>
                  <tbody>
                    {matches.map(match => {
                      return (
                        <tr>
                          <td>
                            {match.startDate.split(' ')[0]}
                            <br />
                            {match.startDate.split(' ')[1]}
                          </td>
                          <td>
                            <img
                              src={
                                match.homeTeamLogoThumbnailContent
                                  ? IMAGE_DATA + match.homeTeamLogoThumbnailContent
                                  : defaultLogo
                              }
                              alt="logo"
                            />
                            <br />
                            <img
                              src={
                                match.awayTeamLogoThumbnailContent
                                  ? IMAGE_DATA + match.awayTeamLogoThumbnailContent
                                  : defaultLogo
                              }
                              alt="logo"
                            />
                          </td>
                          <td>
                            {match.homeTeamScore ?? 0}
                            <br />
                            {match.awayTeamScore ?? 0}
                          </td>
                          <td>
                            <strong>{match.homeTeamName}</strong>
                            <strong>{match.awayTeamName}</strong>
                          </td>
                          <td>
                            <a href="" className="btnn">
                              HOME
                            </a>
                          </td>
                          <td>
                            <a href="" className="btnn">
                              DRAW
                            </a>
                          </td>
                          <td>
                            <a href="" className="btnn">
                              AWAY
                            </a>
                          </td>
                        </tr>
                      );
                    })}
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

export default Home;
