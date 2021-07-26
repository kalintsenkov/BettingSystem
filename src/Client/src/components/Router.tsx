import {
    BrowserRouter as Router,
    Route,
    Switch
} from "react-router-dom";

import Home from "./Home";
import Login from "./Login";
import Register from "./Register";
import Header from "./shared/Header";

const AppRouter = (): JSX.Element => {
    return (
        <Router>
            <Header />
            <Switch>
                <Route exact path="/" component={Home} />
                <Route path="/login" component={Login} />
                <Route path="/register" component={Register} />
            </Switch>
        </Router>
    );
}

export default AppRouter;
