import React from "react";

import "./../assets/css/bootstrap.min.css";
import "./../assets/css/font-awesome.min.css";
import "./../assets/css/jquery-ui.css";
import "./../assets/css/main.css";

import Router from "./Router";
import ContextWrapper from "./contexts/ContextWrapper";

const App = (): JSX.Element => {
    return (
        <ContextWrapper>
            <Router />
        </ContextWrapper>
    )
};

export default App;
