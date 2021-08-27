import apiService from './api.service';
import IGambler from '../models/gambler.model';

const gamblersPath = 'http://localhost:5002/gamblers/';

const gamblerService = {
  create: (gambler: IGambler) => {
    return apiService.post(gamblersPath, gambler);
  }
};

export default gamblerService;
