import { AxiosResponse } from 'axios';
import { Observable } from 'rxjs';

import apiService from './api.service';
import ISearchMatches from '../models/search-matches.mode';
import { Endpoints } from '../utilities/constants';

const matchesService = {
  search: (startDate: string = ''): Observable<AxiosResponse<ISearchMatches>> => {
    return apiService.get(Endpoints.MATCHES_PATH + `?startDate=${startDate}`);
  }
};

export default matchesService;
