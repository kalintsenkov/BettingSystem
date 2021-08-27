import apiService from './api.service';
import { Endpoints } from '../utilities/constants';

const matchesService = {
  getAll: () => {
    return apiService.get(Endpoints.MATCHES_PATH);
  }
};

export default matchesService;
