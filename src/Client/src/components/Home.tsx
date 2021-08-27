import React, { useEffect, useState } from 'react';

import { toast } from 'react-toastify';

import IMatch from '../models/match.model';
import matchesService from '../services/matches.service';

const Home = (): JSX.Element => {
  const [matches, setMatches] = useState<IMatch[]>([]);

  useEffect(() => {
    matchesService.getAll().subscribe({
      next: res => {
        setMatches(res.data);
      },
      error: err => {
        const errors: string[] = err.response.data;
        errors.map(e => toast.error(e));
      }
    });
  }, []);

  return <>{JSON.stringify(matches)}</>;
};

export default Home;
