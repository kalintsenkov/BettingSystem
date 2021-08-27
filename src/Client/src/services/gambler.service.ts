import apiService from './api.service';
import IGambler from '../models/gambler.model';
import { Endpoints } from '../utilities/constants';

const gamblerService = {
  create: (gambler: IGambler) => {
    return apiService.post(Endpoints.GAMBLERS_PATH, gambler);
  }
};

export default gamblerService;
