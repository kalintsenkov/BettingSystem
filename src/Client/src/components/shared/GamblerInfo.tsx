import { useContext, useEffect, useState } from 'react';

import { toast } from 'react-toastify';

import { AuthenticationContext } from '../contexts/ContextWrapper';
import IGamblerDetails from '../../models/gambler-details.model';
import gamblerService from '../../services/gambler.service';

const GamblerInfo = (): JSX.Element => {
  const { isAuthenticated, gamblerId } = useContext(AuthenticationContext);

  const [gamblerDetails, setGamblerDetails] = useState<IGamblerDetails>();

  useEffect(() => {
    gamblerService.details(gamblerId).subscribe({
      next: res => setGamblerDetails(res.data),
      error: err => {
        const errors: string[] = err.response.data;
        errors.map(e => toast.error(e));
      }
    });
  }, [gamblerId]);

  return (
    <>
      {isAuthenticated && (
        <div className="web-sidebar-widget">
          <div className="widget-head">
            <h3>Gambler info</h3>
          </div>
          <div className="widget-body">
            <p>
              <strong>Name:</strong> {gamblerDetails?.name}
            </p>
            <p>
              <strong>Balance:</strong> {gamblerDetails?.balance}
            </p>
            <p>
              <strong>Total wins:</strong> {gamblerDetails?.totalWins}
            </p>
          </div>
        </div>
      )}
    </>
  );
};

export default GamblerInfo;
