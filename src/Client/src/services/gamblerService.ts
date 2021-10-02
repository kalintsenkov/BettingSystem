import { Observable } from 'rxjs';
import { AxiosResponse } from 'axios';

import apiService from './apiService';
import IGambler from '../models/gambler';
import IGamblerDetails from '../models/gamblerDetails';
import { ENDPOINTS } from '../common/constants';

const gamblerService = {
  create: (gambler: IGambler) => {
    return apiService.post(ENDPOINTS.GAMBLERS_PATH, gambler);
  },

  getId: () => {
    return apiService.get(ENDPOINTS.GAMBLERS_PATH + 'Id');
  },

  details: (gamblerId: number): Observable<AxiosResponse<IGamblerDetails>> => {
    return apiService.get(ENDPOINTS.GAMBLERS_PATH + gamblerId);
  },

  deposit: (amount: number): Observable<AxiosResponse<void>> => {
    return apiService.put(ENDPOINTS.GAMBLERS_PATH + 'Deposit', { amount });
  },

  withdraw: (amount: number): Observable<AxiosResponse<void>> => {
    return apiService.put(ENDPOINTS.GAMBLERS_PATH + 'Withdraw', { amount });
  }
};

export default gamblerService;
