import apiService from './api.service';
import jwtService from './jwt.service';

const identityPath = 'http://localhost:5001/identity/';
const loginPath = identityPath + 'login';
const registerPath = identityPath + 'register';

const usersService = {
  login: (data: any) => {
    return apiService.post(loginPath, data);
  },

  register: (data: any) => {
    return apiService.post(registerPath, data);
  },

  isAuthenticated: (): boolean => {
    return jwtService.getToken() ? true : false;
  }
};

export default usersService;
