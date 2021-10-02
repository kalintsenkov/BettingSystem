import jwtDecode from "jwt-decode";

const key: string = 'token';

const jwtService = {
  saveToken: (token: string): void => {
    localStorage.setItem(key, token);
  },

  getToken: (): string | null => {
    return localStorage.getItem(key);
  },

  removeToken: (): void => {
    return localStorage.removeItem(key);
  },

  decode: (): any => {
    const jwt = jwtService.getToken();

    if (!jwt) {
      return null;
    }

    const decodedToken = jwtDecode(jwt);

    return decodedToken;
  }
};

export default jwtService;
