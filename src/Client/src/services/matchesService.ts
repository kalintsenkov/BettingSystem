import { AxiosResponse } from 'axios';
import { Observable } from 'rxjs';

import apiService from './apiService';
import ISearchMatches from '../models/searchMatches';
import { ENDPOINTS } from '../common/constants';

const matchesService = {
  search: (startDate: string = ''): Observable<AxiosResponse<ISearchMatches>> => {
    return apiService.get(ENDPOINTS.MATCHES_PATH + `?startDate=${startDate}`);
  }
};

export default matchesService;
