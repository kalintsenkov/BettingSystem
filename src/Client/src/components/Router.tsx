import { BrowserRouter as Router, Route, Switch } from 'react-router-dom';

import Login from '../pages/authentication/Login';
import Register from '../pages/authentication/Register';
import Home from '../pages/home/Home';
import Standings from '../pages/standings/Standings';
import Footer from './footer/Footer';
import Header from './header/Header';
import LeftSidebar from './sidebars/LeftSidebar';
import RightSidebar from './sidebars/RightSidebar';

const AppRouter = (): JSX.Element => {
  return (
    <Router>
      <Header />
      <section>
        <div className="container-fluid">
          <div className="row">
            <LeftSidebar />
            <Switch>
              <Route exact path="/" component={Home} />
              <Route path="/home" component={Home} />
              <Route path="/login" component={Login} />
              <Route path="/register" component={Register} />
              <Route path="/standings/:league/:id" component={Standings} />
            </Switch>
            <RightSidebar />
          </div>
        </div>
      </section>
      <Footer />
    </Router>
  );
};

export default AppRouter;
