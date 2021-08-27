import { AxiosResponse } from 'axios';
import { Observable } from 'rxjs';

import apiService from './api.service';
import IMatch from '../models/match.model';
import { Endpoints } from '../utilities/constants';

const matchesService = {
  getAll: (): Observable<AxiosResponse<IMatch[]>> => {
    return apiService.get(Endpoints.MATCHES_PATH);
  }
};

export default matchesService;
