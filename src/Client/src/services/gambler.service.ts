import { Observable } from 'rxjs';
import { AxiosResponse } from 'axios';

import apiService from './api.service';
import IGambler from '../models/gambler.model';
import IGamblerDetails from '../models/gambler-details.model';
import { Endpoints } from '../utilities/constants';

const gamblerService = {
  create: (gambler: IGambler) => {
    return apiService.post(Endpoints.GAMBLERS_PATH, gambler);
  },

  getId: () => {
    return apiService.get(Endpoints.GAMBLERS_PATH + 'Id');
  },

  details: (gamblerId: number): Observable<AxiosResponse<IGamblerDetails>> => {
    return apiService.get(Endpoints.GAMBLERS_PATH + gamblerId);
  }
};

export default gamblerService;
