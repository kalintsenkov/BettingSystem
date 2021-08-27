import apiService from './api.service';
import jwtService from './jwt.service';
import ICredentials from '../models/credentials.model';
import { Endpoints } from '../utilities/constants';

const loginPath = Endpoints.IDENTITY_PATH + 'login';
const registerPath = Endpoints.IDENTITY_PATH + 'register';

const usersService = {
  login: (credentials: ICredentials) => {
    return apiService.post(loginPath, credentials);
  },

  register: (credentials: ICredentials) => {
    return apiService.post(registerPath, credentials);
  },

  getRole: (): string => {
    const decoded = jwtService.decode();

    if (!decoded) {
      return '';
    }

    return decoded.role;
  }
};

export default usersService;
