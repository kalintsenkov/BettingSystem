import apiService from './apiService';
import jwtService from './jwtService';
import ICredentials from '../models/credentials';
import { ENDPOINTS } from '../common/constants';

const loginPath = ENDPOINTS.IDENTITY_PATH + 'login';
const registerPath = ENDPOINTS.IDENTITY_PATH + 'register';

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
  },

  isAuthenticated: (): boolean => {
    return jwtService.getToken() != null;
  }
};

export default usersService;
