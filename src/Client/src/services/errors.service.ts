import { toast } from 'react-toastify';

const errorsService = {
  handle: (err: any) => {
    const errorData = err.response.data;
    const errors = errorData.errors
      ? Object.keys(errorData.errors || {}).map(key => `${errorData.errors[key]}`)
      : Object.keys(errorData || {}).map(key => `${errorData[key]}`);

    errors.map(e => toast.error(e));
  }
};

export default errorsService;
