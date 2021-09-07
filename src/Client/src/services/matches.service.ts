import { AxiosResponse } from 'axios';
import { Observable } from 'rxjs';

import apiService from './api.service';
import ISearchMatches from '../models/search-matches.mode';
import { Endpoints } from '../utilities/constants';

const matchesService = {
  getAll: (): Observable<AxiosResponse<ISearchMatches>> => {
    return apiService.get(Endpoints.MATCHES_PATH);
  }
};

export default matchesService;
