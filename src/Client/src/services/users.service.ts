import apiService from './api.service';
import ICredentials from '../components/models/credentials.model';

const identityPath = 'http://localhost:5001/identity/';
const loginPath = identityPath + 'login';
const registerPath = identityPath + 'register';

const usersService = {
  login: (credentials: ICredentials) => {
    return apiService.post(loginPath, credentials);
  },

  register: (credentials: ICredentials) => {
    return apiService.post(registerPath, credentials);
  }
};

export default usersService;
