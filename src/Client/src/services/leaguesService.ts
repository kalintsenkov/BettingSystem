import { Observable } from 'rxjs';
import { AxiosResponse } from 'axios';

import apiService from './apiService';
import ILeague from '../models/league';
import ILeagueStandings from '../models/leagueStandings';
import { ENDPOINTS } from '../common/constants';

const leaguesService = {
  getAll: (): Observable<AxiosResponse<ILeague[]>> => {
    return apiService.get(ENDPOINTS.LEAGUES_PATH);
  },

  getStandings: (leagueId: number): Observable<AxiosResponse<ILeagueStandings[]>> => {
    return apiService.get(ENDPOINTS.LEAGUES_PATH + leagueId + '/standings');
  }
};

export default leaguesService;
