import { Observable } from 'rxjs';
import { AxiosResponse } from 'axios';

import apiService from './api.service';
import ILeague from '../models/league.model';
import { Endpoints } from '../utilities/constants';

const leaguesService = {
  getAll: (): Observable<AxiosResponse<ILeague[]>> => {
    return apiService.get(Endpoints.LEAGUES_PATH);
  }
};

export default leaguesService;
