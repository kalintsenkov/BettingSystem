import IGambler from '../components/models/gambler.model';
import apiService from './api.service';

const gamblersPath = 'http://localhost:5002/gamblers/';

const gamblerService = {
  create: (gambler: IGambler) => {
    return apiService.post(gamblersPath, gambler);
  }
};

export default gamblerService;
