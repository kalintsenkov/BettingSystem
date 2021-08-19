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
  }
};

export default jwtService;
