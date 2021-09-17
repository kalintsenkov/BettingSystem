import { BrowserRouter as Router, Route, Switch } from 'react-router-dom';

import Home from './Home';
import Login from './authentication/Login';
import Register from './authentication/Register';
import Header from './shared/Header';
import Footer from './shared/Footer';
import RightSidebar from './shared/RightSidebar';
import LeftSidebar from './shared/LeftSidebar';

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
