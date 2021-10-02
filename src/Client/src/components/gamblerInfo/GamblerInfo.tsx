import { useContext, useEffect, useState } from 'react';

import { AuthenticationContext } from '../contexts/ContextWrapper';
import IGamblerDetails from '../../models/gamblerDetails';
import errorsService from '../../services/errorsService';
import gamblerService from '../../services/gamblerService';

const GamblerInfo = (): JSX.Element => {
  const { isAuthenticated, gamblerId } = useContext(AuthenticationContext);

  const [gamblerDetails, setGamblerDetails] = useState<IGamblerDetails>();

  useEffect(() => {
    if (gamblerId) {
      gamblerService.details(gamblerId).subscribe({
        next: res => setGamblerDetails(res.data),
        error: errorsService.handle
      });
    }
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
