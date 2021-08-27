import apiService from './api.service';
import jwtService from './jwt.service';
import ICredentials from '../models/credentials.model';

const identityPath = 'http://localhost:5001/identity/';
const loginPath = identityPath + 'login';
const registerPath = identityPath + 'register';

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
