import axios, { AxiosRequestConfig } from 'axios';

import jwtService from './jwt.service';

const axiosInstance = axios.create();

axiosInstance.interceptors.request.use(
  (config) => {
    config.headers = {
      Authorization: `Bearer ${jwtService.getToken()}`,
      Accept: 'application/json',
      'Content-Type': 'application/json'
    };
    return config;
  },
  (error) => {
    Promise.reject(error);
  }
);

axiosInstance.interceptors.response.use(
  (response) => {
    return response;
  },
  (error) => {
    const originalRequest = error.config;
    if (error.response.status === 403 && !originalRequest._retry) {
      originalRequest._retry = true;
      axios.defaults.headers.common['Authorization'] = 'Bearer ' + jwtService.getToken();
      return axiosInstance(originalRequest);
    }
    return Promise.reject(error);
  }
);

const apiService = {
  get: (path: string, config?: AxiosRequestConfig) => {
    return axiosInstance.get(path, config);
  },

  post: (path: string, body?: Object, config?: AxiosRequestConfig) => {
    return axiosInstance.post(path, body, config);
  },

  put: (path: string, body?: Object, config?: AxiosRequestConfig) => {
    return axiosInstance.put(path, body, config);
  },

  delete: (path: string, config?: AxiosRequestConfig) => {
    return axiosInstance.delete(path, config);
  }
};

export default apiService;
