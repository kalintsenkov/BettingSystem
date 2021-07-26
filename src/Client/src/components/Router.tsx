import {
    BrowserRouter as Router,
    Route,
    Switch
} from "react-router-dom";

import Home from "./Home";
import Login from "./Login";
import Register from "./Register";

const AppRouter = (): JSX.Element => {
    return (
        <Router>
            <Switch>
                <Route exact path="/" component={Home} />
                <Route exact path="/login" component={Login} />
                <Route exact path="/register" component={Register} />
            </Switch>
        </Router>
    );
}

export default AppRouter;
